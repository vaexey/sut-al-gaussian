#include "gauss.h"
#include <stdio.h>
#include <stdbool.h>
#include <math.h>
#include <string.h>

const char* LIB_ID = "GAUSSIAN_HLL";

int id(
	char* id,
	int id_len
)
{
	const int len = strlen(LIB_ID);

	if (id_len < len)
	{
		return -1;
	}

	strcpy(id, LIB_ID);

	return 0;
}

void filter(
	char* kernel,
	int radius,
	unsigned char* src,
	unsigned char* dest,
	int width,
	int height,
	int stride,

	int y1,
	int y2
)
{
	int rx1 = 0;
	int rx2 = width * 3;

	int ksize = gauss_kernel_size(radius);
	int klen = ksize * ksize;

	for (int y = y1; y < y2 ; y++)
	{
		for (int rx = 0; rx < rx2; rx++)
		{
			int sum = 0;
			int weight = 0;

			for (int ky = 0; ky < ksize; ky++)
			{
				for (int kx = 0; kx < ksize; kx++)
				{
					int mx = rx + kx - radius;
					int my = y + ky - radius;

					char k = kernel[ky * ksize + kx];
					char px = src[y * stride + rx];

					sum += k * px;
					weight += k;
				}
			}

			dest[y * stride + rx] = sum / weight;
		}
	}
}

#define GAUSS_PI 3.14159265358979323846
void gauss_kernel(
	char* kernel,
	int radius
)
{
	const int size = gauss_kernel_size(radius);
	const double sigma = size / 3.0;

	const double modifier = 1 / (2 * GAUSS_PI * sigma * sigma);
	const double sigma_div2sq = -1.0 / (2 * sigma * sigma);

	double max = 0.0;

	for (int i = 0; i < size; i++)
		for (int j = 0; j < size; j++)
		{
			const double di = radius - i;
			const double dj = radius - j;
			const double power = sigma_div2sq * (di * di + dj * dj);
			const double value = modifier * exp(power);

			if (value > max)
				max = value;
		}

	for (int i = 0; i < size; i++)
		for (int j = 0; j < size; j++)
		{
			const double di = radius - i;
			const double dj = radius - j;
			const double power = sigma_div2sq * (di * di + dj * dj);
			const double value = modifier * exp(power) / max * 20.0;

#ifdef DEBUG
			printf("%f\n", value);
#endif
			kernel[size * j + i] = (int)value;
		}
}

int gauss_kernel_size(
	int radius
)
{
	return 2 * radius + 1;
}

void filter_24bpp_k3(
	char* kernel,
	unsigned char* src,
	unsigned char* dest,
	int startIndex,
	int endIndex,
	int width,
	int stride
)
{
	printf("S: %d\nE: %d\nW: %d\nStrzoda: %d\n", startIndex, endIndex, width, stride);

	const int BPP = 3;

	int i = startIndex * stride;

	int kernelWeight = 0;
	for (int i = 0; i < 9; i++)
		kernelWeight += kernel[i];

	for (int y = startIndex; y < endIndex; y++)
	{
		int next = i + stride;
		int lim = i + width * BPP;

		while (i < lim)
		{
			int x = i % stride;
			if (x < 30 || x >(stride - 30))
			{
				i += 1;
				continue;
			}

			int kptr = i - stride - BPP;
			int ksum = 0;

			for (int k = 0; k < 3; k++)
				ksum += kernel[k] * src[kptr + BPP * k];
			kptr += stride;

			for (int k = 0; k < 3; k++)
				ksum += kernel[3 + k] * src[kptr + BPP * k];
			kptr += stride;

			for (int k = 0; k < 3; k++)
				ksum += kernel[6 + k] * src[kptr + BPP * k];

			dest[i] = ksum / kernelWeight;

			//int ben = (1 + (int)src[i]);
			//if (ben > 255)
			//	ben = 255;
			//dest[i] = ben;

			//dest[i] = 128;

			i += 1;
			//i += BPP;
		}

		i = next;
	}
}

void filter_uniform(
	char* kernel,
	int radius,
	unsigned char* src,
	unsigned char* dest,
	int startIndex,
	int endIndex,
	int width,
	int height,
	int stride
)
{
#ifdef DEBUG
	printf("S: %d\nE: %d\nW: %d\nS: %d\n", startIndex, endIndex, width, stride);
#endif

	const int BPP = 3;
	
	const int KSIZE = radius * 2 + 1;
	const int KLEN = KSIZE * KSIZE;

	int kweight = 0;

	for (int i = 0; i < KLEN; i++)
		kweight += kernel[i];

	if ((startIndex - radius) < 0)
	{
		startIndex = radius;
	}
	if ((endIndex + radius) > height)
	{
		endIndex = height - 1 - radius;
	}

	int i = startIndex * stride;

	for (int y = startIndex; y < endIndex; y++)
	{
		int ksafe_shift = radius * BPP;

		int next = i + stride;
		int lim_before = i + ksafe_shift;
		int lim = i + width * BPP;
		int lim_unsafe = lim - ksafe_shift;

		int before_counter = 0;
		int before_start = radius;
		while (i < lim_before)
		{
			//int kptr = i - (radius * stride + radius * BPP);
			//int ksum = 0;
			//int kweight_subset = 0;

			//for (int ky = 0; ky < KLEN; ky += KSIZE)
			//{
			//	for (int k = before_start; k < KSIZE; k++)
			//	{
			//		int w = kernel[ky + k];

			//		ksum += w * src[kptr + k * BPP];
			//		kweight_subset += w;
			//	}

			//	kptr += stride;
			//}

			//dest[i] = ksum / kweight_subset;

			i += 1;
			before_counter++;

			if (before_counter == BPP)
			{
				before_counter = 0;
				before_start -= 1;
			}
		}
		while (i < lim_unsafe)
		{
			int kptr = i - (radius * stride + radius * BPP);
			int ksum = 0;

			for (int ky = 0; ky < KLEN; ky += KSIZE)
			{
				for (int k = 0; k < KSIZE; k++)
					ksum += kernel[ky + k] * src[kptr + k * BPP];

				kptr += stride;
			}

			dest[i] = ksum / kweight;

			i += 1;
		}
		//int after_counter = 0;
		//int after_end = KSIZE;
		//while (i < lim)
		//{
		//	int kptr = i - (radius * stride + radius * BPP);
		//	int ksum = 0;
		//	int kweight_subset = 0;

		//	for (int ky = 0; ky < KLEN; ky += KSIZE)
		//	{
		//		for (int k = 0; k < after_end; k++)
		//		{
		//			int w = kernel[ky + k];

		//			ksum += w * src[kptr + k * BPP];
		//			kweight_subset += w;
		//		}

		//		kptr += stride;
		//	}

		//	dest[i] = ksum / kweight_subset;

		//	i += 1;
		//	after_counter++;

		//	if (after_counter == BPP)
		//	{
		//		after_counter = 0;
		//		after_end -= 1;
		//	}
		//}

		i = next;
	}
}
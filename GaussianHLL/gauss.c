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

		i = next;
	}
}
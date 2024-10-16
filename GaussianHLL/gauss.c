#include "gauss.h"

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

void gauss_kernel(
	char* kernel,
	int radius
)
{
	int size = gauss_kernel_size(radius);

	for (int i = 0; i < size; i++)
		for (int j = 0; j < size; j++)
			kernel[size*j + i] = 1;
}

int gauss_kernel_size(
	int radius
)
{
	return 2 * radius + 1;
}
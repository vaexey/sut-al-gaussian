#include "gauss.h"

void filter(
	unsigned char* src,
	unsigned char* dest,
	int width,
	int height,
	char* kernel
)
{
	for (int y = 0; y < height; y++)
	{
		for (int x = 0; x < width; x++)
		{
			for (int c = 0; c < 3; c++)
			{

			}
		}
	}
}

void gauss_kernel(
	char* kernel,
	int radius
)
{
	int size = gauss_kernel_size;

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
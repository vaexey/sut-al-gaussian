#define DLLEXPORT __declspec(dllexport) 

void DLLEXPORT filter(
	char* kernel,
	int radius,
	unsigned char* src,
	unsigned char* dest,
	int width,
	int height,
	int stride,

	int y1,
	int y2
);

void DLLEXPORT gauss_kernel(
	char* kernel,
	int radius
);

int DLLEXPORT gauss_kernel_size(
	int radius
);
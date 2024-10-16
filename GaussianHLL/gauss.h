#define DLLEXPORT __declspec(dllexport) 

void DLLEXPORT filter(
	unsigned char* src,
	unsigned char* dest,
	int width,
	int height,
	char* kernel
);

void DLLEXPORT gauss_kernel(
	char* kernel,
	int radius
);

int DLLEXPORT gauss_kernel_size(
	int radius
);
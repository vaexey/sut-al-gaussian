#define DLLEXPORT __declspec(dllexport)
//#define DEBUG

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

void DLLEXPORT filter_24bpp_k3(
	char* kernel,
	unsigned char* src,
	unsigned char* dest,
	int startIndex,
	int endIndex,
	int width,
	int stride
);

void DLLEXPORT filter_uniform(
	char* kernel,
	int radius,
	unsigned char* src,
	unsigned char* dest,
	int startIndex,
	int endIndex,
	int width,
	int stride
	//bool ysafe
);
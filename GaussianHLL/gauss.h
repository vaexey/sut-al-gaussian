#define DLLEXPORT __declspec(dllexport)
//#define DEBUG

int DLLEXPORT id(
	char* id,
	int id_len
);

void DLLEXPORT gauss_kernel(
	char* kernel,
	int radius
);

int DLLEXPORT gauss_kernel_size(
	int radius
);

void DLLEXPORT filter_uniform(
	char* kernel,
	int radius,
	unsigned char* src,
	unsigned char* dest,
	int startIndex,
	int endIndex,
	int width,
	int height,
	int stride
);
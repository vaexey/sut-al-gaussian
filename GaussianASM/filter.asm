;; Extern to print stdout
; extern __imp_wprintf:qword

.const

MSG_BEGIN DB "filter_uniform begin",0

;; bytes per pixel const
BPP DQ 3

CONST_0 DQ 0,0,0,0

SHUF_MASK_B DB 0,0FFH,3,0FFH,6,0FFH,9,0FFH,12,0FFH,15,0FFH,18,0FFH,21,0FFH,24,0FFH,27,0FFH,30,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH
SHUF_MASK_G DB 1,0FFH,4,0FFH,7,0FFH,10,0FFH,13,0FFH,16,0FFH,19,0FFH,22,0FFH,25,0FFH,28,0FFH,31,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH

SHUF_MASK_KGEN_R5 DB 0,0FFH,1,0FFH,2,0FFH,3,0FFH,4,0FFH,5,0FFH,6,0FFH,7,0FFH,8,0FFH,9,0FFH,10,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH,0FFH

KERN_R5_ROW_0 DW 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
KERN_R5_ROW_1 DW 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
KERN_R5_ROW_2 DW 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
KERN_R5_ROW_3 DW 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
KERN_R5_ROW_4 DW 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
KERN_R5_ROW_5 DW 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2

.code

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; macro row_mult_5
;;	arg0: sourceRow - source avx reg for the row
;;  arg1: shufMask - shuffle mask for the row
;;  arg2: kernRow - kernel row
;;  arg3: sum - summing destination
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Expands to instructions that:
;;  - shuffle given sourceRow YMM register to extract B/G/R bytes
;;  - shuffle given B/G/R/ bytes into packed words
;;  - multiply packed words by given kernRow
;;  - horizontally sum packed words into sum
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
row_mult_5 macro sourceRow, shufMask, kernRow, sum

;; Shuffle B bytes into words (all B bytes joined with 0x00 byte)
vpshufb YMM0, sourceRow, ymmword ptr [shufMask]

;; Multiply row by appropriate kernel row
vpmullw YMM0, YMM0, ymmword ptr [kernRow]

;; Sum horizontally weighted values until all are accumulated in two qwords
;; 1st iteration of word vertical sum
vphaddw YMM0, YMM0, ymmword ptr [CONST_0]
;; 2nd iteration of word vertical sum
vphaddw YMM0, YMM0, ymmword ptr [CONST_0]
;; 3rd iteration of word vertical sum
vphaddw YMM0, YMM0, ymmword ptr [CONST_0]

;; Extract lower half
movq RBX, XMM0

;; Swap xmmwords inside YMM
vperm2f128 YMM0, YMM0, YMM0, 000000001B

;; Extract upper half
movq RAX, XMM0

;; Sum both halves
add RAX, RBX

;; Add to total sum
add RAX, sum
mov sum, RAX

endm

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; macro ker_sum_5
;;  arg0: shufMask - shuffle mask for the rows
;;  arg1: kernelPtr - kernel vector table pointer
;;  arg2: sum - summing destination
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Expands to instructions that:
;;  - perform row_mult_5 macro with shufMask 11 times
;;  - stores resulting sum into sum
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
ker_sum_5 macro shufMask, kernelPtr, sum

;; Set sum register to 0
mov R12, 0

;; Calculate sum for all the rows (11 times)
row_mult_5 YMM1, shufMask, kernelPtr+0*32, sum
row_mult_5 YMM2, shufMask, kernelPtr+1*32, sum
row_mult_5 YMM3, shufMask, kernelPtr+2*32, sum
row_mult_5 YMM4, shufMask, kernelPtr+3*32, sum
row_mult_5 YMM5, shufMask, kernelPtr+4*32, sum

row_mult_5 YMM6, shufMask, kernelPtr+5*32, sum

row_mult_5 YMM7, shufMask, kernelPtr+4*32, sum
row_mult_5 YMM8, shufMask, kernelPtr+3*32, sum
row_mult_5 YMM9, shufMask, kernelPtr+2*32, sum
row_mult_5 YMM10, shufMask, kernelPtr+1*32, sum
row_mult_5 YMM11, shufMask, kernelPtr+0*32, sum

endm

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; void filter_uniform(
;;	uint8_t* kernel,
;;	uint64_t radius,
;;	uint8_t* src,
;;	uint8_t* dest,
;;	uint64_t startIndex,
;;	uint64_t endIndex,
;;	uint64_t width,
;;	uint64_t height,
;;	uint64_t stride
;;)
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Applies gauss filter
;; TODO: DOCS
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
filter_uniform proc

;; Enter stack frame with 0x200 depth
push RBP
mov RBP, RSP
sub RSP, 0200h

;; Push all nonvolatile registers (except RBP for leave instruction)
push RBX
push RDI
push RSI
push R12
push R13
push R14
push R15

;; Stack variables
;; 0x08 - 
;; 0x10 - 
;; 0x18 - 
;; 0x20 - 
;; 0x28
;; 0x30
;; 0x38
;; 0x40 - tempSrcIdx
;; 0x48 - KSIZE
;; 0x50 - KLEN
;; 0x58 - kweight
;; 0x60 - yEnd
;; 0x080 - KERNEL ROW 5 (32b)
;; 0x0A0 - KERNEL ROW 4 (32b)
;; 0x0C0 - KERNEL ROW 3 (32b)
;; 0x0E0 - KERNEL ROW 2 (32b)
;; 0x100 - KERNEL ROW 1 (32b)
;; 0x120 - KERNEL ROW 0 (32b) - base vector KERNEL ptr

;; Args in ascending order:
;; RCX - kernel ptr
;; RDX - radius
;; R8 - src ptr
;; R9 - dest ptr
;; [RBP+0x30] - startIndex
;; [RBP+0x38] - endIndex
;; [RBP+0x40] - width
;; [RBP+0x48] - height
;; [RBP+0x50] - stride

;; Unpack stack arguments
mov R10, [RBP+030h]
mov R11, [RBP+038h]
mov R12, [RBP+040h]
mov R13, [RBP+048h]
mov R14, [RBP+050h]

mov [RBP+010h], RCX
mov [RBP+018h], RDX
mov [RBP+020h], R8
mov [RBP+028h], R9

;; KERNEL CALCULATIONS

;; Calc KSIZE = 2*radius + 1
mov RAX, [RBP+018h]
mov RDX, 2
mul RDX

add RAX, 1

;; Store on stack
mov [RBP-048h], RAX

;; Calc KLEN = KSIZE^2
mov RDX, RAX
mul RDX

;; Store on stack
mov [RBP-050h], RAX

;; Vectorize kernel

;; Load KSIZE
mov RAX, [RBP-048h]

;; Load kernel array pointer
mov RBX, [RBP+010h]

;; Iterate 6 times (rows 0-4 and middle row 5)
kGenIdx = 0
rept 6

;; Load row (with overflow) to YMM
vmovups YMM0, ymmword ptr [RBX]

;; Shuffle first 11 values to words (dispose other data)
vpshufb YMM0, YMM0, ymmword ptr [SHUF_MASK_KGEN_R5]

;; Store to kernel vector array
vmovups ymmword ptr [RBP-0120H+kGenIdx*32], YMM0

;; Increment kernel array pointer by KSIZE
add RBX, RAX

kGenIdx = kGenIdx + 1
endm

;; Calculate weight of full matrix
;; Sum all matrix values to RAX
mov RAX, 0

;; Load address of kernel array (subtract one due to loop CX range of 1..9)
mov RBX, [RBP+010h]
sub RBX, 1

;; Clear RDX to allow summing just bytes
xor RDX, RDX

;; Iterate over kernel KLEN times
mov RCX, [RBP-050h]
kernel_loop:

;; Add (next) kernel value to sum register
mov DL, byte ptr [RBX + RCX]
add RAX, RDX

loop kernel_loop

;; Store kernel weight (sum) on stack
mov [RBP-058h], RAX

;; Main filter loop
;; Register purpose:
;; RAX - general
;; RBX - general
;; RCX - 
;; RDX - 
;; RSI - srcPtr
;; RDI - destPtr
;; R8  - y loop index [startIndex..endIndex]
;; R9  - x loop index [yStrideIndex..(yStrideIndex+width*BPP)]
;; R10 - xEnd = y+width*BPP
;; R11 - yStrideIndex
;; R12 - per pixel sum
;; R13 - x loop src[index]
;; R14 - x loop dest[index]
;; R15 - stride
;; ------------
;; AVX registers purpose:
;; YMM0 - general; used by row macro
;; YMM1 - row 0
;; YMM2 - row 1
;; YMM3 - row 2
;; YMM4 - row 3
;;     ...

;; Load src and dest pointers
mov RSI, [RBP+020h]
mov RDI, [RBP+028h]

;; Load stride value to register
mov R15, [RBP+050h]

;; Store y start value = startIndex
mov R8, [RBP+030h]

;; Safety measure: skip dangerous y range by shrinking by radius
mov RAX, [RBP+018h]
add R8, RAX
sub [RBP+038h], RAX

;; Safety measure #2: skip dangerous y end range
sub qword ptr [RBP+038h], 20

;; Store yStrideIndex start value = startIndex * stride
mov RAX, R8
mul R15
mov R11, RAX

;; for loop y=startIndex to endIndex
y_loop:

;; Store x start value = yStrideIndex
mov R9, R11

;; Store xEnd value = yStrideIndex + width*BPP
mov RAX, [RBP+040h]
mul BPP
add RAX, R11
mov R10, RAX

;; Safety measure: skip dangerous x range by shrinking by radius*BPP
mov RAX, [RBP+018h]
mul BPP
add R9, RAX
sub R10, RAX

;; for loop x to xEnd
x_loop:

;; PIXEL
;; Relative index: R9
;; Relative to: RSI, RDI
;; R13 - src[index]
;; R14 - dest[index]

;; Create offset radius*(stride+BPP) from index to align kernel
mov RAX, R15
add RAX, BPP
mul qword ptr [RBP+018h]

;; Subtract accumulated offset
mov RBX, R9
sub RBX, RAX

;; Calculate ptr to first kernel value in source and store
lea R13, [RSI+RBX]

;; Calculate ptr to dest and store
lea R14, [RDI+R9]

;; Store tempSrcIdx for next load macro
mov [RBP-040H], R13

;; Load 11 rows into YMM registers (1..11)
;; Increment ptr by stride every row
ymmIdx = 1
rept 11
@CatStr(<vmovups YMM>, %ymmIdx, <, [R13+0]>)
add R13, R15
ymmIdx = ymmIdx + 1
endm

;; Calculate kernel sum for B byte and store in R12
ker_sum_5 SHUF_MASK_B, RBP-0120H, R12

;; Store sum into RAX
mov RAX, R12

;; Divide by weight
mov RBX, [RBP-058h]
mov RDX, 0
div RBX

;; Store B byte
mov byte ptr [R14+0], AL

;; Calculate kernel sum for G byte and store in R12
ker_sum_5 SHUF_MASK_G, RBP-0120H, R12

;; Store sum into RAX
mov RAX, R12

;; Divide by weight
mov RBX, [RBP-058h]
mov RDX, 0
div RBX

;; Store G byte
mov byte ptr [R14+1], AL

;; Restore start index back to realign YMMs for R byte
mov R13, [RBP-040H]

;; Add 1 offset to skip first B byte
add R13, 1

;; Load 11 rows into YMM registers (1..11)
;; Increment ptr by stride every row
ymmIdx = 1
rept 11
@CatStr(<vmovups YMM>, %ymmIdx, <, [R13+0]>)
add R13, R15
ymmIdx = ymmIdx + 1
endm

;; Calculate kernel sum for R byte and store in R12
;; (MASK_G since all bytes are shifted to the left)
ker_sum_5 SHUF_MASK_G, RBP-0120H, R12

;; Store sum into RAX
mov RAX, R12

;; Divide by weight
mov RBX, [RBP-058h]
mov RDX, 0
div RBX

;; Store R byte
mov byte ptr [R14+2], AL

;; END PIXEL

;; Increment x by one
;inc R9
add R9, 3

;; Go back if not reached xEnd yet
cmp R9, R10
jne x_loop

;; Increment y by one
inc R8

;; Increment yStrideIndex by stride
add R11, R15

;; Go back if not reached endIndex yet
cmp R8, [RBP+038h]
jne y_loop

;; Pop all saved nonvolatile registers in reverse order
pop R15
pop R14
pop R13
pop R12
pop RSI
pop RDI
pop RBX

;; Leave stack frame
leave
ret

filter_uniform endp

end
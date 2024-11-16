;; Extern to print stdout
; extern __imp_wprintf:qword

.const

MSG_BEGIN DB "filter_uniform begin",0

;; bytes per pixel const
BPP DQ 3

.code

;;;;;;;;;;;
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
;;;;;;
;; Applies gauss filter
;; TODO: DOCS
;;;;;;;
filter_uniform proc

;; Enter stack frame with 0x80 depth
push RBP
mov RBP, RSP
sub RSP, 080h

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
;; 0x40
;; 0x48 - KSIZE
;; 0x50 - KLEN
;; 0x58 - kweight
;; 0x60 - yEnd

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
;; R12 - 
;; R13 - x loop src[index]
;; R14 - x loop dest[index]
;; R15 - stride

;; Load src and dest pointers
mov RSI, [RBP+020h]
mov RDI, [RBP+028h]

;; Load stride value to register
mov R15, [RBP+050h]

;; Store y start value = startIndex
mov R8, [RBP+030h]

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

;; for loop x to xEnd
x_loop:

;; PIXEL
;; Relative index: R9
;; Relative to: RSI, RDI
;; R13 - src[index]
;; R14 - dest[index]

;; Create offset radius*(stride+1) from index to align kernel
mov RAX, R15
add RAX, 1
mul [RBP+018h]

;; Subtract accumulated offset
mov RBX, R9
sub RBX, RAX

;; Calculate ptr to first kernel value in source and store
lea R13, [RSI+RBX]

;; Calculate ptr to dest and store
lea R14, [RDI+R9]

;; END PIXEL

;; Increment x by one
inc R9

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
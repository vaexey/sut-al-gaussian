;; Extern to print stdout
extern __imp_wprintf:qword

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

;; Enter stack frame
push RBP
mov RBP, RSP
sub RSP, 040h

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

;; Store y into RCX with start value = &src + startIndex
mov RCX, [RBP+020h]
add RCX, [RBP+030h]

;; Calc yEnd = (&src + endIndex * stride) and store on stack
mov RAX, [RBP+050h]
mov RDX, [RBP+038h]
mul RDX
add RAX, [RBP+020h]
mov [RBP-060h], RAX

;; Increment y until it reaches yEnd
y_loop:

;; TODO: implement filter func

;; Increment by stride value
add RCX, [RBP+050h]

;; Go back if not reached yEnd yet
cmp RCX, [RBP-060h]
jne y_loop

;; Leave stack frame
leave
ret

filter_uniform endp

end
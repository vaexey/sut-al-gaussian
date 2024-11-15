;; Extern to print stdout
extern __imp_wprintf:qword

.const

MSG_BEGIN DB "filter_uniform begin",0

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

;; Leave stack frame
leave
ret

filter_uniform endp

end
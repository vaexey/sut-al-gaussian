
.const
LIB_ID DB "GAUSSIAN_ASM",0
LIB_ID_LEN DQ 13

.code

;;;;;;;;;;;;;;
;; uint64_t id(uint8_t* dest, uint64_t maxLen)
;;;;;;
;; Stores library ID into dest array of size maxLen
;;;;;;;;;;;;;;;;
id proc

;; Verify whether dest* [maxLen] is big enough to put LIB_ID
cmp RDX, LIB_ID_LEN
jae id_ok
;; If not return -1
mov RAX, -1
ret

;; If LIB_ID fits in specified array:
id_ok:

;; Load src index
lea RSI, LIB_ID

;; Load dest index
mov RDI, RCX

;; Repeat movsb LIB_ID_LEN times
mov RCX, [LIB_ID_LEN]
rep movsb

;; Return 0
mov RAX, 0
ret


;;add RCX, RDX
;;mov RAX, RCX
;;ret

id endp

;;;;;;
;; uint64_t gauss_kernel_size(uint64_t radius)
;;;;;
;; Returns size of gauss kernel based on specified radius
;;;
gauss_kernel_size proc

;; Store radius in RAX
mov RAX, RCX

;; Perform 2*radius
mov RCX, 2
mul RCX

;; Add 1 and return
add RAX, 1
ret

gauss_kernel_size endp

;;;;;
;; void gauss_kernel (uint8_t* kernel, int radius)
;;;;
;; Creates kernel values for a given kernel array of
;; size determined by radius
;;;;;;
gauss_kernel proc

;; TODO: implement variable sizing

mov byte ptr [RCX + 0], 1
mov byte ptr [RCX + 1], 2
mov byte ptr [RCX + 2], 1


mov byte ptr [RCX + 3], 2
mov byte ptr [RCX + 4], 4
mov byte ptr [RCX + 5], 2

mov byte ptr [RCX + 6], 1
mov byte ptr [RCX + 7], 2
mov byte ptr [RCX + 8], 1

ret

gauss_kernel endp

end
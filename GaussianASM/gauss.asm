
.const
LIB_ID DB "GAUSSIAN_ASM",0
LIB_ID_LEN DQ 13

GKERNEL_QUALITY DB 3,4,5,6,7,7,7,6,5,4,3
DB 4,6,7,9,10,11,10,9,7,6,4
DB 5,7,10,12,13,14,13,12,10,7,5
DB 6,9,12,14,16,17,16,14,12,9,6
DB 7,10,13,16,18,19,18,16,13,10,7
DB 7,11,14,17,19,20,19,17,14,11,7
DB 7,10,13,16,18,19,18,16,13,10,7
DB 6,9,12,14,16,17,16,14,12,9,6
DB 5,7,10,12,13,14,13,12,10,7,5
DB 4,6,7,9,10,11,10,9,7,6,4
DB 3,4,5,6,7,7,7,6,5,4,3

.code

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; uint64_t id(uint8_t* dest, uint64_t maxLen)
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Stores library ID into dest array of size maxLen
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
id proc

;; Verify whether dest* [maxLen] is big enough to put LIB_ID
cmp RDX, LIB_ID_LEN
jae id_ok
;; If not return -1
mov RAX, -1
ret

;; If LIB_ID fits in specified array:
id_ok:

;; Save nonvolatile registers
push RSI
push RDI

;; Load src index
lea RSI, LIB_ID

;; Load dest index
mov RDI, RCX

;; Repeat movsb LIB_ID_LEN times
mov RCX, [LIB_ID_LEN]
rep movsb

;; Return 0
mov RAX, 0

;; Restore nonvolatile registers
pop RDI
pop RSI

ret

id endp

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; uint64_t gauss_kernel_size(uint64_t radius)
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Returns size of gauss kernel based on specified radius
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
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

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; void gauss_kernel (uint8_t* kernel, int radius)
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;; Creates kernel values for a given kernel array of
;; size determined by radius
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
gauss_kernel proc

;; Save nonvolatile registers
push RSI
push RDI

;; Clone static hardcoded kernel into array

;; Load src index
lea RSI, GKERNEL_QUALITY

;; Load dest index
mov RDI, RCX

;; Repeat movsb LIB_ID_LEN times
mov RCX, 121
rep movsb

;; Restore nonvolatile registers
pop RDI
pop RSI

ret

gauss_kernel endp

end
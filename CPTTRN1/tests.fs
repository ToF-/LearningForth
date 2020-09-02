require ffl/tst.fs
require cpttrn1.fs

create output-buffer 10000 allot
variable output-length

variable input-buffer 
variable input-length
variable input-index

\ keep track of each char emitted via output
: >output-buffer ( char -- )
    output-buffer output-length @ + c! 
    1 output-length +! ;

\ make this word the new output behavior
' >output-buffer is output

\ do nothing is the new NL behavior
' noop is nl

\ provide the next char received on input
: >input-buffer ( -- char )
    input-index @ dup input-length < if 
        input-buffer @ + c@ 
        1 input-index +!
    else
        drop 4
    then ;

\ make this word the new input behavior
' >input-buffer is input

t{ 
    ." testing the pattern" cr
    \ save that string as inbut buffer
    s" 1 4 4" input-length ! input-buffer ! input-index off
    main
    \ check the output buffer
    output-buffer output-length @ 
    s" *.*..*.**.*..*.*" compare 0 ?s
}t

t{ 
    ." getting a number " cr
    s" 4807" input-length ! input-buffer ! input-index off 
    get-number
    4807 ?s
}t
bye

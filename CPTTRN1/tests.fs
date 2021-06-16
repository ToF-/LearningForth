require ffl/tst.fs
require cpttrn1.fs

create output-buffer 10000 allot
variable output-length

\ keep track of each char emitted via output
: >output-buffer ( char -- )
    output-buffer output-length @ + c! 
    1 output-length +! ;

\ make mock-emit the new behavior
' >output-buffer is output

t{ 
    ." testing the pattern" cr
    4 4 .rows
    output-buffer output-length @ 
    s" *.*..*.**.*..*.*" compare 0 ?s
}t
bye

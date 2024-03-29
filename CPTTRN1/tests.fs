<<<<<<< HEAD
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
=======
REQUIRE ffl/tst.fs
REQUIRE cpttrn1.fs

T{  ." STARDOT returns a . or a * depending on arg is odd or even" CR
    1 STARDOT CHAR . ?S
    2 STARDOT CHAR * ?S
    3 STARDOT CHAR . ?S
}T

T{ ." _EMIT emits a char to the output stream unless redirected " CR 
    CREATE TEMP 10000 ALLOT
    VARIABLE OUTPUT-LENGTH

    : >TEMP ( char )
        TEMP OUTPUT-LENGTH @ + C! 
        1 OUTPUT-LENGTH +! ;

    ' >TEMP IS _EMIT
    OUTPUT-LENGTH OFF
    CHAR ! _EMIT CHAR $ _EMIT CHAR # _EMIT
    S" !$#" TEMP OUTPUT-LENGTH @ COMPARE 0 ?S
}T

T{ ." .ROW displays a row of alternate dots and stars " CR
    ' >TEMP IS _EMIT
    OUTPUT-LENGTH OFF
    0 4 .ROW 
    S" *.*." TEMP OUTPUT-LENGTH @ COMPARE 0 ?S
 }T

T{ ." _CR emits a new line to the output stream unless redirected " CR
    : TEMP-CR 13 _EMIT ;
    
    ' TEMP-CR IS _CR
    0 TEMP C!
    OUTPUT-LENGTH OFF
    _CR TEMP C@ 13 ?S
}T

T{ ." .ROWS emits several rows of alternate dots and stars " CR
    TEMP 10000 ERASE
    OUTPUT-LENGTH OFF
    ' >TEMP IS _EMIT
    ' NOOP IS _CR
    4 4 .ROWS
    S" *.*..*.**.*..*.*" TEMP OUTPUT-LENGTH @ COMPARE 0 ?S
}T

T{ ." _KEY reads a char from the input stream unless redirected " CR
    VARIABLE TEMP-INPUT
    VARIABLE INPUT-LENGTH
    VARIABLE TEMP-INDEX
    : <TEMP ( -- char )
        TEMP-INDEX @ INPUT-LENGTH @ < IF
            TEMP-INPUT @ TEMP-INDEX @ + C@ 
            1 TEMP-INDEX +! 
        ELSE
            4 
        THEN ;

    ' <TEMP IS _KEY
    S" 42" INPUT-LENGTH ! TEMP-INPUT ! TEMP-INDEX OFF
    _KEY CHAR 4 ?S _KEY CHAR 2 ?S
}T

T{ ." SKIP-NON-DIGITS reads chars from the input stream until a digit it read " CR

    S"    42" INPUT-LENGTH ! TEMP-INPUT ! TEMP-INDEX OFF
    SKIP-NON-DIGITS CHAR 4 ?S
}T

T{ ." GET-NUMBER reads a number from the input stream " CR 
    S" 4807" INPUT-LENGTH ! TEMP-INPUT ! TEMP-INDEX OFF
    GET-NUMBER 4807 ?S
}T

T{ ." MAIN reads a number of cases and prints them " CR
    S" 1 2 5" INPUT-LENGTH ! TEMP-INPUT ! TEMP-INDEX OFF
    TEMP 10000 ERASE OUTPUT-LENGTH OFF
    MAIN
    S" *.*.*.*.*." TEMP OUTPUT-LENGTH @ COMPARE 0 ?S
}T
BYE
>>>>>>> 241edc7037f91b6f8bbc19a829f1d5f56bc9897f

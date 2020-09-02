REQUIRE ffl/tst.fs
REQUIRE cpttrn1.fs

T{  ." STARDOT returns a . or a * depending on arg is odd or even" CR
    1 STARDOT CHAR . ?S
    2 STARDOT CHAR * ?S
    3 STARDOT CHAR . ?S
}T

T{ ." _EMIT emits a char to the output stream unless redirected " CR 
    CREATE TEMP 10000 ALLOT
    VARIABLE TEMP-LENGTH

    : >TEMP ( char )
        TEMP TEMP-LENGTH @ + C! 
        1 TEMP-LENGTH +! ;

    ' >TEMP IS _EMIT
    TEMP-LENGTH OFF
    CHAR ! _EMIT CHAR $ _EMIT CHAR # _EMIT
    S" !$#" TEMP TEMP-LENGTH @ COMPARE 0 ?S
}T

T{ ." .ROW displays a row of alternate dots and stars " CR
    ' >TEMP IS _EMIT
    TEMP-LENGTH OFF
    0 4 .ROW 
    S" *.*." TEMP TEMP-LENGTH @ COMPARE 0 ?S
 }T

T{ ." _CR emits a new line to the output stream unless redirected " CR
    : TEMP-CR 13 _EMIT ;
    
    ' TEMP-CR IS _CR
    0 TEMP C!
    TEMP-LENGTH OFF
    _CR TEMP C@ 13 ?S
}T
BYE
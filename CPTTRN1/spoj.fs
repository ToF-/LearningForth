: STARDOT ( n -- char )
    1 AND IF [CHAR] . ELSE [CHAR] * THEN ;

DEFER _EMIT  ' EMIT IS _EMIT

: .ROW ( counter,cols -- )
    0 DO DUP STARDOT _EMIT 1+ LOOP DROP ;

DEFER _CR   ' CR IS _CR

: .ROWS ( cols,rows -- )
    0 DO I OVER .ROW _CR LOOP DROP ;

DEFER _KEY  ' KEY IS _KEY

: IS-DIGIT? ( char -- flag )
    DUP [CHAR] 0 >= SWAP [CHAR] 9 <= AND ;

: SKIP-NON-DIGITS ( -- char ) 
    BEGIN _KEY DUP IS-DIGIT? 0= WHILE DROP REPEAT ;

: GET-NUMBER ( -- n )
    SKIP-NON-DIGITS
    0 SWAP
    BEGIN
        DUP IS-DIGIT? WHILE
        [CHAR] 0 - SWAP 10 * +
        _KEY
    REPEAT DROP ;

: MAIN 
    GET-NUMBER
    0 DO  GET-NUMBER GET-NUMBER SWAP .ROWS _CR LOOP ;
MAIN BYE


: IS-DIGIT? ( c -- f )
    DUP  [CHAR] 0 >= 
    SWAP [CHAR] 9 <= AND ;
    
: GOBBLE 
    BEGIN
        KEY DUP IS-DIGIT? 0= WHILE
        DROP
    REPEAT ;

: GET-NUMBER ( -- n )
    GOBBLE 
    0 SWAP
    BEGIN
        SWAP 10 * 
        [CHAR] 0 - +
        KEY DUP
    IS-DIGIT? 0= UNTIL 
    DROP ;

: .PATTERN ( n -- c )
    IF [CHAR] * ELSE [CHAR] . THEN EMIT ;

: .CB-LINE ( n,l -- )
    SWAP 1 AND SWAP
    0 DO
        0= DUP .PATTERN
    LOOP CR DROP ;

: .CB-LINES ( m,n -- )
    SWAP 0         \ n,m,0
    DO             \ n
        I OVER     \ n,i,n
        .CB-LINE   \ n
    LOOP DROP ;

: MAIN
    GET-NUMBER
    0 DO
        GET-NUMBER
        GET-NUMBER
        .CB-LINES CR
    LOOP ;

MAIN BYE

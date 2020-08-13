CHAR 0 CONSTANT ZERO
CHAR 9 CONSTANT NINE
CHAR - CONSTANT DASH

: IS-DIGIT? ( c -- f )
    DUP  ZERO >=
    SWAP NINE <= AND ;

: IS-MINUS? ( c -- f )
    DASH = ;

: SKIP-NON-NUMERIC ( -- s,c )
    1
    BEGIN
        KEY 
        DUP IS-MINUS? 
        IF 
            SWAP NEGATE SWAP 0
        ELSE
            DUP IS-DIGIT? 
        THEN
        0= WHILE
        DROP
    REPEAT ;

: CHAR>DIGIT ( c -- n )
    ZERO - ;

: DIGIT>ACCUM ( a,d -- a*10+d )
    SWAP 10 * + ;

: GET-NUMBER ( -- n )
    SKIP-NON-NUMERIC 
    0 SWAP           
    BEGIN
        CHAR>DIGIT DIGIT>ACCUM
        KEY DUP IS-DIGIT?  
    0= UNTIL 
    DROP * ;     

: MAIN
    GET-NUMBER 0 DO GET-NUMBER . CR LOOP ;

MAIN BYE

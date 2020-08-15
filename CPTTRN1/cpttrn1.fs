: STARDOT  ( n -- char )
    1 AND IF [CHAR] . ELSE [CHAR] * THEN ;
    
: .ROW  ( c,n )
    0 DO DUP STARDOT EMIT 1+ LOOP 
    DROP CR ;
        
: .ROWS ( #cols,#rows -- )
    0 DO I OVER .ROW LOOP 
    DROP CR ;

: TO-DIGIT ( char -- n )
    [CHAR] 0 - ;

: IS-DIGIT? ( char -- flag )
    TO-DIGIT DUP 0 >= SWAP 9 <= AND ;     

: SKIP-NON-DIGIT ( -- char )
    BEGIN
        KEY DUP IS-DIGIT? 0= WHILE
        DROP
    REPEAT ;

: GET-NUMBER ( -- n )
    SKIP-NON-DIGIT  
    0 SWAP          \ accumulator
    BEGIN
        TO-DIGIT SWAP 10 * + 
        KEY DUP IS-DIGIT? 
    0= UNTIL DROP ;

: MAIN
    GET-NUMBER 0 DO
        GET-NUMBER GET-NUMBER
        SWAP .ROWS
    LOOP ;

MAIN BYE

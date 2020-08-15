3 CONSTANT SIZE

: INSIDE? ( limit,index -- 0|x )
    SWAP 1- OVER - * 0> ;

: DOT? ( limit,index -- flag )
    DUP SIZE MOD -ROT INSIDE? AND ;

: STARDOT  ( limit,index -- char )
    DOT? IF [CHAR] . ELSE [CHAR] * THEN ;

: .STAR-ROW ( #cols -- )
    0 DO [CHAR] * EMIT LOOP CR ;

: .STARDOT-ROW  ( #cols -- )
    0 DO 2R@ STARDOT EMIT LOOP CR ;
        
: .ROW ( #cols,limit,index -- )
    DOT?  IF .STARDOT-ROW ELSE .STAR-ROW THEN ;
    
: .ROWS ( #cols,#rows -- )
    0 DO DUP 2R@ .ROW LOOP 
    DROP CR ;  

: EXPAND ( n -- size )
    SIZE * 1+ ;

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
        EXPAND SWAP EXPAND
        .ROWS
    LOOP ;

MAIN BYE


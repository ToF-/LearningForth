: INSIDE? ( limit,index -- 0|x )
    SWAP 1- OVER - * ;

: STARDOT  ( index,limit -- char )
    INSIDE? IF [CHAR] . ELSE [CHAR] * THEN ;

: .STAR-ROW ( #cols -- )
    0 DO [CHAR] * EMIT LOOP CR ;

: .STARDOT-ROW  ( #cols -- )
    0 DO 2R@ STARDOT EMIT LOOP CR ;
        
: .ROW ( #cols,index,limit -- )
    INSIDE? IF .STARDOT-ROW ELSE .STAR-ROW THEN ;
    
: .ROWS ( #cols,#rows -- )
    0 DO DUP 2R@ .ROW LOOP 
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

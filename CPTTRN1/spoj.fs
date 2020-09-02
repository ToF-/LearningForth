VARIABLE DEBUG 
DEBUG OFF

\ make output indirect so that we can test the output
DEFER OUTPUT 

\ make emit the default behavior
' EMIT IS OUTPUT

\ make input indirect so that we can test the output
DEFER INPUT 

\ make key the default behavior
' KEY IS INPUT

: STARDOT  ( n -- char )
    1 AND IF [CHAR] . ELSE [CHAR] * THEN ;
    
: .ROW  ( c,n )
    0 DO DUP STARDOT OUTPUT 1+ LOOP 
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
        INPUT DUP IS-DIGIT? 0= WHILE
        DROP
    REPEAT ;

: GET-NUMBER ( -- n )
    SKIP-NON-DIGIT  
    0 SWAP          \ accumulator
    BEGIN
        TO-DIGIT SWAP 10 * + 
        INPUT DUP IS-DIGIT? 
    0= UNTIL DROP ;

: MAIN
    GET-NUMBER 0 DO
        GET-NUMBER GET-NUMBER
        SWAP .ROWS
    LOOP ;

main bye

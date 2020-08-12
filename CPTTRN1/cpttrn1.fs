CHAR . CONSTANT DOT
CHAR * CONSTANT STAR

\ put a star if n is even, else a dot 
: DOT-OR-CHAR ( n -- c )
    1 AND IF DOT ELSE STAR THEN ;
    
\ print the character depending on n
: .DOT-OR-CHAR ( n -- )
    DOT-OR-CHAR EMIT ;

\ print a row of n stars, with initial counter
: .ROW  ( c,n )
    0 DO
        DUP .DOT-OR-CHAR 1+
    LOOP 
    DROP CR ;
        
    
\ print n rows of m star or dot
: .ROWS ( n,m -- )
    SWAP          \ m,n        outer loop max on top
    0 DO          \ m
        I OVER    \ m,c,m      counter = I, keep m for several loops
        .ROW
    LOOP 
    DROP CR ;

: IS-DIGIT? ( c -- f )
    DUP  [CHAR] 0 >=
    SWAP [CHAR] 9 <= AND ;

: SKIP-NON-DIGIT ( -- c )
    BEGIN
        KEY DUP IS-DIGIT? 0= WHILE
        DROP
    REPEAT ;

: GET-NUMBER ( -- n )
    SKIP-NON-DIGIT  \ c
    0 SWAP          \ a,c     put the accumulator
    BEGIN
        [CHAR] 0 -  \ a,d     digit value
        SWAP 10 * + \ a       accumulate
        KEY         \ a,c
        DUP IS-DIGIT?  \ a,c,f
    0= UNTIL DROP ;

        

: MAIN
    GET-NUMBER
    0 DO
        GET-NUMBER
        GET-NUMBER
        .ROWS
    LOOP ;

MAIN BYE

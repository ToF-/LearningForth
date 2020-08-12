CHAR . CONSTANT DOT
CHAR * CONSTANT STAR

\ true if 0 < i < m-1
: INSIDE? ( m,i -- f )
    SWAP 1- OVER - * ;

\ print a star if i is 0 or m-1 else a dot 
: .DOT-OR-CHAR ( m,i -- c )
    INSIDE? IF DOT ELSE STAR THEN EMIT ;
    
\ print a row of n dots with star at the border
: .DOTS  ( n -- )
    0 DO 2R@ .DOT-OR-CHAR LOOP CR ;

\ print a row of stars
: .STARS ( m -- ) 
    0 DO STAR EMIT LOOP CR ;        

\ print a border row of size m, stars if i = 0 or n-1
: .ROW ( m,n,i -- )
    INSIDE? IF .DOTS ELSE .STARS THEN ;
    
\ print n rows of dots with a border of stars
: .ROWS ( n,m -- )
    SWAP            \ m,n        outer loop max on top 
    0 DO DUP 2R@ .ROW LOOP 
    DROP CR ;  

\ true if the given char is between '0' and '9'
: IS-DIGIT? ( c -- f )
    DUP  [CHAR] 0 >=
    SWAP [CHAR] 9 <= AND ;

\ read input until first digit char, return it
: SKIP-NON-DIGIT ( -- c )
    BEGIN
        KEY DUP IS-DIGIT? 0= WHILE
        DROP
    REPEAT ;

\ read input until a number is read, return it
: GET-NUMBER ( -- n )
    SKIP-NON-DIGIT  \ c
    0 SWAP          \ a,c     put the accumulator
    BEGIN
        [CHAR] 0 -  \ a,d     digit value
        SWAP 10 * + \ a       accumulate
        KEY         \ a,c
        DUP IS-DIGIT?  \ a,c,f
    0= UNTIL DROP ;

\ read the numbers, print the patterns
: MAIN
    GET-NUMBER
    0 DO
        GET-NUMBER
        GET-NUMBER
        .ROWS
    LOOP ;

\ MAIN BYE

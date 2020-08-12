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

3 1 .ROWS
4 4 .ROWS
2 5 .ROWS

BYE

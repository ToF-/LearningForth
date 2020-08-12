CHAR . CONSTANT DOT
CHAR * CONSTANT STAR

\ put a star if n is even, else a dot 
: DOT-OR-CHAR ( n -- c )
    1 AND IF DOT ELSE CHAR THEN ;
    
\ print the character depending on n
: .DOT-OR-CHAR ( n -- )
    DOT-OR-CHAR EMIT ;

\ print n rows of 1 star or dot
: .ROWS ( n -- )
    0 SWAP
    0 DO
        DUP .DOT-OR-CHAR CR
        1+
    LOOP 
    DROP ;

3 .ROWS
BYE

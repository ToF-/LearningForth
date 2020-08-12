CHAR . CONSTANT DOT
CHAR * CONSTANT STAR

\ put a star if n is even, else a dot 
: DOT-OR-CHAR ( n -- c )
    1 AND IF DOT ELSE CHAR THEN ;
    
\ print the character depending on n
: .DOT-OR-CHAR ( n -- )
    DOT-OR-CHAR EMIT ;

0 .DOT-OR-CHAR CR
1 .DOT-OR-CHAR CR
2 .DOT-OR-CHAR CR

BYE

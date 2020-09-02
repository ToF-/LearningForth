\ make output indirect, with default behavior as EMIT
DEFER OUTPUT ' EMIT IS OUTPUT

\ make NL indirect with default behavior as CR
DEFER NL ' CR IS NL

\ make input indirect, with default behavior as KEY
DEFER INPUT  ' KEY IS INPUT

: STARDOT  ( n -- char )
    1 AND IF [CHAR] . ELSE [CHAR] * THEN ;
    
: .ROW  ( c,n ) 0 DO DUP STARDOT OUTPUT 1+ LOOP DROP NL ;
        
: .ROWS ( #cols,#rows -- ) 0 DO I OVER .ROW LOOP DROP NL ;

: TO-DIGIT ( char -- n ) [CHAR] 0 - ;

: IS-DIGIT? ( char -- flag ) TO-DIGIT DUP 0 >= SWAP 9 <= AND ;     

: SKIP-NON-DIGIT ( -- char ) BEGIN INPUT DUP IS-DIGIT? 0= WHILE DROP REPEAT ;

: GET-NUMBER ( -- n )
    SKIP-NON-DIGIT  0 SWAP          \ accumulator
    BEGIN
        TO-DIGIT SWAP 10 * + 
        INPUT DUP IS-DIGIT? 
    0= UNTIL DROP ;

: MAIN
    GET-NUMBER 0 DO
        GET-NUMBER GET-NUMBER
        SWAP .ROWS
    LOOP ;


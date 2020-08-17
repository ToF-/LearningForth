VARIABLE SIZE

: RELATIVE ( n -- n%s )
    SIZE @ MOD ;

: OPPOSITE ( n -- s-n%s )
    SIZE @ 1- SWAP RELATIVE - ;

: NORTH-WEST ( row,col -- n )
    RELATIVE SWAP OPPOSITE - ;

: NORTH-EAST ( row,col -- n )
    OPPOSITE SWAP OPPOSITE - ;

: SOUTH-WEST ( row,col -- n )
    RELATIVE SWAP RELATIVE - ;

: SOUTH-EAST ( row,col -- n )
    OPPOSITE SWAP RELATIVE - ;

CREATE ZONES ' NORTH-WEST , ' NORTH-EAST , ' SOUTH-WEST , ' SOUTH-EAST ,
47 CONSTANT SLASH 
92 CONSTANT BACKSLASH
CREATE DIAGS SLASH C, BACKSLASH C, BACKSLASH C, SLASH C,

: WHICH-ZONE ( row,col -- NW|NE|SW|SE )
    SIZE @ / 1 AND SWAP 
    SIZE @ / 1 AND 2* OR ; 

: PATTERN-VALUE ( row,col -- value)
    OVER OVER WHICH-ZONE
    CELLS ZONES + @ EXECUTE ;

: DIAGONAL ( row,col -- char )
    WHICH-ZONE 
    DIAGS + C@ ;

: AREA ( v -- char )
    0> IF [CHAR] * ELSE [CHAR] . THEN ;

: PATTERN ( row,col -- char )
    OVER OVER PATTERN-VALUE 
    ?DUP 0= IF DIAGONAL ELSE -ROT DROP DROP AREA THEN ;

: .ROW ( row,limit -- )
    0 DO DUP I PATTERN EMIT LOOP DROP ;

: .ROWS ( #cols,#rows -- )
    0 DO I OVER .ROW CR LOOP DROP ;

: EXPAND ( inner-size -- size )
    SIZE @ 2* * ;

: TO-DIGIT ( char -- n )
    [CHAR] 0 - ;

: IS-DIGIT? ( char -- flag )
    TO-DIGIT DUP 0 >= SWAP 9 <= AND ;     

: SKIP-NON-DIGIT ( -- char )
    BEGIN KEY DUP IS-DIGIT? 0= WHILE DROP REPEAT ;

: GET-NUMBER ( -- n )
    SKIP-NON-DIGIT  
    0 SWAP          \ accumulator
    BEGIN
        TO-DIGIT SWAP 10 * + 
        KEY DUP IS-DIGIT? 
    0= UNTIL DROP ;

: .VALUES ( #rows,#cols -- )
    SWAP 0 DO DUP 0 DO J I DIAGONAL 4 .R LOOP CR CR LOOP ; 

: MAIN
    GET-NUMBER 0 DO
        GET-NUMBER GET-NUMBER 
        GET-NUMBER SIZE !
        EXPAND SWAP EXPAND
        .ROWS CR
    LOOP ;

MAIN BYE


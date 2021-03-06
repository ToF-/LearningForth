VARIABLE SIZE

: REL-COORD ( n -- n%s )
    SIZE @ MOD ;

: OPP-COORD ( n -- s-n%s )
    SIZE @ 1- SWAP REL-COORD - ;

: UP? ( row,col -- flag )
    SIZE @ TUCK / 2 MOD -ROT / 2 MOD = ;

: DIAGONAL? ( row,col -- char,flag )
    OVER OVER UP?
    IF   REL-COORD SWAP OPP-COORD = [CHAR] /
    ELSE REL-COORD SWAP REL-COORD = [CHAR] \
    THEN SWAP ;
    
: PATTERN ( row,col -- char )
    DIAGONAL? 0= IF DROP [CHAR] . THEN ;

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

: MAIN
    GET-NUMBER 0 DO
        GET-NUMBER GET-NUMBER 
        GET-NUMBER SIZE !
        EXPAND SWAP EXPAND
        .ROWS CR
    LOOP ;

MAIN BYE


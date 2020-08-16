VARIABLE V-SIZE
VARIABLE H-SIZE
CREATE PATTERNS CHAR . C, CHAR | C, CHAR - C, CHAR + C,
1 CONSTANT V-MASK 
2 CONSTANT H-MASK

: PATTERN-MASK ( n,mask,size -- flag )
    ROT 1+ SWAP MOD 0= AND ;

: PATTERN ( row,col -- char )
    V-MASK H-SIZE @ PATTERN-MASK >R
    H-MASK V-SIZE @ PATTERN-MASK R>
    OR PATTERNS + C@ ;

: .ROW ( row,limit -- )
    0 DO DUP I PATTERN EMIT LOOP DROP ;

: .ROWS ( #cols,#rows -- )
    0 DO I OVER .ROW CR LOOP DROP ;

: EXPAND ( n,size -- size )
    SWAP 1+ * 1- ;

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
        GET-NUMBER 1+ V-SIZE !
        GET-NUMBER 1+ H-SIZE !
        H-SIZE @ EXPAND SWAP 
        V-SIZE @ EXPAND 
        .ROWS CR
    LOOP ;

MAIN BYE


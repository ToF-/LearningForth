: STARDOT ( n -- char )
    1 AND IF [CHAR] . ELSE [CHAR] * THEN ;

DEFER _EMIT  ' EMIT IS _EMIT

: .ROW ( counter,cols -- )
    0 DO DUP STARDOT _EMIT 1+ LOOP DROP ;

DEFER _CR   ' CR IS _CR

: .ROWS ( cols,rows -- )
    0 DO I OVER .ROW _CR LOOP DROP ;

DEFER _KEY  ' KEY IS _KEY

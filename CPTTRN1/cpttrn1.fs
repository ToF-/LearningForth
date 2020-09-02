: STARDOT ( n -- char )
    1 AND IF [CHAR] . ELSE [CHAR] * THEN ;

DEFER _EMIT  ' EMIT IS _EMIT

: .ROW ( counter,cols -- )
    0 DO DUP STARDOT _EMIT 1+ LOOP DROP ;

DEFER _CR   ' CR IS _CR
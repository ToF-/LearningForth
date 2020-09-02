REQUIRE ffl/tst.fs
REQUIRE cpttrn1.fs

T{  ." STARDOT returns a . or a * depending on arg is odd or even" CR
    1 STARDOT CHAR . ?S
    2 STARDOT CHAR * ?S
    3 STARDOT CHAR . ?S
}T
BYE
test : spoj.fs test.txt
	sed -n -e 's/\(<- \)\(.*\)/\2/pw input.dat'    test.txt >/dev/null
	sed -n -e 's/\(-> \)\(.*\)/\2/pw expected.dat' test.txt >/dev/null
	gforth spoj.fs <input.dat >output.dat
	diff expected.dat output.dat

unit : cpttrn1.fs tests.fs
	gforth-itc tests.fs

spoj : cpttrn1.fs
	echo "MAIN BYE" >main.fs
	cat cpttrn1.fs main.fs >spoj.fs
	
clean : 
	rm *.dat

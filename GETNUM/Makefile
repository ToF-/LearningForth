test : getnum.fs test.txt
	sed -n -e 's/\(<- \)\(.*\)/\2/pw input.dat'    test.txt >/dev/null
	sed -n -e 's/\(-> \)\(.*\)/\2/pw expected.dat' test.txt >/dev/null
	gforth getnum.fs <input.dat >output.dat
	diff expected.dat output.dat

clean : 
	rm *.dat

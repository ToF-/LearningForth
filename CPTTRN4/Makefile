test : cpttrn4.fs test.txt
	sed -n -e 's/\(<- \)\(.*\)/\2/pw input.dat'    test.txt >/dev/null
	sed -n -e 's/\(-> \)\(.*\)/\2/pw expected.dat' test.txt >/dev/null
	gforth cpttrn4.fs <input.dat >output.dat
	diff expected.dat output.dat

clean : 
	rm *.dat

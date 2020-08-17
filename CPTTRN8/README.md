https://www.spoj.com/problems/CPTTRN8/

    echo "2 4 4 4   2 2 2" >large.dat
    gforth cpttrn8.fs <large.dat
    
    .../\....../\....../\....../\...
    ../**\..../**\..../**\..../**\..
    ./****\../****\../****\../****\.
    /******\/******\/******\/******\
    \******/\******/\******/\******/
    .\****/..\****/..\****/..\****/.
    ..\**/....\**/....\**/....\**/..
    ...\/......\/......\/......\/...
    .../\....../\....../\....../\...
    ../**\..../**\..../**\..../**\..
    ./****\../****\../****\../****\.
    /******\/******\/******\/******\
    \******/\******/\******/\******/
    .\****/..\****/..\****/..\****/.
    ..\**/....\**/....\**/....\**/..
    ...\/......\/......\/......\/...
    .../\....../\....../\....../\...
    ../**\..../**\..../**\..../**\..
    ./****\../****\../****\../****\.
    /******\/******\/******\/******\
    \******/\******/\******/\******/
    .\****/..\****/..\****/..\****/.
    ..\**/....\**/....\**/....\**/..
    ...\/......\/......\/......\/...
    .../\....../\....../\....../\...
    ../**\..../**\..../**\..../**\..
    ./****\../****\../****\../****\.
    /******\/******\/******\/******\
    \******/\******/\******/\******/
    .\****/..\****/..\****/..\****/.
    ..\**/....\**/....\**/....\**/..
    ...\/......\/......\/......\/...
    
    ./\../\.
    /**\/**\
    \**/\**/
    .\/..\/.
    ./\../\.
    /**\/**\
    \**/\**/
    .\/..\/.

Important parameter: the *size* of the diamond. Here's a diamond of size 4:

         01234567
    
       0 .../\...
       1 ../**\..
       2 ./****\.
       3 /******\
       4 \******/
       5 .\****/.
       6 ..\**/..
       7 ...\/...

Determining what character to print at any point (*row*,*col*) is a matter of finding in which zone (*NW*,*NE*,*SW*,*SE*) of an invidual diamond the point is located: *(row/size)%2 + (col/size)%2*.

         01234567
    
       0 00001111
       1 00001111
       2 00001111
       3 00001111
       4 22223333
       5 22223333
       6 22223333
       7 22223333

The point (*row*,*col*) being outside, on the diagonal, or inside the diamond is determined by the relationship between row and col, depending on the zone:

- *NW* : *(col % size) - (size - ((row % size) + 1)*
- *NE* : *(size - ((col % size) + 1)) - (size - ((row % size) + 1))*
- *SW* : *(col % size) - (row % size)*
- *SE* : *(size - ((col % size) + 1)) - (row % size)*


           0  1  2  3  4  5  6  7
    
       0  -3 -2 -1  0  0 -3 -2 -1  
       1  -2 -1  0  1  1  0 -1 -2
       2  -1  0  1  2  2  1  0 -1
       3   0  1  2  3  1  2  3  0
       4   0  1  2  3  3  2  1  0
       5  -1  0  1  2  2  1  0 -1
       6  -2 -1  0  1  1  0 -1 -2
       7  -3 -2 -1  0  0 -1 -2 -3

The direction for a point on the diagonal depends on which zone the point is located:

- *NW* : / 
- *NE* : \
- *SW* : /
- *SE* : \

Thus for each point (*row*,*col*):

- find the relative zone for the point
- compute the pattern value given the zone
- if the point is on a diagonal, compute the diagonal direction
- print the point


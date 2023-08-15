Unfortunately, we cannot simply add a try-catch code block
and wrap the entire method in it because we cannot use the yield return keywords in
such a code block. 


C# provides us with a keyword and compilation mode that can somewhat prevent
unexpected overflows and underflows: checked. By default, C# compiles in
unchecked mode. This means that the CLR does not throw any exceptions on arith-
metic overflow and underflow. This is fine for most use cases, because we have
some additional overhead with checking for this possibility, and it is not a common
occurrence in a lot of programs. But, if we use checked mode, the CLR throws an
exception when it detects under- or overflow. To use checked mode, we can either
compile the entire codebase with these checks in place, by adding the -checked
compiler option to the build instructions, or we can use the checked keyword.
To have the CLR throw an exception when it sees under- or overflow in a specific code
block, we can wrap code in a checked block as follows:
checked {
int maxVal = 0b_11111111_11111111_11111111_1111111;
int oneVal = 0b_00000000_00000000_00000000_0000001;
int overflow = maxVal + oneVal;
}
Now, when we add the maxVal and oneVal variables, the CLR throws an Overflow-
Exception! Consequently, if you compiled the entire codebase in checked mode,
you can use the unchecked code block to tell the CLR not to throw any Overflow-
Exceptions for that block’s scope.



We can only set readonly values at their declaration or in a constructor.
Because we can set a readonly value only once, and declaring a field means the
compiler automatically assigns a default value to its spot in memory, we need to
set it at the earliest possible moment. A readonly field can greatly reduce the
amount of data manipulation others can do on our code.



By using an IAsyncEnumerable<T> along with the yield return keywords, we
can create code that asynchronously awaits on data and processes it as it
receives the data. This is very helpful when dealing with external interactions
such as database queries.




By default, C# code is compiled using unchecked mode. This means the CLR
does not throw an OverflowException if it encounters an overflow or under-
flow. Similarly, checked mode means the CLR does throw such an exception.



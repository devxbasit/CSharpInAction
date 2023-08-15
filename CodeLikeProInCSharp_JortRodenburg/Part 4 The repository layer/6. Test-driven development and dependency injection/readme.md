The power of dependency injec-
tion is that it inverts the control of the dependency. Instead of the class having control
of the dependency and how it is instantiated, now the calling class has this control.
This is what we mean by “inversion of control.”

 I like using the following template for my test names: {METHOD NAME}
_{EXPECTED OUTCOME}. It uses snake casing to separate the method under
test from the result: CreateCustomer_Success.

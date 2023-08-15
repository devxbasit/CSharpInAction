The .NET garbage collector scans the code during run time for objects that no lon-
ger have any “links” to them. These links can be things like method calls or variable
assignments. To do this, it uses so-called generations.


Calling Dispose on a resource implementing IDisposable does not
cause an immediate garbage collection to happen. We are merely flagging it
safe for collecting and requesting for it to happen at the next opportunity to
do so. No impromptu garbage collection is initiated, but we take the manage-
ment of when the resource is determined safe for collection into our own
hands as opposed to letting the garbage collector decide.


 For constructors, there is also the static con-
structor. Because we are dealing with static, there can be only one static constructor,
and, therefore, it cannot be overloaded. When instantiating a class or calling a static
member on a class, a static constructor is always called before instantiation or static
member access. We can have static constructors and regular constructors, but the
runtime always calls the static (once) before the very first regular constructor you
use. Consequently, a static constructor is always parameter less, and static con-
structors do not contain access modifiers (a static constructor is always public).
For the Java programmers out there, note that Java’s anonymous static initialization
block is equivalent to a static constructor in C#. C# can have only one static construc-
tor, however, whereas Java can have multiple anonymous static initialization blocks.



write code as a narrative.



 the DRY principle to mean that “Every piece of knowledge must
have a single, unambiguous, authoritative representation within a system (27).” In
practical terms, this often means that you write the same code only once. In other
words: don’t duplicate code.


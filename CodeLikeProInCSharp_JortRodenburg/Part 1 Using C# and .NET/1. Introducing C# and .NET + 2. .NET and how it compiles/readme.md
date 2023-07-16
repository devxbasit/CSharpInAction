There is a difference between knowing the syntax of a language and being able to write clean, idiomatic (using, containing, or denoting expressions that are natural to a native speaker) code.

Open/Closed Principle
In 1988, the French computer scientist Bertrand Meyer (creator of the Eiffel program- ming language) released a book called Object-Oriented Software Construction (Prentice Hall, 1988). The release of Meyer’s book was a pivotal moment in the history of object oriented programming and design, because in it, he introduced the Open/Closed Principle (OCP). The OCP is aimed at improving the maintainability and flexibility of software designs. Meyer says the OCP means that “software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification.” But what does the OCP mean in practical terms? To examine that, let’s apply the OCP to a class: we deem a class “open” for extension and “closed” to modification if we can add functionality to the class without changing the existing functionality (and, therefore, potentially breaking parts of our code). If you abide by that rule, the odds of you introducing a regression (or new bug) in the existing code are much smaller than if you try to force in the bug fix or new feature with no regard for maintainability and extensibility. When you work with code that is more complicated (and coupled; discussed in chapter 8), you are more likely to introduce new bugs due to misunderstanding the side effects of your changes. This is what we want to avoid at all costs.

CIL - Common Intermediate Language
CRL - Common Language Infrastructure

Self-documenting code means code that is written clearly enough that we need no comments to explain the logic. The code documents itself. For example, if you have a method called DownloadDocument, others can have some inkling of what it does. There is no need to add a comment saying that the logic inside the method downloads a document.

Languages within the confines of .NET use a two-step compilation process. First, code is compiled statically to a lower-level language called Common Intermediate Language (CIL, IL, or MSIL for short; MS for Microsoft—it is somewhat similar to Java bytecode, for the Java developers among us), which in turn compiles just-in-time (JIT) to native code when the .NET runtime executes the code on the host.

At the end of the day, why bother writing clean code? Clean code works like a wash ing machine for bugs and incorrect functionality. If we put our codebase in the clean code washing machine, as shown in figure 1.3, we see that once you refactor some thing to be more “clean,” bugs come out and incorrect functionality stares at you with no place to hide. After all, “it all comes out in the wash.” Of course, it is also risky to refactor production code; often unintended side effects are introduced. This makes it difficult for management to approve big refactors without added functionality. How ever, with the right tools (some of which are discussed in this book), you can minimize the chances of negative side effects and improve the quality of the codebase. 

The two most important pillars of the .NET Framework are the Framework Class Library (FCL; a humongous class library that is the backbone of the .NET Framework) and the Common Language Runtime (CLR; the runtime environment of .NET that contains the JIT compiler, garbage collector, primitive data types, and more). In other words, the FCL contains all the libraries you are likely to use, and the CLR executes the code

Just In Time Compilation, JIT, or Dynamic Translation, is compilation that is being done during the execution of a program. Meaning, at run time, as opposed to prior to execution. What happens is the translation to machine code. The advantages of a JIT are due to the fact, that since the compilation takes place in run time, a JIT compiler has access to dynamic runtime information enabling it to make better optimizations

What is important to understand about the JIT compilation, is that it will compile the bytecode into machine code instructions of the running machine. Meaning, that the resulting machine code is optimized for the running machine’s CPU architecture.

The C# compilation process knows three states (C#, Intermediate Language, and native code).

Managed code is the code which is managed by the CLR(Common Language Runtime) in .NET Framework. Whereas the un-managed code is the code which is directly executed by the operating system

.NET uses a combination of static and JIT (“just-in-time”) compilation. This allows for faster execution when compared to a fully JIT language and cross platform execution.

The C# compilation process has three states of being: (1) C# code, (2) Intermediate Language code, and (3) native code.

The C# compilation process has two steps: C# to Intermediate Language (static compilation) and Intermediate Language to native code (JIT compilation).

Intermediate Language is stored in portable executable files (such as .exe and .dll on Windows). The CLR scans these files for the embedded IL and executes it, JIT compiling it to the appropriate native code.

The Common Language Runtime is invoked on the launch of a .NET application and JIT compiles the Intermediate Language code to native code.

The Common Language Infrastructure is a technical standard that provides a base for all languages targeting .NET. This allows us to use languages such as F# and VB.NET along with C#.
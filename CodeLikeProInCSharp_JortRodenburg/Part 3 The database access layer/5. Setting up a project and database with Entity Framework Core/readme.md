 An environment variable is a key-value pair, {K, V }, which we set at
the operating system level. We can retrieve environment variables at run time, making
them excellent for providing variables that either change per system or deployment or
values that we do not want hardcoded in our codebase



The single-responsibility principle
One of the clean code tenets identified by Robert Martin, the single-responsibility
principle (SRP) is the harmonica of clean code: easy to play, but mastery takes years
of practice. The SRP builds on the concept of “separation of concerns” as evange-
lized (and coined) by Edsger Dijkstra in his paper “On the Role of Scientific Thought.”a
In practice, the SRP means that a method should do only one thing and do that well.
This goes back to the monster methods we discussed earlier in the book. More for-
mally, according to Martin in a blog post published in 2014 (https://blog.cleancoder
.com/uncle-bob/2014/05/08/SingleReponsibilityPrinciple.html), the SRP states that
“each software module should have one and only one reason to change.”
Going back to practical terms, how do you know whether you violated the SRP? The
easiest way I have found is to ask yourself if you are doing more than one thing in
the method. If you need to use the word “and” in either your explanation of the
method or in the method name, that usually means you are violating the SRP. The
SRP is closely tied to the Liskov principle, which I discuss in chapter 8.



Using test-driven development (TDD) to implement your code sets you apart from a
lot of developers. Your code will be more robust and better tested than that of your
peers who don’t use TDD. If you have never used TDD, I’ll guide you through the pro-
cess of actually using TDD practically. Test-driven development is, at its most funda-
mental level, the practice of writing unit tests before writing the code that implements
what you are trying to test. You update your tests and code in tandem and build them
up simultaneously, which promotes good design and solid code because the feedback
loop is tight and you are acutely aware of any code that breaks your tests.


Doing more than one thing in a method violates the
single-responsibility principle. 


Our code should be self-documenting. Somebody unfamiliar with the logic should
be able to read the code and understand, in broad strokes, what is going on. We
should delete the comment.
Using hardcoded SQL statements is a potential stumbling block for maintain-
ing a service. If the database schema changes, we now need to change the SQL
query as well. It is safer to use an ORM tool, like Entity Framework Core, to
abstract away the SQL query.


You can assign the default value for any type explicitly by using the
default keyword instead of a value. 

 we also should
make sure that nobody can inherit from our Customer object and consequently use
polymorphism to add that to the database. So, we also seal our class by using the
sealed keyword. 


Reflection
Reflection is a powerful technique in C# used to access information at run time about
assemblies, types, and modules. In practice, this means that you can find out what the
type is of an object or change some of its properties while executing your code. You
can use reflection for much more than that, however. The opportunities are surprising.
For example, you can use reflection to create custom method attributes, create new
types, or invoke code in a file you don’t know the name of yet, all at runtime. You can
even access private fields from outside classes (but please do not do that; respect
the developers’ access guidance).
As you can imagine, reflection is not the cheapest thing to execute in terms of mem-
ory and CPU cycles. To perform some of its operations, it has to load in and keep
track of a lot of metadata in memory. Imagine the amounts of processing needed to
detect the type of an unknown object at run time. Libraries and frameworks often
cannot make assumptions about the type of objects they operate on, so they use
reflection to gather metadata and make decisions based on that data.
Before using reflection, reflect on your use case.


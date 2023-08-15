
Test Driven Development - TTD 
Red -> Green -> Refactor stage




Stubbing, within the context of unit testing, is the act of executing a stub class (a class that acts as a cer-
tain class but overrides implementations) instead of the original class.


A stub is very helpful when we want to execute different code than what the origi-
nal class does. For example, the context.SaveChangesAsync method saves the changes
made to the internal DbSets of Entity Framework Core to the database. In section 8.4,
we wanted to execute a different version of the method, so we made a stub (Flying-
DutchmanAirlinesContext_Stub) and overrode the parent class’s SaveChangesAsync
method.







Allowing yourself to delete your own code when you find an alternative approach
(that works better) is a key skill for a developer and is harder than you think.


Deleting code
Deleting code is scary. A commonly used phrase for hesitation to delete your own
work is “kill your darlings.” Often, however, to deliver the best work possible, you
have to swallow your pride and delete your own (usually beautiful and elegant) code.
If you delete your code in favor of a better implementation, it is not defeat—quite
the opposite, it is a win. Even if you did not write the new implementation yourself,
you should consider this to be a positive change. The fresh approach is undoubtedly
more readable and maintainable, saving yourself (and others) a lot of heartache
down the road.
I want to draw your attention to a special case where you should be merciless in delet-
ing code, both of your own design and of others: commented-out code. I’m going to
say it, and I bet some of you disagree with me: commented-out code has no place in
a production codebase. Period. You do not merge commented-out code into the main
branch. Think about why the code is commented out in the first place. Is it something
that is an alternative approach to a solution? Is it an old implementation? Is it a half-
assed new implementation? Is it something that you might need in the future
(unlikely)? In my humble opinion, those reasons are not good enough to warrant you
spoiling my beautiful codebase with an ugly block of commented-out code. If you want
commented-out code in the codebase, you can either make it work (and uncom-
mented it), or you must not need it that badly.
For example, the following code block contains a method with an implementation but
has a comment with a different implementation:
// This code is too complicated! There is a better way.
// public bool ToggleLight() => _light = !_light;
public bit ToggleLight() => _light ^= 1;
Now, the comment in the code has a valid point. The IsToggleLight method running
uses a bitwise XOR operator to flip the _light bit. The implementation in the com-
ment may be easier to read, indeed. It also comes with some unknowns, however,
because it changes the return type of the ToggleLight method and the underlying
type of _light (both from bit to bool), but we could deal with that. Why was this
code never uncommented or implemented, though? Did it not pass code review?
Does it not work? Is this a passive-aggressive “for future reference” comment by a
disgruntled senior engineer or a new developer trying to impress somebody? It
doesn’t matter.



If BookingRepository does not function correctly, it has unwanted consequences
for BookingService. In testing BookingService, can we not assume that Booking-
Repository works correctly because we already have unit tests in place for that class?
Well, yes, that makes some sense. If we could somehow skip the BookingService code
and have it return valid information when we want it, we could control all the code
execution in the repository layer during the test. Additionally, if we instantiate a
BookingRepository and inject that into BookingService, the tests would operate on
the actual BookingRepository instance and, therefore, on the in-memory database
When testing a multilayered architecture (such as the repository/service pattern we
are using), you typically don’t need to test the actual logic of a tier down from what
you are working on. If you are testing the repository layer, you can stub or mock the
database access layer (which is what we did with the FlyingDutchmanAirlinesContext
_Stub class). If you are testing the service layer, you don’t need to verify the logic of
the repository layer.



A stub is very helpful when we want to execute different code than what the origi-
nal class does. For example, the context.SaveChangesAsync method saves the changes
made to the internal DbSets of Entity Framework Core to the database. In section 8.4,
we wanted to execute a different version of the method, so we made a stub (Flying-
DutchmanAirlinesContext_Stub) and overrode the parent class’s SaveChangesAsync
method.
In a mock, we do not provide any new implementation for a method. When we use
a mock, we tell the compiler to instantiate a type of Mock<T> that masquerades as T.
Because of the Liskov substitution principle, we can use the mock as type T. Instead of
an actual instance of class T being instantiated and injected into a constructor, we
instantiate and inject the mock.
In our case, we want a Mock<BookingRepository>. When, during a test, the code in
BookingService calls this mock’s CreateBooking, we want to do one of two following
things:
Immediately return from the method (without actually creating the booking in
the database) when we want to mimic a success condition.
Throw an Exception when we want to mimic a failure condition.
Because we need to do only these two simple things, and we do not have to perform
any logic that checks for entities within the in-memory database (like we do in the
stub), it is easier to use a mock. You’re not convinced? Well, hang on to your hats and
read the next section.


Compiler method inlining
During compilation, when a compiler encounters a call to a method in a different
class, it is often beneficial for performance to replace the method call with the body
of the called method. This decreases the amount of cross-file computation and, in
general, improves performance. There is a point of diminishing returns, however.
When the called method is very large and contains calls to other large methods, the
compiler can get stuck in a rabbit hole. The compiler then copies the bodies of deeply
nested methods into the original calling class, and before you know it, your class
blows up in size and complexity. Modern compilers are very good at detecting this
sort of thing, so in general, it is not something you need to worry about.
Additionally, compilers generally do not attempt to inline recursive methods because
it would result in the compiler being stuck in an infinite loop where it tries to copy the
body of the same method into itself into perpetuity. For more information on compiler
inlining (and compilers in general), see Alfred V. Aho, Monica S. Lam, Ravi Sethi, and
Jeffrey D. Ullman’s Compilers: Principles, Techniques & Tools (2nd edition; Pearson
Education, 2007).
uckily, we can tell the compiler to not inline the code in a specific method by using
the method implementation (MethodImpl ) method attribute. The MethodImpl method
attribute allows us to specify how the compiler should treat our method, and lo and
behold, one option is to stop the compiler from inlining a given method. Let’s add the
MethodImpl method attribute to the constructor and ask the compiler not to inline
the method, as shown here:
[MethodImpl(MethodImplOptions.NoInlining)]
public BookingRepository() {}




In a repository/service world, the controller holds an instance of the service,
and the service holds an instance of the repository. This is to ensure coupling is
as loose as possible between the individual classes. If the controller were to hold
an instance of both the service and repository, we would have very tight cou-
pling to the repository.


When testing a solution that follows the repository/service pattern (or any
other multilayered architecture), you need to test the logic only at the level you
want to test. For example, if you are testing a controller class, you may mock or
stub the service layer, but the test does not need to execute the actual logic in
the service layer. Consequently, the repository layer is not called at all in this
scenario. This helps us test only atomic operations, as opposed to entire stacks.
If we want to test across layers, we need an integration test.
 
 Compiler inlining means that a compiler replaces a method call with the body
of the called method. This is useful for performance because it reduces cross-
file calls.


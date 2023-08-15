Additionally, we do
not want to deal with the foreign key constraints on the repository level but rather on
the service level. For a repository/service architecture, a good rule of thumb is this:
keep your repositories dumb and your services smart. This means that your repository
methods should be methods with a stringent adherence to the single-responsibility
principle (discussed in the introduction of chapter 6), whereas this adherence is a bit
laxer on the service side.
Services can call whatever repository methods they need to fulfill their tasks. A
repository method should not have to call a different repository to do their job



Separation of concerns and coupling
“Separation of concerns” is a term coined by Edsger Dijkstra in his paper “On the
Role of Scientific Thought” (EWD 447, Springer-Verlag, 1982). At its most basic level,
it means that a “concern” should do only one concrete thing. But what is a “concern”?
A concern is a mental model of a programming module, which can take the form of
things like methods or a class. When we take separation of concerns to the class
level and apply it to BookingRepository, we might say that the BookingRepository
should concern itself only with operations on the Booking database table. This means
that retrieving information from the Customer table, for example, is not within the
scope of the concern. If we apply it to a method, we could say that a method needs
to do one singular thing and nothing else. This is a very important clean code tenet
because it helps us to develop code that is readable and maintainable.
We discussed the concept of writing code that reads like a narrative using small
methods before. This is that same concept. In his monumental work Clean Code: A
Handbook of Agile Software Craftsmanship (Prentice-Hall, 2008), Robert C. Martin
touches on this subject many times. One particular occasion is the section appropri-
ately titled “Do One Thing.” He tells us that “Functions should do one thing. They
should do it well. They should do it only.” If we hold this message in the back of our
heads when we write code, we are one step ahead of the curve when it comes to writ-
ing amazing code. We discussed the single-responsibility principle, which concerns
itself with writing clean methods that do only one thing, in chapter 6.
What is coupling, and how does it relate to the idea of separation of concerns? Cou-
pling is a different angle with which to approach the problem of separation of con-
cerns. Coupling is a metric that quantifies how integrated one class is with another.
If classes are highly coupled, it means that they depend highly on each other. We
call this tight coupling. We do not want tight coupling. Tight coupling often results in
methods calling a lot of other methods at the wrong architectural level: think about
the BookingRepository calling the FlightRepository to retrieve information about a flight.
Loose coupling is when two methods (or systems) are not very dependent on each
other and can execute independently (and, therefore, be changed with minimal side
effects). Larry Constantine coined the term coupling, which first appeared in the book
Structured Design: Fundamentals of a Discipline of Computer Program and Systems
Design (Prentice-Hall, 1979) by Constantine and Edward Yourdon. When trying to
determine the amount of coupling between two things, one can ask the question that
Constantine and Yourdon pose in their book: “How much of one module must be
known to understand another module?”



The CancellationToken class
You can cancel database queries in progress by using an instance of Cancellation-
Token and calling the CancellationToken.Cancel() method. Cancellation tokens
are also used to notify other parts of your code of a canceled request. We don’t use
these in our code because our requests are simple insertions and retrievals of single
records with limited foreign key constraints.
If you were to kick off a stored procedure that could take minutes to execute, you may
want to cancel it under some edge condition. In that case, use a cancellation token.
If we do not pass in an instance of CancellationToken, the CLR assigns a new
instance to the argument on its own.




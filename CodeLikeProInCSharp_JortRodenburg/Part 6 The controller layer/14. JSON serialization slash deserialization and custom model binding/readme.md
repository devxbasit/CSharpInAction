By adding the [FromBody] attribute to a type of BookingData accessible through the
body variable, we can now use the data from the HTTP request, as shown in figure 14.6.
It is that simple. Now, some people are not a fan of “magic” in their codebases, and
that’s fine.



Acceptance testing before you hand off your product to a client is incredibly import-
ant and useful. Wouldn’t you want to catch any bugs or incorrect functionality before
the client does? Because we are testing against the production (deployed) database,1
we can test only happy path and nondatabase exception scenarios. We don’t want to
force failures in a production environment. This is where us having unit-tested the
failure paths comes in handy because we can still be safe in knowing they work.
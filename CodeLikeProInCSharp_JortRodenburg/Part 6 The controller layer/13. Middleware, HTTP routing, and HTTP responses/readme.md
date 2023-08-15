A controller exposes methods we call endpoint methods. These methods accept
HTTP requests and return HTTP responses. An HTTP response usually comprises the
following three key items, as shown in figure 13.3:
 An HTTP status code like 200 (OK), 404 (Not Found), or 500 (Internal Server Error) —
The controller determines this status code based on the state of the service after
processing the request.
 Headers—This is a collection of key-value pairs that often include the type of
returned data and whether there are any cross-origin resource sharing (CORS)
instructions. Unless you need to pass along an odd header, the ASP.NET can
often take care of this step for you automatically.
 A body—Where appropriate, you can return data to the consumer. Often this
data is returned as a JSON value and goes along with a 200 (OK) status code.
Some HTTP status codes don’t allow for returning data (e.g., the 201 status
code, which means “no content”). This data is returned in the “body” section



That code compiles and returns exactly what we want. There is an additional tip here
that bears understanding: instead of using the magic (hardcoded) number of 200 for
the status code, we should use the HttpStatusCode enum and cast its value to an inte-
ger. It is a little bit more code, but it removes the magic number




Injecting dependencies by writing middleware is not the only way to
achieve DI in C#. Plenty of third-party (open source) DI frameworks for C#
are out there, such as Autofac, Castle Windsor, and Ninject. For more infor-
mation on some of these external frameworks, see Mark Seemann’s Depen-
dency Injection in .NET (Manning, 2011).


We can add dependencies to be injected in the ConfigureServices method in the fol-
lowing three ways:
 Singleton—One instance across the entire lifetime of the service
 Scoped—One instance across the lifetime of a request
 Transient—A new instance every time a dependency is used

USING A SINGLETON DEPENDENCY TO GUARANTEE THE SAME INSTANCE EVERY TIME
Adding an injected dependency with the singleton option mimics a singleton design
pattern. In a singleton design pattern, you have only one instance per application.
The CLR reuses this instance repeatedly for as long as your application runs. The
instance may start as a null pointer, but at first use, the code instantiates it.
When we use a singleton dependency with dependency injection, the injected
instance is always the same, no matter when or where it is injected. For example, if we
were to add an injected singleton of type BookingRepository, we would always use the
same instance for every request coming through our service.1


USING A SCOPED DEPENDENCY TO GUARANTEE THE SAME INSTANCE ON A PER-REQUEST BASIS
With a scoped dependency, every HTTP request instantiates its own version of the
dependency that needs injecting. ASP.NET uses this instance for the entire request
life cycle but instantiates a new instance for every new request that enters the hallowed
halls of the service.
For example, if we were to instantiate a FlightRepository instance and we inject
the FlightRepository type in two service layer classes, both service layer classes
would receive (and operate on) the same instance of FlightRepository, as long as we
are dealing with the same HTTP request.


USING A TRANSIENT DEPENDENCY (DI) TO ALWAYS GET A NEW INSTANCE
Transient dependencies in DI are perhaps the most common way of dealing with
dependency injection. When we add a transient dependency, every time that depen-
dency needs to be injected, ASP.NET instantiates a new instance. This guarantees that
we work on a fresh copy of the injected class.
Because transient dependencies are the most common, and easiest to use, types
of dependency injection, we shall fall in line. 
To add a transient dependency to the
ConfigureServices method in the Startup class, use the services.[dependency-
Type]([Requested Type], [Injected Type]) syntax.


Coding to interfaces is a clean code principle that promotes the use of generic
constructs over limiting concrete classes. This allows us to adhere to the Open/
Closed Principle and easily extend our code without changing the existing class.





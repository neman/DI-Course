## What is DI?

Dependency Injection (DI) is one of the most misunderstood concepts of object-oriented programming. The confusion is abundant and spans terminology, 
purpose, and mechanics. Should it be called Dependency Injection, Inversion of Control, or even Third-Party Connect? Is the purpose of DI only to support unit testing or is there a broader purpose? Is DI the same as Service Location? Is a DI CONTAINER required? 

BIG Picture.
Ask audience "What is DI?"

Present answer on slide from Wikipedia and Mark Seeman Blog

How to explain DI to 5 year old?

John Munsch et al., “How to explain Dependency Injection to a 5-year old,” 2009, http://stackoverflow.com/questions/1638919/how-to-explain-dependency-injection-to-a-5-year-old
When you go and get things out of the refrigerator for yourself, you can cause problems. You might leave the door open, you might get something Mommy or Daddy doesn’t want you to have. You might even be looking for something we don’t even have or which has expired.

What you should be doing is stating a need, “I need something to drink with lunch,” and then we will make sure you have something when you sit down to eat.

What this means in terms of object-oriented software development is this: 
  *collaborating classes (the five-year-olds) should rely on the infrastructure (the parents) to provide the necessary services.*

## Understanding the purpose of DI 

DI isn’t an end-goal—it’s a means to an end. DI enables loose coupling, and loose coupling makes code more maintainable. 
Software development is still a rather new profession, so in many ways we’re still figuring out how to implement good architecture. However, individuals with expertise in more traditional professions (such as construction) figured it out a long time ago. 
(e.g. Design patterns Christopher Alexander)

The hair dryer is tightly coupled to the wall and you can’t easily modify one without impacting the other.

SOLID

- Single Responsibility
- Open/closed
- Liskov substitution
- Interface segregation
- Dependency inversion

 LISKOV SUBSTITUTION PRINCIPLE. This principle states that we should be able to replace one implementation of an interface with another without breaking either client or implementation.

In software design, this way of INTERCEPTING one implementation with another implementation of the same interface is known as the Decorator design pattern. It gives us the ability to incrementally introduce new features and CROSS-CUTTING CONCERNS without having to rewrite or change a lot of our existing code. 

Adapter pattern
We sometimes find ourselves in situations where a plug doesn’t fit into a particular socket. If you’ve traveled to another country, you’ve likely noticed that sockets differ across the world.

The Adapter design pattern works like its physical namesake. It can be used to match two related, yet separate, interfaces to each other. This is particularly useful when you have an existing third-party API that you wish to expose as an instance of an interface your application consumes. 


## DEMO: Hello DI - small console app example

In software design, this way of *INTERCEPTING* one implementation with another implementation of the same interface is known as the Decorator[5] design pattern. It gives us the ability to incrementally introduce new features and CROSS-CUTTING CONCERNS without having to rewrite or change a lot of our existing code. 


Demo of SecurityConsoleWritter - Decorator Pattern

The SecureMessageWriter implements the security features of the application, whereas the ConsoleMessageWriter addresses the user interface. This enables us to vary these aspects independently of each other and compose them as needed. 

Loose coupling enables you to write code which is open for extensibility, but closed for modification. This is called the OPEN/CLOSED PRINCIPLE. The only place where you need to modify the code is at the application’s entry point; we call this the COMPOSITION ROOT. 

## Application Layering
View - wpf, UI elements and xaml
Presentation - ViewModel, Presentation logic
Repository - responsible to interact with Data
Service - wcf provides data
DataModel - Shared project

Show them each layer
Ask if layers means loose coupling?
Show the code

Client Side Caching

## Lab example: Tight Coupling to Loose Coupling
(transform ntier tight couple to loose couple)
Create Repository Interface (add class library)
Add reference to DataModel
Add CRUD operation
Repository --> Add ref to repository interface
ViewModel - Change to ISuperheroRepository
add constructor injection --> build failed
View ctor requires repository, add SuperheroViewModel to ctor and assign to DataContext
app builds, but fail at runtime on F5 - `An unhandled exception of type 'System.NullReferenceException' occurred in PresentationFramework.dll Additional information: Object reference not set to an instance of an object.`
go to App.xaml -> StartupUri
` StartupUri="SuperheroesViewerWindow.xaml`
Delete previous line of code - no window shown on F5
Go to App.xaml.cs
Add 
```csharp
    protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Application.Current.MainWindow = new SuperheroesViewerWindow();
            Application.Current.MainWindow.Show();
        }
```
change to 
Application.Current.MainWindow = new SuperheroesViewerWindow(viewModel);
add SuperheroViewModel viewModel = new SuperheroViewModel();
add IRepository reference

final

```csharp
  protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SuperheroRepository repository = new SuperheroRepository();
            SuperheroViewModel viewModel = new SuperheroViewModel(repository);
            Application.Current.MainWindow.Title = "Loose Coupling - Superheroes";
            Application.Current.MainWindow = new SuperheroesViewerWindow(viewModel);
            Application.Current.MainWindow.Show();
        }
```
go to Presentation, delete `using Repository.Service;` and assembly ref

next slide 
## Composing the Application
Back to code adding a bootstrapper

## DEMO: Add Bootstraper app, Add different Repository, Add Caching repository
add sln folder Application
Move SuperheroesViewer to new sln folder
Add new project to ApplicationView sln folder (ClassLibrary)
Add ref to (PresentationCore, PresentationFramework, System.Xaml, WindowsBase)
Add ref to proj Superheroes.Presentation and Superheroes.DataModel
Add existing Item SuperheroesViewerWindow.xaml
Remove SuperheroesViewerWindow.xaml from Application
Extract method from and call ComposeObjects

```csharp
SuperheroRepository repository = new SuperheroRepository();
SuperheroViewModel viewModel = new SuperheroViewModel(repository);
Application.Current.MainWindow = new SuperheroesViewerWindow(viewModel);
```

Coposition Root - location where we snap building blocks togheter
View - contains UI Elements for app, better seperation
Run the application

new demo
add additional differentRepository
add Superheroes.Repository.CSV ref to Bootstrap

add tp App.config
```xml
  <!-- Settings for CSV Repository -->
  <appSettings>
    <add key="CSVFileName" value="Superheroes.txt"/>
  </appSettings>
```

Client side caching add Caching repository
add caching repository project
add references to application
compose root with CachedRepository and csv
run app
stop service to se caching

Example of open closed principle

## Composition Root

The Composition Root can be implemented with Poor Man's DI, but is also the (only) appropriate place to use a DI Container.

## The appropriate entry point



## What are the benefits of DI?
Table is available on slides
 - Late binding - xml, json config (the ability to swap out one service with another is the most prevalent benefit for most people, so they tend to weigh the advantages against the disadvantages with     only this benefit in mind.)
 - Extensibility - e.g. Decorator (Successful software must be able to change. You’ll need to add new features and extend existing features. Loose coupling enables us to efficiently recompose the         application, similar to the way that we can rewire electrical appliances using plugs and sockets.)
   Loose coupling enables you to write code which is open for extensibility, but closed for modification. This is called the OPEN/CLOSED PRINCIPLE. The only place where you need to modify the code is at the application’s entry point; we call this the COMPOSITION ROOT. 
 - Parallel development
 - Maintainability - As the responsibility of each class becomes clearly defined and constrained, maintenance of the overall application becomes easier. This is a known benefit of the SINGLE          
   RESPONSIBILITY PRINCIPLE, which states that each class should have only a single responsibility. 
 - TESTABILITY - An application is considered TESTABLE when it can be unit tested. 

## What to inject and what not to inject?

 When you must decide how to package modules, loose coupling provides especially useful guidance. You don’t have to abstract everything away and make everything pluggable. 
 The .NET Base Class Library (BCL) consists of many assemblies. Every time you write code that uses a type from a BCL assembly, you add a dependency to your module. In the previous section, I discussed how loose coupling is important, and how programming to an interface is the cornerstone.

Does this imply that you can’t reference any BCL assemblies and use their types directly in your application? What if you would like to use an XmlWriter, which is defined in the System.Xml assembly? 

- Seams 
    Everywhere we decide to program against an interface instead of a concrete type, we introduce a SEAM into the application. A SEAM is a place where an application is assembled from its constituent parts,[13] similar to the way a piece of clothing is sewn together at its seams. 
    The Hello DI sample I built in section 1.2 contains a SEAM between Salutation and ConsoleMessageWriter. The Salutation class doesn’t directly depend on the ConsoleMessageWriter class; rather, it uses the IMessageWriter interface to write messages. You can take the application apart at this SEAM and reassemble it with a different message writer. 

- Stable Dependencies 
    By default, you can consider most (but not all) types defined in the BCL as safe, or STABLE DEPENDENCIES—I call them stable because they’re already there, tend to be backwards compatible, and invoking them has deterministic outcomes. 

     - The class or module already exists.
     - You expect that new versions won’t contain breaking changes.
     - The types in question contain deterministic algorithms.
     - You never expect to have to replace the class or module with another.

Ironically, DI CONTAINERS themselves will tend to be STABLE DEPENDENCIES, because they fit all the criteria. When you decide to base your application on a particular DI CONTAINER, you risk being stuck with this choice for the entire lifetime of the application; that’s yet another reason why you should limit the use of the container to the application’s COMPOSITION ROOT. 

- Volatile Dependencies 

     - The DEPENDENCY introduces a requirement to set up and configure a runtime environment for the application. A relational database is the archetypical example: if we don’t hide the relational database behind a SEAM, we can never replace it by any other technology. It also makes it hard to set up and run automated unit tests. Databases are a good example of BCL types that are VOLATILE DEPENDENCIES: even though LINQ to Entities is a technology contained in the BCL, its usage implies a relational database. Other out-of-process resources such as message queues, web services, and even the file system fall into this category. Please note that it isn’t so much the concrete .NET types that are Volatile, but rather what they imply about the runtime environment. The symptoms of this type of DEPENDENCY are lack of late binding and extensibility, as well as disabled TESTABILITY.
    
     - The DEPENDENCY doesn’t yet exist, but is still in development. The obvious symptom of such dependencies is the inability to do parallel development.
    
     - The DEPENDENCY isn’t installed on all machines in the development organization. This may be the case for expensive third-party libraries, or dependencies that can’t be installed on all operating systems. The most common symptom is disabled TESTABILITY.
    
     - The dependency contains nondeterministic behavior. This is particularly important in unit tests, because all tests should be deterministic. Typical sources of nondeterminism are random numbers and algorithms that depend on the current date or time. Note that common sources of nondeterminism, such as System.Random, System.Security.Cryptography.RandomNumberGenerator, or System.DateTime.Now are defined in mscorlib, so you can’t avoid having a reference to the assembly in which they’re defined. Nevertheless, you should treat them as VOLATILE DEPENDENCIES, because they tend to destroy TESTABILITY.

It’s for VOLATILE DEPENDENCIES, rather than STABLE DEPENDENCIES, that we introduce SEAMS into our application.

## DI Containers

after talk create ninject example project for DI

## Lab excercise: Add DI Container which reads configuration from file 

Lab for practice, create DI with file configuration,


## DI-PATTERNS

 - CONSTRUCTOR INJECTION

How do we guarantee that a necessary Dependency is always available to the class we’re currently developing?
BY REQUIRING ALL CALLERS TO SUPPLY THE DEPENDENCY AS A PARAMETER TO THE CLASS’S CONSTRUCTOR. 

Keep the constructor free of any other logic. The SINGLE RESPONSIBILITY PRINCIPLE implies that members should do only one thing, and now that we use the constructor to inject DEPENDENCIES, we should prefer to keep it free of other concerns. 

Think about CONSTRUCTOR INJECTION as statically declaring a class’s Dependencies. The constructor signature is compiled with the type and is available for all to see. It clearly documents that the class requires the DEPENDENCIES it requests through its constructor. 

CONSTRUCTOR INJECTION should be your default choice for DI. It addresses the most common scenario where a class requires one or more DEPENDENCIES, and no reasonable LOCAL DEFAULTS are available. 

If at all possible, constrain the design to a single constructor. Overloaded constructors lead to ambiguity: which constructor should a DI CONTAINER use? 

 - PROPERTY INJECTION

How do we enable DI as an option in a class when we have a good Local Default?
BY EXPOSING A WRITABLE PROPERTY THAT LETS CALLERS SUPPLY A DEPENDENCY IF THEY WISH TO OVERRIDE THE DEFAULT BEHAVIOR.

When a class has a good LOCAL DEFAULT, but we still want to leave it open for extensibility, we can expose a writable property that allows a client to supply a different implementation of the class’s DEPENDENCY than the default.  

PROPERTY INJECTION is also known as SETTER INJECTION. 

```csharp
public partial class SomeClass
{
    public ISomeInterface Dependency { get; set; }
}
```
You can’t mark the Dependency property’s backing field as readonly because you allow callers to modify the property at any given time of SomeClass’s lifetime. 

Another complication arises if you allow clients to switch the DEPENDENCY in the middle of the class’s lifetime. This can be addressed by introducing an internal flag that only allows a client to set the DEPENDENCY once.

PROPERTY INJECTION should only be used when the class you’re developing has a good LOCAL DEFAULT and you still want to enable callers to provide different implementations of the class’s DEPENDENCY.
PROPERTY INJECTION is best used when the DEPENDENCY is optional. 

It would be tempting to make that implementation the default used by the class under development. However, when such a prospective default is implemented in a different assembly, using it as a default would mean creating a hard reference to that other assembly, effectively violating many of the benefits of loose coupling described in chapter 1.

Conversely, if the intended default implementation is defined in the same library as the consuming class, you don’t have that problem. This is unlikely to be the case with Repositories, but such LOCAL DEFAULTS are more likely as Strategies

PROPERTY INJECTION is only one among many different ways of applying the OPEN/CLOSED PRINCIPLE. 

Sometimes you only wish to provide an extensibility point, but leave the LOCAL DEFAULT as a no-op. In such cases, you can use the Null Object[6] pattern to implement the LOCAL DEFAULT. 

With CONSTRUCTOR INJECTION, you could protect the class against such incidents by applying the readonly keyword to the backing field, but this isn’t possible when you expose the DEPENDENCY as a writable property. In many cases, CONSTRUCTOR INJECTION is much simpler and more robust, but there are situations where PROPERTY INJECTION is the correct choice. This is the case when supplying a DEPENDENCY is optional, because you have a good LOCAL DEFAULT. 

e.g. Default is MemoryCache, but change to RedisCache

 - METHOD INJECTION

How can we inject a Dependency into a class when it’s different for each operation?
BY SUPPLYING IT AS A METHOD PARAMETER. 

```csharp 
    public void DoStuff(ISomeInterface dependency)
```

Often, the DEPENDENCY will represent some sort of context for an operation that’s supplied alongside a “proper” value: 

```csharp 
    public string DoStuff(SomeValue value, ISomeContext context)
```

When to use it?
METHOD INJECTION is best used when the DEPENDENCY can vary with each method call. This can be the case when the DEPENDENCY itself represents a value, but is often seen when the caller wishes to provide the consumer with information about the context in which the operation is being invoked. 

```csharp
    public virtual object ConvertTo(ITypeDescriptorContext context,CultureInfo culture, object value, Type destinationType)
```
```csharp
    object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext);
```

if you’re building a framework, METHOD INJECTION can often be useful, because it allows you to pass information about the context to add-ins to the framework. That’s one reason why we see METHOD INJECTION used so prolifically in the BCL. 

We mainly use METHOD INJECTION when we already have an instance of the DEPENDENCY we want to pass on to collaborators, but where we don’t know the concrete types of the collaborators at design time (such as is the case with add-ins).

With METHOD INJECTION, we’re on the other side of the fence compared to the other DI patterns: we don’t consume the DEPENDENCY, but rather supply it. The types to which we supply the DEPENDENCY have no choice in how to model DI or whether they need the DEPENDENCY at all. They can consume it or ignore it as they see fit. 

 - AMBIENT CONTEXT

How can we make a Dependency available to every module without polluting every API with Cross-Cutting Concerns?
BY MAKING IT AVAILABLE VIA A STATIC ACCESSOR.  

```csharp
public string GetMessage()
{
    return SomeContext.Current.SomeValue;
}
```

In this case, the context has a static Current property that a consumer can access. This property may be truly static, or may be associated with the currently executing thread. 

The Context can be Abstract class, which allows us to replace one context with another implementation at runtime. 

The difference is that an AMBIENT CONTEXT only provides an instance of a single, strongly-typed DEPENDENCY, whereas a SERVICE LOCATOR is supposed to provide instances for every DEPENDENCY you might request. The differences are subtle, so be sure to fully understand when to apply AMBIENT CONTEXT before you do so. When in doubt, pick one of the other DI patterns.

When an AMBIENT CONTEXT is in play, it’s impossible to tell whether a given class uses it just by looking at its interface.

When an AMBIENT CONTEXT is in play, it’s impossible to tell whether a given class uses it just by looking at its interface.

this implicitness also makes it hard to discover a class’s extensibility points

BCL example is `System.Security.Principal.IPrincipal`
`Thread.CurrentCulture`

TimeProvider, DefaultTimeProvider, property TimeProvider
Testing DateTime.Now

Adapter Pattern can Abstract this ambient context

 - Interceptor
 Add another method to Product. Make it non virtual to show how it works.
 

DI Scope
- Object Composition
- Object Lifetime
- Interception



DI anti-patterns

    CONTROL FREAK
    BASTARD INJECTION
    CONSTRAINED CONSTRUCTION
    SERVICE LOCATOR

DI Refactorings

    Mapping runtime value to ABSTRACTIONS
    Working with short-lived DEPENDENCIES
    Resolving cyclic DEPENDENCIES
    Dealing with Constructor Over-injection
    Monitoring coupling

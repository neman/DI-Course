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

## Lab example: Tight Coupling to Loose Coupling
(transform ntier tight couple to loose couple)

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
- Seams 
    Everywhere we decide to program against an interface instead of a concrete type, we introduce a SEAM into the application. A SEAM is a place where an application is assembled from its constituent parts,[13] similar to the way a piece of clothing is sewn together at its seams. 

- Stable Dependencies 
    By default, you can consider most (but not all) types defined in the BCL as safe, or STABLE DEPENDENCIES—I call them stable because they’re already there, tend to be backwards compatible, and invoking them has deterministic outcomes. 

DI Scope
- Object Composition
- Object Lifetime
- Interception





DI anti-patterns

    CONTROL FREAK
    BASTARD INJECTION
    CONSTRAINED CONSTRUCTION
    SERVICE LOCATOR


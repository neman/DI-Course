 What is DI?

Dependency Injection (DI) is one of the most misunderstood concepts of object-oriented programming. The confusion is abundant and spans terminology, 
purpose, and mechanics. Should it be called Dependency Injection, Inversion of Control, or even Third-Party Connect? Is the purpose of DI only to support unit testing or is there a broader purpose? Is DI the same as Service Location? Is a DI CONTAINER required? 

BIG Picture.
Ask audience "What is DI?"

Present answer on slide from Wikipedia and Mark Seeman Blog

How to explain DI to 5 year old?

John Munsch et al., “How to explain Dependency Injection to a 5-year old,” 2009, http://stackoverflow.com/questions/1638919/how-to-explain-dependency-injection-to-a-5-year-old
When you go and get things out of the refrigerator for yourself, you can cause problems. You might leave the door open, you might get something Mommy or Daddy doesn’t want you to have. You might even be looking for something we don’t even have or which has expired.

What you should be doing is stating a need, “I need something to drink with lunch,” and then we will make sure you have something when you sit down to eat.

What this means in terms of object-oriented software development is this: collaborating classes (the five-year-olds) should rely on the infrastructure (the parents) to provide the necessary services. 


Understanding the purpose of DI 


DEMO: Hello DI - small console app example

What are the benefits of DI?

What to inject and what not to inject?
- Seams 
    Everywhere we decide to program against an interface instead of a concrete type, we introduce a SEAM into the application. A SEAM is a place where an application is assembled from its constituent parts,[13] similar to the way a piece of clothing is sewn together at its seams. 

- Stable Dependencies 
    By default, you can consider most (but not all) types defined in the BCL as safe, or STABLE DEPENDENCIES—I call them stable because they’re already there, tend to be backwards compatible, and invoking them has deterministic outcomes. 

DI Scope
- Object Composition
- Object Lifetime
- Interception


DEMO: Complex example (transform ntier tight couple to loose couple


DI anti-patterns

    CONTROL FREAK
    BASTARD INJECTION
    CONSTRAINED CONSTRUCTION
    SERVICE LOCATOR


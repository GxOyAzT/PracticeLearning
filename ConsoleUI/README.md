# Records
Benefits of Records:
- simple to set up
- thread-safe (because it's immutable by default)
- Easy/safe to share among methods

When to use Records:
- Capture external data that doesnt change
- API calls
- Processing data (ofc without change)

When not to use Records:
- when you need to change the data (Entity Framework)


# init
When we use init then value of property can be set only in constructor or when we first declare object. After initialize property is also readonly for this class.


# Design Patterns

## Singelton
We use it when we want a class to have only one object, then we use the singelton pattern.
Critics consider the singleton to be an anti-pattern in that it is frequently used in scenarios where it is not beneficial, introduces unnecessary restrictions in situations where a sole instance of a class is not actually required, and introduces global state into an application

## Template Method Pattern (Behavioral)
The template Method Pattern defined the program skeleton of an algorithm in an operation, deferring some steps to subclasses.
It lets one redefine certain steps of an algorithm without changing the algoritm's structure.
In the TMP, one or more algoritms steps can be overriden by subclasses to allow differing behaviorals while ensuring that the overarching algorithm is still followed.

## Command Pattern (Behavioral)
The CP is a behavioral design pattern in witch an object is used to encapsulate all information needed to perform an action or trigger on event at a later time.
It is used in conjunction with many other pattrens.

## Memento Pattern
The MP provides the ability to restore an object to its previous state (undo via rollback).
The MP is implemented with three objects: the originator, a caretaker and a memento.
The originator is some object that has an internal state.
The caretaker is going to do something to the originator, but wants to be alboe to undo the change. It asks for a memento object.
Then it does whatever operation (or sequence of operations) it is going to do.
To roll back the state before the operations, it returns the memento object to the originator.

## Strategy Pattern (behavioral)
The SP is software design pattern that enables an algorithm's behaviour to be selected at runtime. The strategy pattern: (1) defines a family of algorithms (2) encapsulates each algoritm (3) makes the algorithms interchangable within that family.
Promotes the Open/Closed principle by using Composition over Inheritance.


# Terms
instance objects - non static objects
tightly coupled


# Others
 - Class members (including nested classes and structs) can be declared with any of the six types of access. Struct members can't be declared as protected, protected internal, or private protected because structs don't support inheritance.
 - Derived classes can't have greater accessibility than their base types.


# Access Modifiers
 - public: The type or member can be accessed by any other code in the same assembly or another assembly that references it.
 - private: The type or member can be accessed only by code in the same class or struct.
 - protected: The type or member can be accessed only by code in the same class, or in a class that is derived from that class.
 - internal: The type or member can be accessed by any code in the same assembly, but not from another assembly.
 - protected internal: The type or member can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly.
 - private protected: The type or member can be accessed only within its declaring assembly, by code in the same class or in a type that is derived from that class.
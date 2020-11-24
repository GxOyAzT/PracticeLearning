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

## Template Method Pattern (Behavioral)
The template Method Pattern defined the program skeleton of an algorithm in an operation, deferring some steps to subclasses.
It lets one redefine certain steps of an algorithm without changing the algoritm's structure.
In the TMP, one or more algoritms steps can be overriden by subclasses to allow differing behaviorals while ensuring that the overarching algorithm is still followed.

# Terms
instance objects - non static objects

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
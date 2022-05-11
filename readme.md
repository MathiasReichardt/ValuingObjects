## ValuingObjects

This is a solution to demonstrate the use of ValueObjects


[See Implement value objects](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects)

## Important characteristics of value objects

- They have no identity.
- They are **immutable**. 
    - (also no Alias Bug -> ref one object in two places and change it by accident see: [AliasingBug by Martin Fowler](https://martinfowler.com/bliki/AliasingBug.html))

### Examples

- RangeClass vs 2 integers
- MyId vs GUID
- Currency vs int (what Currency? €, $..? )

### Hints

#### Equals() vs ==

- Normally (when not dealing with strings, that is), Equals compares values, while `==` compares object references.
- `==` operator is selected by left operand so `object == MyValuetyoe` will do a reference comparison on the pointers!
    - see [C# difference between == and Equals()](https://stackoverflow.com/questions/814878/c-sharp-difference-between-and-equals)

#### GetHashCode

- used by dictionaries and hashSets, if hashcode collides equality is checked

## Special: Ids

### Surrogate Id vs. natural/business Id

- Surrogate id is a unique key that can be used to identify an object (in the DB or HTTP) e.g. GUID

    1. Stability: Changing a key because of a business or natural need will negatively affect related tables. Surrogate keys rarely, if ever, need to be changed because there is no meaning tied to the value.
    2. Convention: Allows you to have a standardized Primary Key column naming convention rather than having to think about how to join tables with various names for their PKs.
    3. Speed: Depending on the PK value and type, a surrogate key of an integer may be smaller, faster to index and search.

- natural/business Id: Unique identifier inside the business rules e.g. A complete address, scheduled flight (airline, departureDate, flightNumber, operationalSuffix)
    - have understandable meaning and show structure
- A system often has both, do not use surrogate ids to handle business logic because it can change e.g. migrating to a new db, or also the natural id can change (customer move)


## Reads

- [Great library for SI units](https://github.com/angularsen/UnitsNet)
- [Value Object by Martin Fowler](https://martinfowler.com/bliki/ValueObject.html)
- [Implement value objects](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects)

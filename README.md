# FlyWeight Design Pattern
Flyweight is a structural design pattern that allows programs to support vast quantities of objects by keeping their memory consumption low.
Usage examples: The Flyweight pattern has a single purpose which is reducing memory intake. 
Identification: Flyweight can be recognized by a creation method that returns cached objects instead of creating new ones.

A flyweight object essentially has two kinds of attributes – intrinsic and extrinsic.
An intrinsic state attribute is stored/shared in the flyweight object, and it is independent of the flyweight’s context. As the best practice, we should make intrinsic states immutable.
An extrinsic state varies with the flyweight’s context, which is why they cannot be shared. Client objects maintain the extrinsic state, and they need to pass this to a flyweight object during object creation.

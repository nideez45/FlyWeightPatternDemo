# FlyWeight Design Pattern
Flyweight is a <b>structural</b> design pattern that allows programs to support vast quantities of objects by keeping their memory consumption low.
Usage examples: The Flyweight pattern has a single purpose which is reducing memory intake. 
Identification: Flyweight can be recognized by a creation method that returns cached objects instead of creating new ones.

A flyweight object essentially has two kinds of attributes – <b>intrinsic</b> and <b>extrinsic</b>.
An intrinsic state attribute is stored/shared in the flyweight object, and it is independent of the flyweight’s context. As the best practice, we should make intrinsic states immutable.
An extrinsic state varies with the flyweight’s context, which is why they cannot be shared. Client objects maintain the extrinsic state, and they need to pass this to a flyweight object during object creation.

I have made a Car class that has Company and Model as intrinsic attributes and Owner and Number as extrinsic attributes. The FlyWeight class will hold the intrinsic attributes and extrinsic attributes will be passed to this for displaying. There is a FlyWeight factory that caches various pairs of Company and Model on creation.

# Class relationship
![WhatsApp Image 2023-09-15 at 7 29 49 PM](https://github.com/nideez45/FlyWeightPatternDemo/assets/75631297/d6281260-2b14-41fd-a4cd-7d4e3592527d)

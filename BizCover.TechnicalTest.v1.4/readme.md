## Candidate Brief 

You are a software engineer for a company that sells cars online.
The company website uses an internal repository to manage its inventory of cars which is 
provided in ..\packages\BizCover.Repository.Cars.1.0.0\lib\netstandard1.2\BizCover.Repository.Cars.dll and referenced in the project.

The following methods are provided in the third party datasource "BizCover.Repository.Cars.CarRepository"

* GetAllCars
* Add
* Update

You will need to write a .Net REST API (using C#.Net) which will be used by the company website to consume this repository. 

This should be production ready code that can be supported!

This service should be able to perform the following:
1. Insert new car
2. Update existing car.
3. Calculate discount on a list of cars to purchase according to the rules mentioned below.

Discount calculation rule:
1. If total cost exceeds $100,000 apply 5% discount
2. If number of cars is more than 2, apply 3% discount
3. If cars year is before 2000, apply 10% discount
4. The above rules are cumulative (i.e. all of them can be applicable at the same time)



#### HINTS

1. Follow the brief and the requirements!

2. You should use this opportunity to demonstrate that you have the technical knowledge to be successful in a senior engineer.
Remember that a senior engineer will be a person who is not just an "order taker" that does the work, but is someone who can provide input to design decisions, follow best practices, perform peer reviews, and mentoring other developers.

3. If theres common code/scenarios that you have written then you dont need to do this everywhere. Its ok to leave a note for us so that given more time 
you would complete it. We just want to see how you've written it and what your approach is. For instance, if you were writing unit tests then if you cover 
one get scenario you can describe what you would do in other get scenarios if that was applicable.

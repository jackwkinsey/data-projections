# data-projections
Playing around with data projections in C#

This is just a simple project for messing around with ideas for performing data projections between generic types.

It uses a simply Point class and dummy car data.

The meat of the project resides in the Projection class. This class can project either a single entity or a list of entities
from one generic type to another through the use of an entity map which is just a simple diction of key/value pairs. This
entity map is used to describe the mapping of properties from one type to the other

(key = destination property, value = source property)

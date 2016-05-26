# media.elte.hu
Teacher's pages template generator from xml

A simple dotnet core razor based temlating for generating teachers' bio pages for http://media.elte.hu/oktatok/ 

By adding new entries to teachers.xml you can generate a new teacher. The node structure is self explanatory.

Every change must be made in this repository, and afterwards it can be re-generated.

The project is runnable 'as is' from Visual Studio 2015, or Visual Studio Code, by building and starting up 
(for example in debugging mode) and navigating to http://localhost:[port]/Teachers?id=[teacherid]


# notes 
Every paragraph would include a date (mm/dd/yyyy) some kind of short description of progress and faced/resolved problems

##  11/10/2023

project setup c# with cpp/cli 

### Using C++/CLI (CLR) 

- create c# and c++ (i.e. CLR Empty Project) projects. 
- go to cpp project properties and under linker find _Additional Dependencies_ and set its value to _inherit from parent_
- add project reference as described [here](https://learn.microsoft.com/en-us/visualstudio/ide/managing-references-in-a-project?view=vs-2022)
- make sure build dependencies are properly set under c# project properties
- build cpp project 
- reference cpp code in c# files like {namespace}.{class}.{method}

sidenote: clr in visual studio has build target set to .net7-windows, so it should be matched in c# code to be able tro build the solution.
todo: find out if it can be changed, so it could be multiplatform.
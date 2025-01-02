# The Hundred Prisoners Problem App

This is a WPF app that simulates the "Hundred Prisoner Problem" in an attempt to prove that the "following loops" solution does yield a 30% success rate.
Please find the explanation for the problem and the solution at the bottom.


## Current Features
- Choose the number of simulations and the number of prisoners per simulation, then run the simulations
- View the list of completed simulations to see which were successful
- View the list of attempts made by each prisoner to see whether they succeeded or not
- View each individual attempt to see which boxes the prisoner checked and which slip number they found inside


## Programming Concepts Used
- WPF (MVVM)
- Object Mapping (AutoMapper)
- Dependency Injection
- Logging
- Events
- Unit Tests (used modestly--this is an area that I need more practice with)


## Problem explanation

- 100 prisoners are numbered from 1 - 100
- 100 boxes labelled from 1 - 100 are placed in a room
- Each of the prisoner's numbers are written on slips and placed randomly in the boxes, one per box
- Each prisoner may enter the room one at a time and check up to 50 boxes
- They must leave the room exactly as they found it and can't communicate with the others after
- If all 100 prisoners find their number during their turn in the room, they will all be freed. But if even one fails, they will all be executed
- The prisoners may strategize before the challenge begins

** Note that a strategy where boxes are checked randomly yields a near 0% success rate.


## "Following loops" solution explanation

- Each prisoner first looks for the box labelled with their own number. If it contains their number, they succeed. If not, they go to the box labelled with the number they did find. They follow this pattern until they find their number or reach 50 boxes. The odds of success is near 30%.

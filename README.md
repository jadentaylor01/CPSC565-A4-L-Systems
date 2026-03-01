# CPSC 565 A4
Generation of treelike structures using stochastic Lindenmayer Systems.

## Ruleset 1
It is a stochastic extension to rule (d) in section 1.6.3 described in the book “The Algorithmic Beauty of Plants”. This rule makes it so that the point of branching into the smaller fractal like structures happens randomly on the main branch, creating varied leaf locations.

#### Alphabet
∑ = {F, X, +, -, [, ]}

α = 'X'

The characters in ∑ are interpretted by a turtle

'F' = Move forward and place a cylinder along the path

'X' = Do nothing

'+' = Rotate to the left

'-' = Rotate the the right

'[' = Save the turtles position and rotation onto a stack

']' = Pop the turtles position and rotation from the stack and return to the saved location

## Ruleset 2
This ruleset produces plants with one main stock with branches that have a large curvature, as well and grain-like leafs. There will be times you get large branches of leafs and other times the branches remain closer to the stock.

#### Alphabet

∑ = {F, X, L, +, -, [, ]}

α = 'F'

Is the same as Ruleset1, except for the addition of the character 'L'

'X' = Do nothing, this is where the branches entend from the main trunk

'L' = Do nothing, adds the curving nature to the plant leafs
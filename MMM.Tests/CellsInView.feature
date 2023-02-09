Feature: CellsInView

Make sure you can see what you're supposed to see in the First Person View

Scenario: Cells in View
	Given the following board
	| 1 | 7  | 13 | 19 | 25 |
	| 2 | 8  | 14 | 20 | 26 |
	| 3 | 9  | 15 | 21 | 27 |
	| 4 | 10 | 16 | 22 | 28 |
	| 5 | 11 | 17 | 23 | 29 |
	| 6 | 12 | 18 | 24 | 30 |
	When my ship is at (0,0) facing North
	Then the visible cells are
	| null | null | 4 | 10 | 16 |
	| null | null | 5 | 11 | 17 |
	| null | null | 6 | 12 | 18 |

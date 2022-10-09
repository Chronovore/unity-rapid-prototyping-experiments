# System Design
A simulation of autonomous colonies in a solar system.
## Brainstormed Features With Priority

IsComplete | Name | Value | Urgency | Risk Reduction | Duration | WSJF
--- |--- | --- | --- | --- | --- | ---
Yes | Selectable time passage                             | 8     | 7     | 3     | 2     | 9.0
No  | Autonomous building                                 | 4     | 5     | 7     | 3     | 6.3
No  | Resource Generation                                 | 8     | 10    | 10    | 5     | 5.6
No  | Autonomous trade                                    | 8     | 5     | 7     | 4     | 5.0
No  | Autonomous settlement                               | 3     | 3     | 7     | 3     | 4.3
No  | Multiple planets with differing types and resources | 10    | 10    | 10    | 10    | 3.0
No  | Player directed settlement                          | 7     | 8     | 2     | 8     | 1.9
No  | Player directed building                            | 7     | 3     | 2     | 8     | 1.5
No  | Visualization of trade and settlements              | 7     | 2     | 5     | 10    | 1.4

## Feature Requirements
### Incomplete

#### Autonomous building

### Completed

#### Selectable Time Passage
##### Visual
* Display an indicator of game time
* Display a selector of of multiple game time speeds (1x, 2x, 4x, 8x)
* Controls the passage of game time
* Pausing the game pauses time passage
##### Design Elements
* Set Days per week
* Set weeks per month
* Set duration of days
* Set names of days
* Set names of months
##### Systems
Time System
* Tracks Year/Month/Day
* Cycles year when end of year is passed
##### Future Enhancements
* Pause key
* Highlight selected button based on current speed
* Return to previous speed after resuming from pause.
# Patrick Setiawan, S3847228 - Storyteller Helper Overview
This tool is designed to help with the debugging process of story-based games. The testing scene uses a story stage int variable to keep track of the story's "stage", and depending on the stage, some objects might change in other stages (just like how story-based games work). Storyteller Helper helps by reflecting the changes when a player spawns in a certain stage (such as activating animators), spawning the players in custom coordinates, and many more to speed up debugging. This is especially useful, and even neccessary, to have when debugging in a large game.

## Getting Started

Firstly, it is recommended that you copy the testing scene's Story Tools GameObject for simplicity, but if you want to start from scratch, 3 empty GameObjects must be created in the scene. These objects should be named StoryManager, StoryDebugger, and StageCoordinates. For StageCoordinates, create a number of empty GameObjects as its children - each children represent the spawn coordinates for the player during testing. Add more children if you need more spawn coordinates. Finally, attach the respective scripts in ToolScripts to StoryManager and StoryDebugger, and to each children of StageCoordinates.

## Features
1. Story Manager
2. Story Debugger
3. Stage Coordinates

### Story Manager

Story Manager is a script responsible for controlling the stage of the story, and what to do when a stage is completed in normal gameplay. In the testing scene example, scripts tied to a stage are automatically destroyed when that stage is over. This is a completely optional feature, but since in most story-based games scripts are no longer used once that stage is passed, it is destroyed by default to prevent it from consuming more resources and also hindering the gameplay in the next stages. You can delete/modify this if you don't want this feature.

### Story Debugger

Story Debugger is the script responsible for helping debug at certain stages. All of its functions are already commented in the script itself, but there is one feature that might need more explanation. The enableAnimatorState and enableCustomState booleans are variables that determine whether certain animators will be automatically played upon start. If you want to add this feature to your own animator, you must create a transition from the idle state to the playing state of your animator, and add a new boolean parameter called "DebugState" with default value == false. Add this animator to the list of animators to be activated, and the transition should play automatically upon start.

### Stage Coordinates

They are just a set of GameObjects that represent the coordinates for the players to spawn in. Generally, these coordinates are the "default" position of the player for the stage (e.g if the player enters a cave, they will spawn at its inside entrance), but they can be anywhere.

### IMPORTANT: Tool Rules

- Story Tools is designed mainly for linear progression of story-based games, but can be modified/ used for other games that have a level or stage system to it.

- Story Tools is for controlling the flow of the story and changing objects' state for debugging. It is not responsible and has no reference to the text system in the scene, therefore it can work with custom text managers.

- By default, Game Objects that change the stage number must have a reference to StoryManager.storyStage, as that is the only way they can change it.

### Credits/ External Assets

- First Person Drifter (modified): http://www.torahhorse.com/index.php/portfolio/first-person-drifter-for-unity/ 
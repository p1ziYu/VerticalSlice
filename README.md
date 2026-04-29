# GDIM33 Vertical Slice
## Milestone 1 Devlog
1. The graph is responsible for dynamically generating and displaying player choices during the narrative. When the dialogue engine reads a [Choice] command from the script, it uses a String Split node to break the single line of text into an array of separate data points. The graph then uses List: Get Item nodes to extract specific segments, which contain the actual text for options. These extracted strings are fed directly into TextMeshPro: Set Text nodes to update the UI buttons. Finally, the execution flow triggers a Game Object: Set Active node targeting the choicePanel variable, making the entire choice interface visible to the player.
2. In the new breakdown, I specified the NPC's internal logic by expanding it into an "Emotion State Machine". It works by executing specific logic within each state block. For example, during the Pacing state, it uses an On Update node combined with a sine wave calculation to make the NPC continuously walk back and forth. When transitioning to the Angry state, the On Enter State node instantly halts the movement and activates a hidden UI explosion graphic behind the character. Also, I deleted some of the useless attributes for the player.

    The most significant architectural update is how this State Machine interacts with the Dialogue/Narrative Engine. Instead of hardcoding state transitions within the state machine itself, it is driven by the dialogue text file. When the player clicks to advance the conversation, the Dialogue Engine parses the .txt script. If it detects a custom tag like [Event]|GoAngry, a String Split node isolates the command and fires a Trigger Custom Event aimed directly at the NPC's GameObject. The NPC's State Machine listens for this specific signal to transition between states.

<img width="1671" height="1068" alt="QQ20260428-195345" src="https://github.com/user-attachments/assets/37320393-d873-4c15-a006-a6604393ec2c" />

## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!

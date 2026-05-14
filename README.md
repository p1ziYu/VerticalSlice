# GDIM33 Vertical Slice
## Milestone 1 Devlog
1. The graph is responsible for dynamically generating and displaying player choices during the narrative. When the dialogue engine reads a [Choice] command from the script, it uses a String Split node to break the single line of text into an array of separate data points. The graph then uses List: Get Item nodes to extract specific segments, which contain the actual text for options. These extracted strings are fed directly into TextMeshPro: Set Text nodes to update the UI buttons. Finally, the execution flow triggers a Game Object: Set Active node targeting the choicePanel variable, making the entire choice interface visible to the player.
2. In the new breakdown, I specified the NPC's internal logic by expanding it into an "Emotion State Machine". It works by executing specific logic within each state block. For example, during the Pacing state, it uses an On Update node combined with a sine wave calculation to make the NPC continuously walk back and forth. When transitioning to the Angry state, the On Enter State node instantly halts the movement and activates a hidden UI explosion graphic behind the character. Also, I deleted some of the useless attributes for the player. 
The most significant architectural update is how this State Machine interacts with the Dialogue/Narrative Engine. Instead of hardcoding state transitions within the state machine itself, it is driven by the dialogue text file. When the player clicks to advance the conversation, the Dialogue Engine parses the .txt script. If it detects a custom tag like [Event]|GoAngry, a String Split node isolates the command and fires a Trigger Custom Event aimed directly at the NPC's GameObject. The NPC's State Machine listens for this specific signal to transition between states.

<img width="1671" height="1068" alt="QQ20260428-195345" src="https://github.com/user-attachments/assets/37320393-d873-4c15-a006-a6604393ec2c" />

## Milestone 2 Devlog
1. I am building a multi-scene, narrative-driven transition system that bridges the Main Menu, an animated lore introduction, a Level Selection UI, and an MP4 video cutscene before dropping the player into the gameplay level
    1. Implement the Interactive Intro Cinematic (Scene: IntroScene)
        - Set up a UI Canvas with two distinct Canvas Group objects to separate the cosmic narrative text from the character sprite reveal.
        - Utilize Unity's Animation window to record a timeline, keyframing the Alpha values of the Canvas Groups to create a smooth fade-in/fade-out cinematic sequence.
        - Create a full-screen, invisible UI Button with its Text component deleted.
        - Use Visual Scripting to link the invisible button's On Click event to SceneManager.LoadScene, allowing the player to click anywhere to proceed to the Level Select scene.

    2. Develop the Audio Manager (Cross-Scene)
        - Extract the Audio Source from the Start Menu's Main Camera and place it on a newly created, dedicated BGM_Manager GameObject.
        - Assign a custom Unity Tag to the manager to make it identifiable across different scenes.
        - Create a Visual Scripting graph on the manager to enforce a Singleton pattern: check if another object with the tag exists; if not, execute DontDestroyOnLoad.
        - Build a "Music Assassin" prefab using Visual Scripting (Find With Tag -> Destroy) and place it in the target gameplay/transition scenes to kill the global music.

    3. Integrate the Video Transition (Scene: TransitionScene)
        - Get the mp4 video file from source and place it in the Unity StreamingAssets folder.
        - Create a new scene with a Video Player component attached to the Main Camera, set to render on the Camera Near Plane to ensure full-screen playback.
        - Implement dual-exit logic via Visual Scripting: a Coroutine timer (Wait For Seconds) that auto-loads the "Belobog" scene when the video ends

2. Yes, the breakdown activity was incredibly helpful because it forced me to plan the architecture of a complex cross-scene feature (global audio and WebGL video) before coding, saving me from major debugging headaches like overlapping audio tracks. To improve future breakdowns, I would make the steps more technically granular by specifying exact Visual Scripting nodes.
3. I call C# methods directly from my Visual Scripting graph using InvokeMember nodes. Specifically, my dialogue graph calls the PlayTypewriter() method in TypewriterEffect.cs to animate text, and the FocusSpeaker() method in SpeakerHighlight.cs to highlight the active character's portrait. It delegates complex implementation details to C#, where such logic is much more efficient and natural to write than in a node graph. <img width="1872" height="848" alt="QQ20260514-164803" src="https://github.com/user-attachments/assets/bffb588f-d839-40f0-93cb-68fb0eb98a9c" />
4. For Feature (3), please grade my Cross-Scene Global Audio System, which uses a Visual Scripting Singleton pattern to persist music and a KillBGM logic to dynamically destroy it when local audio takes over. You can find the persistent logic attached to the BGM_Manager in the StartMenu scene, and the destruction logic on the KillBGM object in the Belobog scene.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!

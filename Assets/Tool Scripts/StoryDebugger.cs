/*
* Description : This script is for debugging purposes. You can modify storyStage and custom variables/animators here.
* For debugging, set storyStage in StoryManager to the stage you want to debug.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDebugger : MonoBehaviour
{
    // if storyMode is true, then storyManager scripts are run. Set this to false to debug without interference from the StoryManager.
    public bool storyMode = true;

    // spawn coordinates for the player for debugging
    [SerializeField] GameObject player;

    // spawnCoorIndex == 1 corresponds to the first coordinate in the list of spawn coordinates, and by default is the starting 
    // point of the player in the game. The value of spawnCoorIndex must be between 1 and the max length of spawnCoorList
    public int spawnCoorIndex = 1;

    // variable to set whether all object states until that stage has been interacted. If true, all objects appear in the state
    // as if the player has played the game normally until that point (e.g opened doors). If false, then leave the objects as is
    public bool enableAnimatorState = false;

    // similar to stageState, but allows choosing your own animators to activate/ deactivate. 
    public bool enableCustomState = false;

    // variable to disable scripts and gameobjects
    public bool disableCustomScript = false;
    public bool disableCustomObject = false;

    // variable to display player's current stage in the console
    public bool displayStage = false;

    // array of animators to run animations automatically on start when debugging (add more arrays depending on the stages in your
    // game). To add the debug function to a new animator, simply create a new boolean parameter and add it in the transition you 
    // are testing called "DebugState".
    public Animator[] stage1Animators;
    public Animator[] stage2Animators;
    public Animator[] stage3Animators;
    public Animator[] stage4Animators;

    // custom animators for toggling
    public Animator[] customAnimators;

    public Dictionary<int, Animator[]> animatorDicts;

    // list of scripts to manually activate/deactivate (modify the list type for scripts that don't inherit from Monobehaviour)
    public List<MonoBehaviour> customScripts;

    // list of game objects to manually enable/disable (useful to get past areas easily such as walls and doors)
    public List<GameObject> customObjects;

    // array of coordinates to teleport the player to, modify the coordinates for custom locations
    public StageCoordinate[] spawnCoorList;
    public GameObject storyManager;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the dictionary of animators
        animatorDicts = new Dictionary<int, Animator[]>()
        {
            {1, stage1Animators},
            {2, stage2Animators},
            {3, stage3Animators},
            {4, stage4Animators},
        };

        if (enableAnimatorState)
        {
            toggleAnimationForStage(storyManager.GetComponent<StoryManager>().storyStage);
        }
        if (enableCustomState)
        {
            toggleAnimation(customAnimators);
        }

        // spawn the player in the determined location
        spawnPlayer(spawnCoorIndex);

        // disable/ set inactive all scripts and objects in custom scripts/objects if toggled
        if (disableCustomScript)
        {
            disableScripts();
        }
        if (disableCustomObject)
        {
            disableObjects();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // display storyStages in the console
        if (displayStage)
        {
            Debug.Log("Story Stage is at :" + storyManager.GetComponent<StoryManager>().storyStage);
        }
    }

    // manually disable scripts in the game. If storyMode == true, storyManager will already destroy scripts in previous stages, but
    // scriptDisabler allows you to choose a custom list of scripts to disable.
    // Note: Disabling scripts will only disable update properties in them, hence other functions such as OnMouseDown() will still run.
    // change .enabled to a Destroy() function to completely remove script from gameplay
    void disableScripts()
    {
        foreach (MonoBehaviour i in customScripts)
        {
            i.enabled = false;
        }
    }

    // manually disable objects in the game
    void disableObjects()
    {
        foreach (GameObject i in customObjects)
        {
            i.SetActive(false);
        }
    }

    // spawn player according to the index
    // Note: Make sure that “Auto Sync Transforms” in the Physics section of Project Settings is enabled!
    // Otherwise, the player will not be teleported to the spawn coordinates
    void spawnPlayer(int index)
    {
        player.transform.position = spawnCoorList[index - 1].coordinate;
    }

    // toggle array of animators
    void toggleAnimation(Animator[] animators)
    {
        for (int i = 0; i < animators.Length; i++)
        {
            // automatically transitions to the animation where DebugState boolean is attached
            animators[i].SetBool("DebugState", true);
        }
    }

    // run the animators that are associated to that stage. For example, if the story stage is 2, then animators in the 1st
    // stage are automatically toggled based on the dictionary
    void toggleAnimationForStage(int n)
    {
        for (int i = 1; i < n; i++)
        {
            if (animatorDicts.ContainsKey(i)) 
            {
                toggleAnimation(animatorDicts[i]);
            }
        }
    }
}

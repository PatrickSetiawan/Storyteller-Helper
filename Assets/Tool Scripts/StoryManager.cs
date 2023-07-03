/*
* Description : This script is for managing the story in normal gameplay and starting the game at certain stages by changing storyStage's value. 
* You can modify this script to adjust to other games' rules/ mechanics. By default, for the testing scene, the rules are that storyStage always 
* increases by 1 when the player completes a stage, and that scripts tied to all objects in a previous stage are destroyed automatically.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    // variable to keep track of which stage the player is at in the story. This number will only increase as the story progresses. Set 
    // the value to 1 to start game from beginning
    public int storyStage = 1;
    public GameObject storyDebugger;
    public List<MonoBehaviour> stage1Scripts;
    public List<MonoBehaviour> stage2Scripts;
    public List<MonoBehaviour> stage3Scripts;
    public List<MonoBehaviour> stage4Scripts;
    public Dictionary<int, List<MonoBehaviour>> scriptDicts;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the dictionary of scripts
        scriptDicts = new Dictionary<int, List<MonoBehaviour>>()
        {
            {1, stage1Scripts},
            {2, stage2Scripts},
            {3, stage3Scripts},
            {4, stage4Scripts},
        };
    }

    // Update is called once per frame
    void Update()
    {
        // destroy the scripts in previous/completed stages. This is done for performance optimization, but also to make sure that only 
        // scripts tied to that story stage are being run and non-Update functions like OnMouseDown() are also disabled
        if (storyDebugger.GetComponent<StoryDebugger>().storyMode)
        {
            destroyScriptsForStage(storyStage);
        }
    }

    // destroy all scripts in the list of scripts
    void destroyScripts(List<MonoBehaviour> scriptList)
    {
        foreach (MonoBehaviour i in stage1Scripts)
        {
            Destroy(i);
        }
    }

    // destroy all scripts that are associated to that stage. For example, if the story stage is 2, then scripts in the 1st
    // stage are automatically destroyed based on the dictionary
    void destroyScriptsForStage(int n)
    {
        for (int i = 1; i < n; i++)
        {
            if (scriptDicts.ContainsKey(i)) 
            {
                destroyScripts(scriptDicts[i]);
            }
        }
    }
}

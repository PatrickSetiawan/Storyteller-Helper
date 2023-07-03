using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Script : MonoBehaviour
{
    public Animator doorAnimator;
    public GameObject npc1;
    public GameObject textManager;
    public GameObject storyManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (npc1.GetComponent<NPC1Script>().doorOpen)
        {
            textManager.GetComponent<TextManager>().changeDoorText(true);
            doorAnimator.SetBool("OpenDoor", true);
            storyManager.GetComponent<StoryManager>().storyStage = 2;
        } else
        {
            textManager.GetComponent<TextManager>().changeDoorText(false);
        }
    }
}

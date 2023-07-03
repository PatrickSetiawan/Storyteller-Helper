using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Script : MonoBehaviour
{
    public Animator doorAnimator;
    public GameObject chest;
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
        if (chest.GetComponent<ChestScript>().doorOpen)
        {
            textManager.GetComponent<TextManager>().changeDoorText(true);
            doorAnimator.SetBool("OpenDoor", true);
            storyManager.GetComponent<StoryManager>().storyStage = 3;
        } else
        {
            textManager.GetComponent<TextManager>().changeDoorText(false);
        }
    }
}


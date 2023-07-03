using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text currText;
    public static string[] storyText1 = 
    {
        "Hello, I am the first NPC! Nice to meet ya!",
        "Oh? Do you need the key to enter that door? Give me a second...",
        "Found it, here you go! Now you can click on that door to open it!",
    };

    public static string[] storyText2 =
    {
        "Hmm... There seems to be something in the bottom of this chest.",
        "There's a... knife? And something else.....",
        "A key? I think you should use it to open that 2nd door.",
    };

    public static string[] storyText3 = 
    {
        "Oh why hello there! Are you looking for a way out of this place?",
        "Do you mind if I come with you? I'm sure I can be of help!",
    };

    public static string[] endingText = 
    {
        "You have escaped successfully! You are good!",
        "Why did you stab the NPC?! You are evil!",
    };

    public static string[] doorText =
    {
        "You need a key to open this door."
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void changeText(int storyIndex, int lineNumber)
    {
        switch (storyIndex)
        {
            case 1:
            currText.text = storyText1[lineNumber - 1];
            break;

            case 2:
            currText.text = storyText2[lineNumber -1];
            break;

            case 3:
            currText.text = storyText3[lineNumber - 1];
            break;

            case 4:
            currText.text = endingText[lineNumber - 1];
            break;
        }
    }

    public void changeDoorText(bool isDoorOpened)
    {
        if (isDoorOpened)
        {
            currText.text = "";
        } else
        {
            currText.text = doorText[0];
        }
    }
}
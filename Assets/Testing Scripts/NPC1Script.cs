using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1Script : MonoBehaviour
{
    private int lineIndex = 1;
    public bool doorOpen = false;
    public GameObject textManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // iterate through text
        if (lineIndex < TextManager.storyText1.Length)
        {
            textManager.GetComponent<TextManager>().changeText(1, lineIndex);
            lineIndex++;
        } else if (lineIndex >= TextManager.storyText1.Length)
        {
            textManager.GetComponent<TextManager>().changeText(1, lineIndex);
            doorOpen = true;
        }
    }   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
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
        // open chest animation
        gameObject.GetComponent<Animator>().SetBool("OpenChest", true);

        // iterate through text
        if (lineIndex < TextManager.storyText2.Length)
        {
            textManager.GetComponent<TextManager>().changeText(2, lineIndex);
            lineIndex++;
        } else if (lineIndex >= TextManager.storyText2.Length)
        {
            textManager.GetComponent<TextManager>().changeText(2, lineIndex);
            doorOpen = true;
        }
    }   
}

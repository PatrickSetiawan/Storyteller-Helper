using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC2Script : MonoBehaviour
{
    private int lineIndex = 1;
    public enum choices {None, Evil, Good};
    public choices choice = choices.None;
    public GameObject textManager;
    public GameObject storyManager;
    public GameObject player;
    public GameObject option1;
    public GameObject option2;
    private bool choiceMade = false;
    Vector3[] teleportCoor = new [] { new Vector3(-22.41f,0.889f,-10.44f), new Vector3(-22.41f,-36.90f,-10.44f) };

    // Start is called before the first frame update
    void Start()
    {
        Button button1 = option1.GetComponent<Button>();
        button1.onClick.AddListener(GoodChoice);
        Button button2 = option2.GetComponent<Button>();
        button2.onClick.AddListener(EvilChoice);
    }

    // Update is called once per frame
    void Update()
    {
        // teleport the player to a specified coordinate depending on their choice
        if (choice == choices.Good)
        {
            player.transform.position = teleportCoor[0];
            textManager.GetComponent<TextManager>().changeText(4, 1);
        } else if (choice == choices.Evil)
        {
            player.transform.position = teleportCoor[1];
            textManager.GetComponent<TextManager>().changeText(4, 2);
        }
    }

    void GoodChoice()
    {
        option1.SetActive(false);
        option2.SetActive(false);
        choice = choices.Good;
        storyManager.GetComponent<StoryManager>().storyStage = 4;
        choiceMade = true;
    }

    void EvilChoice()
    {
        option1.SetActive(false);
        option2.SetActive(false);
        choice = choices.Evil;
        storyManager.GetComponent<StoryManager>().storyStage = 4;
        choiceMade = true;
    }

    void OnMouseDown()
    {
        // iterate through text
        if (lineIndex < TextManager.storyText3.Length)
        {
            textManager.GetComponent<TextManager>().changeText(3, lineIndex);
            lineIndex++;
        } else if (lineIndex >= TextManager.storyText3.Length)
        {
            textManager.GetComponent<TextManager>().changeText(3, lineIndex);
            // show the choices on the last dialogue
            if (!choiceMade)
            {
                option1.SetActive(true);
                option2.SetActive(true);
            }
        }
    }   
}

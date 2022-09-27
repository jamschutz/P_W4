using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowStory : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text text;
    public GameObject background;

    [Header("Text")]
    public string[] narration;


    bool showStory;
    int currentLine;


    void Start()
    {
        background.SetActive(false);
        text.text = "";
        showStory = false;
        currentLine = 0;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            showStory = true;
            background.SetActive(true);
            text.text = narration[currentLine];

            if(currentLine < narration.Length - 1) {
                currentLine++;
            }
        }


        if(Input.GetKeyUp(KeyCode.Space)) {
            showStory = false;
            background.SetActive(false);
            text.text = "";
        }
    }
}

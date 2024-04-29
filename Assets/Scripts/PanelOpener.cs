using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;

    public TMP_Text resultText;
    private string buttonName;
    public int correctIndex;
    public List<GameObject> pics;

    // Method to open or close the panel
    public void OpenPanel() {
        if (panel != null) {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);

        }
    }

    // Method to set the index of the correct answer
    public void setCorrectIndex(int index) {
        correctIndex = index;
     
    }

    // Method called when a button is clicked
    public void OnClick(int buttonIndex)
    {
        int num = correctIndex;        
        
        GameObject correct = pics[0];
        GameObject wrong = pics[1];

        correct.SetActive(false);
        wrong.SetActive(false);
        
        if (buttonIndex == num) { 
            
            correct = pics[0];
             correct.SetActive(true);
            resultText.text = "せいかいです◎";

        }
        else
        {
           wrong = pics[1];
            wrong.SetActive(true);
            resultText.text = "まちがっています×！";
        }


    }


 
}

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
    public string buttonName;
    public int correctIndex;

    public void OpenPanel() {
        if (panel != null) {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);

        }
    }

    public void setCorrectIndex(int index) {
        correctIndex = index;
     
    }

    public void OnClick(int buttonIndex)
    {
        int num = correctIndex;        Debug.Log(buttonIndex + "unityindex");
        Debug.Log(correctIndex + "correctIndex?");

        if (buttonIndex == num)
        {

            resultText.text = "せいかいです！　よくできました◎";

        }
        else
        {
            resultText.text = "まちがっています×　もういちどちょうせんしよう！";
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShowTextonButton : MonoBehaviour
{
   

    public string character;
    public TMP_Text randomText;

      public void setText(string character) {
        this.character = character;
        randomText.text = character;
       // randomText.text = character;
    }


 

}

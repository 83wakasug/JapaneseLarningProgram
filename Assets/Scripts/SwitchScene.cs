using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : MonoBehaviour
{
 
    public List<GameObject> ListOfCanvases;

    public void switchCanvas(int index) {

        foreach (GameObject canvas in ListOfCanvases) { 
            canvas.SetActive(false);
        }

        ListOfCanvases[index].SetActive(true);
    }

}

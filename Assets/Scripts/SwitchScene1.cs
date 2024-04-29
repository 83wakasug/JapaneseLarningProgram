using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene1 : MonoBehaviour

{
    public void Start( )
    {
       
    }



    // Start is called before the first frame update
    public void KatakanaHiraganaGame(int sceneId ) {
       
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);

    }
   
}

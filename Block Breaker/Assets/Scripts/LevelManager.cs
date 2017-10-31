using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Debug.Log("try " + name);   // ispis na konzolu da vidimo ako se funkcija poziva
        Brick.breakableCount = 0;
        Application.LoadLevel(name); // idemo na drugu scenu
        
    }


    public void QuitRequest()
    {
        Debug.Log("try Quit");   // ispis na konzolu da vidimo ako se funkcija poziva
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel+1);
    }


    public void BrickDestroyed()
    {
        if (Brick.breakableCount <=0)
        {
            LoadNextLevel();
        }
    }
}

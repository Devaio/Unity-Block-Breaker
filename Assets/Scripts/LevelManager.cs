using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {


    public void LoadLevel (string name)
    {
        Debug.Log("Level load requested for : " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        //Application.LoadLevel(Application.loadedLevel + 1); // Obsolete
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void BrickDestroyed()
    {
        // if last brick destroyed
        if (Brick.breakableCount <= 0){
            LoadNextLevel();
        }
    }

}

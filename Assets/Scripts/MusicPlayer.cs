using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    void Awake()
    {
        //Debug.Log("Music Player AWAKE" + GetInstanceID());
        // we only want one music player, 
        if (instance != null)
        {
            // if one already exists, destroy the new one
            Destroy(gameObject);
            print("Duplicate Music Player Self-Destructing!");
        }
        else
        {
            //when one is created and this script runs, set the instance and prevent it from being destroyed on scene load
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}

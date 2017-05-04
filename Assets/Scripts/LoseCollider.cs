using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private LevelManager LevelManager;
    void Start()
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    void OnCollisionEnter2D (Collision2D collision)
    {
        print("Collide");
    }

    void OnTriggerEnter2D (Collider2D trigger)
    {
        print("Trigger");
        LevelManager.LoadLevel("Lose");
    }
}

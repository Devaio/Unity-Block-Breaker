using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public AudioClip crack;
    private int timesHit;
    private LevelManager LevelManager;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        
        timesHit = 0; // initialize brick at 0 hits
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");

        if (isBreakable) {
            breakableCount++;
        }
        //print(breakableCount);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D (Collision2D collision){
        AudioSource.PlayClipAtPoint(crack, transform.position);

        if (isBreakable) {
            HandleHits();
        }

    }

    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]){
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    void HandleHits (){
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            LevelManager.BrickDestroyed();
            Destroy(gameObject);

        }
        else
        {
            LoadSprites();
        }
    }

    // TODO Remove this method once we can actually win
    void SimulateWin(){
        LevelManager.LoadNextLevel();
    }
}

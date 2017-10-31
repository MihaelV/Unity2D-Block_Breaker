using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    
    private LevelManager levelManager;
    //private int maxHits;
    private int timesHit;

    public Sprite[] hitSprites;

    public static int breakableCount = 0;
    private bool isBreakable;
    

    public AudioClip crack;

    public GameObject smoke;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        // keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
            
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }


    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            puffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void puffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject; // instanciramo novi dim
        var sc = smokePuff.GetComponent<ParticleSystem>().main;
        //GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;  // uzimamo boju cigle i psotavljamo ju u boju dima
        sc.startColor = gameObject.GetComponent<SpriteRenderer>().color;
        Destroy(smokePuff, sc.duration); // uništava objekt dima nakon što se dim izanimira
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1; // blok je udaren 1 puta ali indeks prvog ostecenog bloka je 0 zato oduzimamo 1

        if (hitSprites[spriteIndex]!=null) // ako postoji veza izmedu bloka i ostecenog bloka prilikom udara ulazi u if i mijenja iz neostecene u ostecenu ako ne postoji ne ulazi i ne mijenja se tako dugo dok se blok ili ne unisti ili ne nade vezu za sljedeci blok koji je vise ostecen
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing"); // baca error ako nismo postavili sprite izgleda za brick dok ga lopta udari 
        }
        
    }

    // TO DO
    // remove this metod once we acctualy win
    void SimulateWin() {
        levelManager.LoadNextLevel();
    }
}

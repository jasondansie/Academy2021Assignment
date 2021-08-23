using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    public GameObject destroyEffect;
    public GameObject starPickup;

    public AudioSource audioSource;

    public AudioClip defeatClip;
    public AudioClip plopClip;
    public AudioClip blingclip;
    public AudioClip bling002Clip;


    public float volume = 1.5f;
    public float velocity = 3;

    Vector3 pos;

    private GameObject gameManager;
   

    private Rigidbody2D rb;

    private Vector3 newPosition;
    public Vector3 topmiddleWorld;
    public Vector3 topmiddleWorld2;

    private Color[] randColor;

    private bool isRunning = false;
    private bool rotatorHit = false;
    private bool startCore = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager"); // gets reference to the gamemanager gameobject
       
        GetComponent<SpriteRenderer>().color = gameManager.GetComponent<GM>().getRandColor(); // picks a random color from array and assignes it

        topmiddleWorld = gameManager.GetComponent<GM>().topmiddleWorld;
        

        startCore = gameManager.GetComponent<GM>().startCore; //gets a reference to the color arry 

        // 
        Time.timeScale = 0; // pauses the game at the beginning
    }

    // Update is called once per frame
    void Update()
    {
        topmiddleWorld2 = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, Camera.main.nearClipPlane));

        pos = Camera.main.WorldToViewportPoint(transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            
            if (!isRunning)
            {
                Time.timeScale = 1; // restart the game 
                isRunning = true;
            }          

            rb.velocity = Vector2.up * velocity;
            audioSource.PlayOneShot(bling002Clip, 0.5f);
        }      

        if (pos.y < 0.02) {
            gameManager.GetComponent<GM>().startCore = true; // lets game manager know to start core routing to end game
            audioSource.PlayOneShot(defeatClip, 2f);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);         
        }           
    }

     void OnTriggerEnter2D(Collider2D collision)
    {          
        if (collision.tag != "Star" && collision.tag != "ColorSwitcher" && collision.tag != "RotationPoint")
        {
            if (gameObject.GetComponent<SpriteRenderer>().color != collision.GetComponent<SpriteRenderer>().color)
            {
                gameManager.GetComponent<GM>().startCore = true; // lets gamemanager know to start core routing to end game
                audioSource.PlayOneShot(defeatClip, 2f);
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);             
            }
        }

        if (collision.tag == "ColorSwitcher")
        {
            Debug.Log("top point: " + topmiddleWorld);
            Debug.Log("top point2: " + topmiddleWorld2);

           // gameManager.GetComponent<GM>().spawnCircle(topmiddleWorld2.y); //has a problem it used the first spawned rotation point could not figure out how to change it

            GetComponent<SpriteRenderer>().color = gameManager.GetComponent<GM>().getRandColor(); // picks a random color and assignes it
            audioSource.PlayOneShot(plopClip, 1f);

            gameManager.GetComponent<GM>().spawnColorSwitcher();
            Destroy(collision.gameObject);
        }

        if (collision.tag == "RotationPoint")
        {
            Debug.Log("rotation hit");
            if (!rotatorHit)
            {
                rotatorHit = true;
                gameManager.GetComponent<GM>().spawnColorSwitcher();
            }
            
        }

        if (collision.tag == "Star")
        {
         
            audioSource.PlayOneShot(blingclip, 1f);

            Instantiate(starPickup, transform.position, Quaternion.identity);

            gameManager.GetComponent<GM>().score += 1; // increments the score in the gamemanager

            Destroy(collision.gameObject);
        }
    }
}

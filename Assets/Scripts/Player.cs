using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 3;
    public GameObject destroyEffect;
    public GameObject starPickup;

    public AudioSource audioSource;

    public AudioClip defeatClip;
    public AudioClip plopClip;
    public AudioClip blingclip;
    public AudioClip bling002Clip;


    public float volume = 1.5f;

    private GameObject gameManager;
   

    private Rigidbody2D rb;
    private Vector3 newPosition;
    private Color[] randColor;
    private bool isRunning = false;

    private bool startCore;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager"); // gets reference to the gamemanager gameobject
                                                      // 
        

        randColor = gameManager.GetComponent<GM>().colors2; //gets a reference to the color arry 
        GetComponent<SpriteRenderer>().color = randColor[Random.Range(0, randColor.Length)]; // picks a random color from array and assignes it

        startCore = gameManager.GetComponent<GM>().startCore; //gets a reference to the color arry 

        // 
        Time.timeScale = 0; // pauses the game at the beginning
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = new Vector3(0, gameManager.GetComponent<GM>().myScreenPos.y, 0);

        if (Input.GetMouseButtonDown(0))
        {
            if (!isRunning)
            {
                Time.timeScale = 1; // restart the game 
                isRunning = true;
            }
            Debug.Log("currentPos: " + transform.position);

            Debug.Log("newPosition: " + newPosition);           

            rb.velocity = Vector2.up * velocity;
            audioSource.PlayOneShot(bling002Clip, 0.5f);
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.y < 0.02) {
            gameManager.GetComponent<GM>().startCore = true;
            audioSource.PlayOneShot(defeatClip, 2f);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
           
        }

       
            
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("my color" + gameObject.GetComponent<SpriteRenderer>().color);
        

        if (collision.tag != "Star" && collision.tag != "ColorSwitcher")
        {
            if (gameObject.GetComponent<SpriteRenderer>().color != collision.GetComponent<SpriteRenderer>().color)
            {
                gameManager.GetComponent<GM>().startCore = true;
                audioSource.PlayOneShot(defeatClip, 2f);
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                

            }

        }

        if (collision.tag == "ColorSwitcher")
        {
            GetComponent<SpriteRenderer>().color = randColor[Random.Range(0, randColor.Length)]; // picks a random color from array and assignes it
            audioSource.PlayOneShot(plopClip, 1f);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Star")
        {
            audioSource.PlayOneShot(blingclip, 1f);

            Instantiate(starPickup, transform.position, Quaternion.identity);

            gameManager.GetComponent<GM>().score += 1;
            gameManager.GetComponent<GM>().spawnStar(new Vector3(0, 15f, 0));

            Destroy(collision.gameObject);
        }
    }
}

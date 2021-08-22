using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 3;
    public GameObject destroyEffect;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1.5f;

    private GameObject gameManager;

    private Rigidbody2D rb;
    private Vector3 newPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager"); // gets reference to the gamemanager gameobject

        
        Color[] randColor2 = gameManager.GetComponent<GM>().colors2; //gets a reference to the color arry 

        GetComponent<SpriteRenderer>().color = randColor2[Random.Range(0, randColor2.Length)]; // picks a random color from array and assignes it
       

    }

    // Update is called once per frame
    void Update()
    {
        newPosition = new Vector3(0, gameManager.GetComponent<GM>().myScreenPos.y, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("currentPos: " + transform.position);

            Debug.Log("newPosition: " + newPosition);           

            rb.velocity = Vector2.up * velocity;
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.y < 0.02) {           
            audioSource.PlayOneShot(clip, volume);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }       
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("my color" + gameObject.GetComponent<SpriteRenderer>().color);
        Debug.Log("circle color" + collision.GetComponent<SpriteRenderer>().color);
        Debug.Log(collision.gameObject.name + " : " + gameObject.name);

        if (collision.tag != "Star")
        {
            if (gameObject.GetComponent<SpriteRenderer>().color != collision.GetComponent<SpriteRenderer>().color)
            {
                Debug.Log("Blowing up now");
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }      
    }     
 }

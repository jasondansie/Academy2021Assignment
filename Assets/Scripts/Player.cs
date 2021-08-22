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

        GetComponent<Renderer>().material.color = randColor2[Random.Range(1, randColor2.Length - 1)]; // picks a random color from array and assignes it
       

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
            Debug.Log("I am below the camera's view.");
            audioSource.PlayOneShot(clip, volume);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        

    }

    /*
    void OnBecameInvisible()
    {
       
        if (rb.position.y < (newPosition.y - (-15.9))) // so the player death only happens at the bottom
        {
            audioSource.PlayOneShot(clip, volume);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
      

      
    }

    */
}

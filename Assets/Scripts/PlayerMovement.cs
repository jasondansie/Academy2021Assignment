using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity = 3;
    public GameObject destroyEffect;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1.5f;

   //public Camera cam;

    public GameObject gameManager;

    private Rigidbody2D rb;

    

    Vector3 newPosition;


    // Start is called before the first frame update
    void Start()
    {      
        rb = GetComponent<Rigidbody2D>();

        newPosition = gameManager.GetComponent<GM>().cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("currentPos: " + transform.position);
            rb.velocity = Vector2.up * velocity;
        }      
    }

    
    void OnBecameInvisible()
    {
        if (rb.position.y < (newPosition.y  - (-4.9))) // so the player death only happens at the bottom
        {
            audioSource.PlayOneShot(clip, volume);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);         
            Destroy(gameObject);          
        }     
    }
}

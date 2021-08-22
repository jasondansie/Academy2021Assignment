using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public GameObject newStar;
    public GameObject destroyEffect;
    public AudioSource audioSource;


    public AudioClip clip;
    public float volume = 0.5f;


    private GameObject gameManager;
   



     void Start()
    {
        gameManager = GameObject.Find("GameManager");
        // audioSource = GetComponent<AudioSource>(); ;
       //  audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
         
       
    }  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);

        /*
        audioSource.PlayOneShot(clip, volume);
        //audioSource.Play();
        gameManager.GetComponent<GM>().score += 1;
        */
        Destroy(gameObject);

        respawn();
        
    }

    private void respawn()
    {
        int randNum = Random.Range(1, 11);

        if (randNum%2 == 0)
        {
            //Instantiate(newStar, new Vector3(0, 0.41f, 0), Quaternion.identity);
        }
        Instantiate(newStar, new Vector3(0, 0.41f, 0), Quaternion.identity);

        newStar.GetComponent<CircleCollider2D>().enabled = true;
    }
}

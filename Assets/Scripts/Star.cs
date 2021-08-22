using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public GameObject destroyEffect;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    public GameObject gameManager;


    // Update is called once per frame
    void Update()
    {
         
       
    }  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(clip, volume);
        gameManager.GetComponent<GM>().score += 1;
        Destroy(gameObject);
        
    }
}

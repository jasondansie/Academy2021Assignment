using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroy : MonoBehaviour
{
    public GameObject newStar;
    public GameObject destroyEffect;

    public AudioClip clip;
    public float volume = 0.5f;




    private GameObject gameManager;
    private AudioSource Staraudio;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        Staraudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);

        Staraudio.PlayOneShot(clip);

        gameManager.GetComponent<GM>().score += 1;
        /*
        audioSource.PlayOneShot(clip, volume);
        //audioSource.Play();
        
        */
        Destroy(gameObject);
      
        gameManager.GetComponent<GM>().respawn(new Vector3(0, 15f, 0));

    }

}

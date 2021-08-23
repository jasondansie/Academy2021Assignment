using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroy : MonoBehaviour
{
    public GameObject destroyEffect;

    private GameObject gameManager;
    


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}

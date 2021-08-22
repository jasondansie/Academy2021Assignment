using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreater : MonoBehaviour
{

    public GameObject gameManager;

    public GameObject target;

    Color randColor;

    private Color[] colors = new Color[] { new Color(15.7f, 86.7f, 0), new Color(100f, 24.37f, 22.4f), new Color(39.6f, 100f, 46.2f), new Color(71.8f, 0.0f, 89.8f), new Color(15.7f, 86.7f, 0), new Color(100f, 24.37f, 22.4f), new Color(39.6f, 100f, 46.2f), new Color(71.8f, 0.0f, 89.8f) };

    private Color[] colors2 = new Color[] {Color.red, Color.green, Color.blue, Color.magenta, Color.yellow, Color.red, Color.green, Color.blue, Color.magenta, Color.yellow };


    // Start is called before the first frame update
    void Start()
    {   
        GetComponent<Renderer>().material.color = colors2[Random.Range(1, colors2.Length -1)];
    }

    // Update is called once per frame
    void Update()
    {      
        // Spin the object around the target at 20 degrees/second.
        transform.RotateAround(target.transform.position, Vector3.forward, 60 * Time.deltaTime);
    }

  
}

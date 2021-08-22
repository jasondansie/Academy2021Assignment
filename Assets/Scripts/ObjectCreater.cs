using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreater : MonoBehaviour
{

    public GameObject gameManager;

    public GameObject target;

    Color randColor;

    private Color[] colors = new Color[] { new Color(15.7f, 86.7f, 0), new Color(100f, 24.37f, 22.4f), new Color(39.6f, 100f, 46.2f), new Color(71.8f, 0.0f, 89.8f) };



    // Start is called before the first frame update
    void Start()
    {
        // Color randColor = gameManager.GetComponent<GM>().pickColor();

        System.Random rnd = new System.Random();
        int randNum = rnd.Next(0, 4);

        Debug.Log("random: " + randNum);
        randColor = pickColor(randNum);
    }

    // Update is called once per frame
    void Update()
    {
       

        GetComponent<Renderer>().material.color = new Color(randColor.r, randColor.g, randColor.b); //C sharp

        // Spin the object around the target at 20 degrees/second.
        transform.RotateAround(target.transform.position, Vector3.forward, 60 * Time.deltaTime);
    }

    public Color pickColor(int rndN)
    {

        Color color;
       
        return color = colors[rndN];
    }
}

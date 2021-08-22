
using UnityEngine;

public class GM : MonoBehaviour
{
    public Camera cam;
    public int score = 0;

    public GameObject newStar;
    public GameObject circleTopLeft;
    public GameObject circleTopRight;
    public GameObject circleBottomLeft;
    public GameObject circleBottomRight;
    public GameObject rotationPoint;
    public GameObject scoreText;

    public Vector3 myScreenPos;


    
    public Color[] colors2 = new Color[] { Color.red, Color.green, Color.blue, Color.magenta};

    private void Start()
    {
        spawnStar(new Vector3(0,6.41f,0));
        spawnCircle();
    }

    private void Update()
    {
        myScreenPos =Camera.main.WorldToViewportPoint(transform.position);
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }

    private void spawnCircle()
    {
        spawnPrefab(circleTopLeft, new Vector3(-2.23f, 8.76f, 0), Quaternion.Euler(0, 0, 0)); //top left
        spawnPrefab(circleTopRight, new Vector3(2.36f, 8.76f, 0), Quaternion.Euler(0, 0, 270)); //top right
        spawnPrefab(circleBottomLeft, new Vector3(-2.23f, 3.94f, 0), Quaternion.Euler(0, 0, 90)); //bottom left
        spawnPrefab(circleBottomRight, new Vector3(2.26f, 3.94f, 0), Quaternion.Euler(0, 0, 180)); //bottom right
        spawnPrefab(rotationPoint, new Vector3(-0.02f, 6.41f, 0), Quaternion.identity); //rotation point

    }

    public void spawnStar(Vector3 spawnPoint)
    {
        spawnPrefab(newStar, spawnPoint, Quaternion.identity);
    }

    private void spawnPrefab(GameObject prefab , Vector3 spawnPoint, Quaternion rotation)
    {     
        Instantiate(prefab, spawnPoint, rotation);
    }

}

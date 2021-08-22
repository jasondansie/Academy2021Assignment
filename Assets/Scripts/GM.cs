
using UnityEngine;

public class GM : MonoBehaviour
{
    public Camera cam;
    public int score = 0;

    public GameObject newStar;
    public GameObject newArc;
    public GameObject rotationPoint;
    public GameObject scoreText;

    public Vector3 myScreenPos;

  

    private float circleRightTopX = 2.3f;
    private float circleRightBottomX = -2.23f;
    private float circleLefttopX = -2.23f;
    private float circleLeftBottomX = -2.23f;

    
    public Color[] colors2 = new Color[] { Color.red, Color.green, Color.blue, Color.magenta};

    private void Start()
    {
        spawnStar(new Vector3(0,6.41f,0));
    }

    private void Update()
    {
        myScreenPos =Camera.main.WorldToViewportPoint(transform.position);
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }

    private void spawnCircle()
    {
        spawnPrefab(newArc, new Vector3(-2.23f, 8.76f, 0)); //top left
        spawnPrefab(newArc, new Vector3(2.36f, 8.76f, 180)); //top right
        spawnPrefab(newArc, new Vector3(-2.23f, 3.94f, 0)); //bottom left
        spawnPrefab(newArc, new Vector3(2.26f, 3.94f, 0)); //bottom right
        spawnPrefab(rotationPoint, new Vector3(-0.02f, 6.41f, 0)); //bottom right

    }

    private void spawnStar(Vector3 spawnPoint)
    {
        spawnPrefab(newStar, spawnPoint);
    }

    public void spawnPrefab(GameObject prefab , Vector3 spawnPoint)
    {     
        Instantiate(prefab, spawnPoint, Quaternion.identity);
    }

}

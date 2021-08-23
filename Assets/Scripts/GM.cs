using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject gameOverText;
    public GameObject clickToStartText;

    public bool gameRestart = false;
    public bool startCore = false;

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

        if (startCore == true)
        {
            StartCoroutine(gameEndTimer());
        }

        if (Input.GetMouseButtonDown(0) && gameRestart == true)
        {
            Debug.Log("loading level");
            SceneManager.LoadScene(0);
        }
    }

    private void spawnCircle()
    {
        spawnPrefab(circleTopLeft, new Vector3(-2.5f, 8.76f, 0), Quaternion.Euler(0, 0, 0)); //top left
        spawnPrefab(circleTopRight, new Vector3(2.5f, 8.76f, 0), Quaternion.Euler(0, 0, 270)); //top right
        spawnPrefab(circleBottomLeft, new Vector3(-2.5f, 3.94f, 0), Quaternion.Euler(0, 0, 90)); //bottom left
        spawnPrefab(circleBottomRight, new Vector3(2.5f, 3.94f, 0), Quaternion.Euler(0, 0, 180)); //bottom right
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

    public IEnumerator gameEndTimer()
    {
        startCore = false;
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        Time.timeScale = 0; // pauses the game at the end
        gameOverText.gameObject.SetActive(true);
        clickToStartText.gameObject.SetActive(true);
        gameRestart = true;  
    }

}

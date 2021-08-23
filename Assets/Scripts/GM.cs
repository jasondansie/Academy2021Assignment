using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public Camera cam;
    public int score = 0;

    public GameObject newStar;
    public GameObject newColorSwitcher;
    public GameObject circleTopLeft;
    public GameObject circleTopRight;
    public GameObject circleBottomLeft;
    public GameObject circleBottomRight;
    public GameObject rotationPoint2;
    public GameObject scoreText;
    public GameObject gameOverText;
    public GameObject clickToStartText;

    public bool gameRestart = false;
    public bool startCore = false;

    public Vector3 myScreenPos;
    public Vector3 topmiddleWorld;


    private void Start()
    {
        spawnStar(new Vector3(0,6.41f,0));
        spawnCircle(8.76f);
    }

    private void Update()
    {
        myScreenPos =Camera.main.WorldToViewportPoint(transform.position);
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
        topmiddleWorld = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, Camera.main.nearClipPlane));

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

    
    public void spawnCircle(float topY)
    {      
        spawnPrefab(circleTopLeft, new Vector3(-2.5f, topY, 0), Quaternion.Euler(0, 0, 0)); //top left
        spawnPrefab(circleTopRight, new Vector3(2.5f, topY, 0), Quaternion.Euler(0, 0, 270)); //top right
        spawnPrefab(circleBottomLeft, new Vector3(-2.5f, topY - 4.82f, 0), Quaternion.Euler(0, 0, 90)); //bottom left
        spawnPrefab(circleBottomRight, new Vector3(2.5f, topY - 4.82f, 0), Quaternion.Euler(0, 0, 180)); //bottom right
        spawnPrefab(rotationPoint2, new Vector3(-0.02f, (topY - 4.82f) + 2.47f, 0), Quaternion.identity); //rotation point
    }

    public void spawnStar(Vector3 spawnPoint)
    {
        spawnPrefab(newStar, spawnPoint, Quaternion.identity);
    }

    public void spawnColorSwitcher()
    {
        Debug.Log("spawning a switcher");
        spawnPrefab(newColorSwitcher, new Vector3(0, topmiddleWorld.y, 0), Quaternion.identity); //Spawns at the top in the middle
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

    public Color getRandColor()
    {
        Color color;
        int randNum = Random.Range(0, 3);

        switch (randNum)
        {
            case 0:
                color = Color.green;
                break;
            case 1:
                color = Color.blue;
                break;
            case 2:
                color = Color.red;
                break;
            case 3:
                color = Color.magenta;
                break;


            default:
                color = Color.magenta;
                break;
        }


        return color;
    }

}

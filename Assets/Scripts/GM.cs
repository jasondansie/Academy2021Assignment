
using UnityEngine;

public class GM : MonoBehaviour
{
    public Camera cam;
    public int score = 0;

    public GameObject scoreText;

    public Vector3 myScreenPos;

  

    private float circleRightTopX = 2.3f;
    private float circleRightBottomX = -2.23f;
    private float circleLefttopX = -2.23f;
    private float circleLeftBottomX = -2.23f;

    private Color[] colors = new Color[] { new Color(15.7f, 86.7f, 0), new Color(100f, 24.37f, 22.4f), new Color(39.6f, 100f, 46.2f), new Color(71.8f, 0.0f, 89.8f) };




    private void Update()
    {
        myScreenPos =Camera.main.WorldToViewportPoint(transform.position);
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }

    public Color pickColor() {

        Color color;
        System.Random rnd = new System.Random();
        int randNum = rnd.Next(1, 5);

        Debug.Log("random: " + randNum);
        return  color = colors[randNum];
    }
}

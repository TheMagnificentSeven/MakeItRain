using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MakeItRain : MonoBehaviour
{
    private int numObjects;
    private float minX = -4f;
    private float maxX = 4f;
    private GameObject rain;
    private GameObject rainClone;
    private int danceQuality; // 0 is worst, 3 is best
    float startTimer = 31;
    float timer;
    int level = 0;
    int score = 0;
    public Text timerText;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        UpdateScore();
        InitializeTimer();
        danceQuality = -1;
    }

    void Update()
    {
        UpdateTime();
    }

    // Controls Timer
    void UpdateTime()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            timerText.text = "TIMER : " + ((int) timer).ToString();
        }
        else {
            if (startTimer <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            }

            timerText.text = "TIMER : 0";
            timer = 0;
            danceQuality = 0;
            Rain();
        }
    }
    
    void UpdateScore()
    {
            scoreText.text = "SCORE : " + score.ToString();
    }

    // Rain also calls this
    void InitializeTimer()
    {
        timer = startTimer - level;
        UpdateTime();
    }
    
    // Called only when dance is finished or time is out
    public void Rain()
    {
        // Debug.Log(danceQuality);
     // figure out danceQuality depending on how much time timer has left
        if (danceQuality != 0)
        {
            danceQuality = (int) Mathf.Ceil(timer*3 / startTimer);
            score = score + level + (int) timer;
            UpdateScore();
            level++;
        }

        int value = 1;
        switch (danceQuality)
        {
            case 1:
                rain = GameObject.Find("Rain/Poor/" + value);
                break;
            case 2:
                rain = GameObject.Find("Rain/Fair/" + value);
                break;
            case 3: 
                rain = GameObject.Find("Rain/Good/" + value);
                break;
             default:
                rain = GameObject.Find("Rain/Bad/" + value);
                break;
        }

        // determine numObjects using object size!
        float width = rain.GetComponent<BoxCollider2D>().size.x;
        numObjects = (int) Mathf.Ceil(4.0f/width);
        for (int i = 0; i < numObjects; i++)
        {
            float x_rand = Random.Range(minX, maxX - width);
            float y_rand = Random.Range(1f, 3f);
            rainClone = (GameObject) Instantiate(rain, new Vector3(x_rand, rain.transform.position.y - y_rand, rain.transform.position.z), rain.transform.rotation);
            rainClone.GetComponent<Rigidbody2D>().gravityScale = 1;
            rainClone.GetComponent<RainWatcher>().setDmg((2 - danceQuality) * value);
            Collider2D rainCol = rainClone.GetComponent<BoxCollider2D>();
            Collider2D leftWall = GameObject.Find("LeftWall").GetComponent<BoxCollider2D>();
            Collider2D rightWall = GameObject.Find("RightWall").GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(rainCol, leftWall, true);
            Physics2D.IgnoreCollision(rainCol, rightWall, true);
        }

        // Restart
        danceQuality = -1;
        InitializeTimer();
        Debug.Log(timer);
    }
}
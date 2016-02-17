using UnityEngine;
using UnityEngine.UI;

public class MakeItRain : MonoBehaviour
{
    private int numObjects;
    private float minX = -4f;
    private float maxX = 4f;
    private int danceQuality; // 0 is worst, 3 is best
    float startTimer = 31;
    float timer;
    int level = 0;
    public Text timerText;
    public Text scoreText;
    private bool continuouslyRaining = false;

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
            scoreText.text = "SCORE : " + ScoreManager.score.ToString();
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
            danceQuality = (int) Mathf.Ceil(timer*3/(startTimer - level));
            ScoreManager.score = ScoreManager.score + level + (int) timer;
            UpdateScore();
            level++;
        }

        GameObject[] rainArray;

        switch (danceQuality)
        {
            case 1:
                rainArray = GameObject.FindGameObjectsWithTag("Poor");
                break;
            case 2:
                rainArray = GameObject.FindGameObjectsWithTag("Fair");
                break;
            case 3: 
                rainArray = GameObject.FindGameObjectsWithTag("Good");
                break;
             default:
                rainArray = GameObject.FindGameObjectsWithTag("Bad");
                break;
        }

        // pick an object
        int randomNumber = Random.Range(0, rainArray.Length);
        GameObject rain = rainArray[randomNumber];

        // determine numObjects using object size!
        float width = rain.GetComponent<BoxCollider2D>().size.x;
        float damage = (float) rain.GetComponent<RainWatcher>().getDamage();
        numObjects = (int)Mathf.Ceil(20.0f / damage);
        if (width <= 0.5)
            numObjects = numObjects * 3;
        if (danceQuality == 3)
            numObjects = 10;
        else if (danceQuality == 2)
            numObjects = (int)Mathf.Ceil(6.0f / width);
        for (int i = 0; i < numObjects; i++)
        {
            spawnRainObject(rain, width);
        }

        // Restart
        danceQuality = -1;
        InitializeTimer();
        Debug.Log(timer);
    }

    private void spawnRainObject(GameObject rain, float width)
    {
        float x_rand = Random.Range(minX, maxX - width);
        float y_rand = Random.Range(1f, 3f);
        GameObject rainClone = (GameObject)Instantiate(rain, new Vector3(x_rand, rain.transform.position.y - y_rand, rain.transform.position.z), rain.transform.rotation);
        rainClone.GetComponent<Rigidbody2D>().gravityScale = 1;
        rainClone.GetComponent<RainWatcher>();
        rainClone.tag = "Untagged";
        Collider2D rainCol = rainClone.GetComponent<BoxCollider2D>();
        Collider2D leftWall = GameObject.Find("LeftWall").GetComponent<BoxCollider2D>();
        Collider2D rightWall = GameObject.Find("RightWall").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(rainCol, leftWall, true);
        Physics2D.IgnoreCollision(rainCol, rightWall, true);
    }

    private void rainRandomObject()
    {
        GameObject[] rainArray;

        switch (Random.Range(0, 4))
        {
            case 1:
                rainArray = GameObject.FindGameObjectsWithTag("Poor");
                break;
            case 2:
                rainArray = GameObject.FindGameObjectsWithTag("Fair");
                break;
            case 3:
                rainArray = GameObject.FindGameObjectsWithTag("Good");
                break;
            default:
                rainArray = GameObject.FindGameObjectsWithTag("Bad");
                break;
        }
        int randomNumber = Random.Range(0, rainArray.Length);
        GameObject rain = rainArray[randomNumber];
        
        float width = rain.GetComponent<BoxCollider2D>().size.x;
        spawnRainObject(rain, width);
    }

    public void continuousRain()
    {
        if (!continuouslyRaining)
        {
            InvokeRepeating("rainRandomObject", 1, 1);
            continuouslyRaining = true;
        }
    }
}
using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static int score = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }


}

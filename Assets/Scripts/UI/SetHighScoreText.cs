using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetHighScoreText : MonoBehaviour
{
    public static SetHighScoreText Instance;
    private TMP_Text scoreText;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        scoreText = gameObject.GetComponent<TMP_Text>();
        UpdateText();
    }

    // Update is called once per frame
    public void UpdateText()
    {
        //scoreText.text = "High Score: " + GameSettings.highScore.ToString();
        scoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
}

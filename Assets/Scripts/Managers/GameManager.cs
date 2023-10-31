using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public bool isPaused;
    public static GameManager instance;
    public float score;
    public List<GameObject> activeFishes = new List<GameObject>();
    public float timeRemaining = 10; 
    public float maxTime;

    public GameObject player;
    public GameObject TitleUI;
    public GameObject GameplayUI;
    // Start is called before the first frame update
    void Awake()
    {
        timeRemaining = maxTime;
        gameState = GameState.mainmenu;
        if(instance == null)
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && gameState == GameState.gameplay)
        {
            timeRemaining -= Time.deltaTime;
        }

        if(timeRemaining <= 0)
        {
            GameFinish();
        }
    }

    public void StartGame()
    {
        gameState = GameState.gameplay;
        timeRemaining = maxTime;
        player.SetActive(true);
        player.transform.position = Vector3.zero;
        //player = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);
    }

    public void GameFinish()
    {
        gameState = GameState.gameover;
        foreach(GameObject fish in activeFishes)
        {
            Destroy(fish); 
        }

        activeFishes.Clear();
        GameplayUI.SetActive(false);
        TitleUI.SetActive(true);
        player.SetActive(false);

        if(score > GameSettings.highScore){ //if our score is better than the high score it overwrites it
            //GameSettings.highScore = score;
            PlayerPrefs.SetInt("HighScore", Mathf.FloorToInt(score));
            SetHighScoreText.Instance.UpdateText();
        }
    }
}

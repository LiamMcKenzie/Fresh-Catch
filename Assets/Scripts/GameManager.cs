using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public static GameManager instance;
    public int score;
    public List<GameObject> activeFishes = new List<GameObject>();
    public float timeRemaining = 10; 
    // public enum GameState
    // {
    //     mainmenu,
    //     gameplay,
    //     gameover,
    //     catching
    // }
    // Start is called before the first frame update
    void Awake()
    {
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
    }

    public void StartGame()
    {
        gameState = GameState.gameplay;
    }
}

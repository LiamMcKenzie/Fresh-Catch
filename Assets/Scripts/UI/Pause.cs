using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void PauseGame ()
    {
        GameManager.instance.isPaused = true;
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        GameManager.instance.isPaused = false;
        Time.timeScale = 1;
    }
}

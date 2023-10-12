using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public AudioClip ding;
    public AudioClip dingHurry;
    public AudioClip finish;
    AudioSource audioSource;
    int beepsLeft = 10;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float roundUp = Mathf.Ceil (GameManager.instance.timeRemaining);

        if(roundUp == beepsLeft){
            beepsLeft--;
            if(roundUp > 5){
                audioSource.PlayOneShot(ding);
            }
            else if (roundUp > 0)
            {
                audioSource.PlayOneShot(dingHurry, 0.5f);
            }
            else if (roundUp == 0)
            {
                audioSource.PlayOneShot(finish, 0.5f);
                GameManager.instance.gameState = GameState.gameover;
            }
            
            //Debug.Log(roundUp + "," + beepsLeft);  
            
        }
    }
}

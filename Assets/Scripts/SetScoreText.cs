using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScoreText : MonoBehaviour
{
    private TMP_Text scoreText;

    void Start()
    {
        scoreText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString();
    }
}

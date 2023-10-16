using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTimerText : MonoBehaviour
{
    private TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        float roundUp = Mathf.Ceil (GameManager.instance.timeRemaining);
        timerText.text = roundUp.ToString();
        timerText.enabled = (roundUp > 10);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SetCountdownText : MonoBehaviour
{
    private TMP_Text scoreText;

    private Vector3 _originalScale;
    private Vector3 _scaleTo;
    private int valuesLeft = 10;

    void Start()
    {
        scoreText = gameObject.GetComponent<TMP_Text>();

        _originalScale = transform.localScale;
        _scaleTo = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float roundUp = Mathf.Ceil (GameManager.instance.timeRemaining);
        scoreText.text = roundUp.ToString();
        scoreText.enabled = (roundUp <= 10);

        if(roundUp == valuesLeft){
            valuesLeft--;
            OnScale();
        }
    }

    private void OnScale()
    {
        transform.localScale = _originalScale;
        transform.DOScale(_scaleTo, 0.75f).SetEase(Ease.InCubic);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public float fadeTime = 1f;

    public RectTransform rectTransform;

    public void PanelFadeIn()
    {
        //rectTransform.DOScale(0,1).SetEase( Ease.InBounce );
        rectTransform.transform.localPosition = new Vector3(0f, -2000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutSine);
    }

    public void PanelFadeOut()
    {
        //RectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        //DOTweenModuleUI.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingManager : MonoBehaviour
{
    public static CatchingManager instance;
    public List<GameObject> fishes = new List<GameObject>();
    Animator camAnimator;
    Animator rodAnimator;
    public GameObject fishingRod;



    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        camAnimator = Camera.main.GetComponent<Animator>();
        rodAnimator = fishingRod.GetComponent<Animator>();
    }

    void Start()
    {
        rodAnimator.enabled = false;
    }

    void Update()
    {
        if(SwipeDetect.instance.isSwipingUp && fishes.Count != 0 && camAnimator.GetBool("Catching") == false)
        {
            rodAnimator.enabled = true;
            camAnimator.SetBool("Catching", true);
            camAnimator.SetTrigger("LookUp");

            rodAnimator.SetTrigger("Catch");

        }

    }
}

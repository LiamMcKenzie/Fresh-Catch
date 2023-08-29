using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingManager : MonoBehaviour
{
    public static CatchingManager instance;
    public List<GameObject> fishes = new List<GameObject>();
    Animator camAnimator;
    Animator rodAnimator;
    Animator fishAnimator;
    DragObject rodMovement;
    public GameObject fishingRod;

    public GameObject fish;



    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        camAnimator = Camera.main.GetComponent<Animator>();
        rodAnimator = fishingRod.GetComponent<Animator>();
        fishAnimator = fish.GetComponent<Animator>();
        rodMovement = fishingRod.GetComponent<DragObject>();
    }

    void Start()
    {
        rodAnimator.enabled = false;
    }

    void Update()
    {
        if(SwipeDetect.instance.isSwipingUp && fishes.Count != 0 && camAnimator.GetBool("Catching") == false)
        {
            StartCoroutine(Catching());
            //rodAnimator.enabled = true;
            //rodMovement.enabled = false;
            //camAnimator.SetBool("Catching", true);
            //camAnimator.SetTrigger("LookUp");

            //rodAnimator.SetTrigger("Catch");
            //fishAnimator.SetTrigger("LookUp");
        }

        if(camAnimator.GetBool("Catching") == false)
        {
            rodAnimator.enabled = false;
            rodMovement.enabled = true;
        }

    }

    //StartCoroutine(SendRequest());
    private IEnumerator Catching(){
        rodAnimator.enabled = true;
        rodMovement.enabled = false;
        camAnimator.SetBool("Catching", true);

        camAnimator.SetTrigger("LookUp");
        rodAnimator.SetTrigger("Catch");
        
        yield return new WaitForSeconds(1);
        fishAnimator.SetTrigger("LookUp");
        Debug.Log("hi");
        yield return new WaitForSeconds(4);
        Debug.Log("look down");
        camAnimator.SetTrigger("LookDown");
    }
}

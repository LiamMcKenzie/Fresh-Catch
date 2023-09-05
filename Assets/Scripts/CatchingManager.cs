using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingManager : MonoBehaviour
{
    public static CatchingManager instance;
    public List<GameObject> fishes = new List<GameObject>();
    Animator camAnimator;
    Animator rodAnimator;
    Animator uiFishAnimator;
    Animator bobberAnimator;

    DragObject rodMovement;
    
    MoveToPosition bobberMovement;

    public GameObject fishingRod;
    public GameObject bobber;

    public GameObject uiFish;



    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        camAnimator = Camera.main.GetComponent<Animator>();
        rodAnimator = fishingRod.GetComponent<Animator>();
        uiFishAnimator = uiFish.GetComponent<Animator>();
        bobberAnimator = bobber.GetComponent<Animator>();

        rodMovement = fishingRod.GetComponent<DragObject>();
        bobberMovement = bobber.GetComponent<MoveToPosition>();
    }

    void Update()
    {
        if(SwipeDetect.instance.isSwipingUp && fishes.Count != 0 && camAnimator.GetBool("Catching") == false)
        {
            StartCoroutine(Catching());
            Debug.Log(fishes[0].GetComponent<FishMovement>().fish.name);
            fishes.RemoveAt(0);
            //rodAnimator.enabled = true;
            //rodMovement.enabled = false;
            //camAnimator.SetBool("Catching", true);
            //camAnimator.SetTrigger("LookUp");

            //rodAnimator.SetTrigger("Catch");
            //fishAnimator.SetTrigger("LookUp");
        }

        if(camAnimator.GetBool("Catching") == false)
        {
            bobberAnimator.enabled = false;
            bobberMovement.enabled = true;

            rodAnimator.enabled = false;
            rodMovement.enabled = true;

        }

    }

    //StartCoroutine(SendRequest());
    private IEnumerator Catching(){
        camAnimator.SetBool("Catching", true);

        bobberAnimator.enabled = true;
        //bobberMovement.enabled = false;

        rodAnimator.enabled = true;
        rodMovement.enabled = false;


        bobberAnimator.SetTrigger("Catch");

        rodAnimator.SetTrigger("Catch");

        yield return new WaitForSeconds(0.1f);

        camAnimator.SetTrigger("LookUp");
        
        yield return new WaitForSeconds(1);
        uiFishAnimator.SetTrigger("LookUp");
        yield return new WaitForSeconds(4);
        uiFishAnimator.SetTrigger("LookDown");
        camAnimator.SetTrigger("LookDown");
        camAnimator.SetBool("Catching", false);
    }
}

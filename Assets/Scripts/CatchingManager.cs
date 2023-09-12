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

            bobber.SetActive(true);

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
        bobber.SetActive(false);
        for(int i = 0; i < fishes.Count; i++)
        {
            fishes[i].GetComponent<FishMovement>().playerInFov = false;
        }

        uiFishAnimator.SetTrigger("LookUp");
        GameManager.instance.score += fishes[0].GetComponent<FishMovement>().fish.score;
        GameManager.instance.activeFishes.Remove(fishes[0]);
        Destroy(fishes[0]);
        fishes.Clear();
        
        yield return new WaitForSeconds(4);
        //fishes.RemoveAt(0);
        
        uiFishAnimator.SetTrigger("LookDown");
        camAnimator.SetTrigger("LookDown");
        yield return new WaitForSeconds(1);
        bobberAnimator.SetTrigger("Cast");
        yield return new WaitForSeconds(1);
        for(int i = 0; i < fishes.Count; i++)
        {
            fishes[i].GetComponent<FishMovement>().bobber = GameObject.Find("Bobber");
        }
        camAnimator.SetBool("Catching", false);
    }
}

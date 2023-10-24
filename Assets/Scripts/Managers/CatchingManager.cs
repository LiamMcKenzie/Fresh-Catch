using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingManager : MonoBehaviour
{
    public static CatchingManager instance;
    public List<GameObject> fishes = new List<GameObject>();
    //Animator camAnimator;
    //Animator rodAnimator;
    //Animator uiFishAnimator;
    //Animator bobberAnimator;

    DragObject rodMovement;
    
    MoveToPosition bobberMovement;

    public GameObject fishingRod;
    public GameObject bobber;

    public GameObject uiFish;
    public GameObject caughtFish;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        //camAnimator = Camera.main.GetComponent<Animator>();
        //rodAnimator = fishingRod.GetComponent<Animator>();
        //uiFishAnimator = uiFish.GetComponent<Animator>();
        //bobberAnimator = bobber.GetComponent<Animator>();

        rodMovement = fishingRod.GetComponent<DragObject>();
        bobberMovement = bobber.GetComponent<MoveToPosition>();
    }

    void Update()
    {
        if(SwipeDetect.instance.isSwipingUp && fishes.Count != 0 && GameManager.instance.gameState != GameState.catching)
        {
            StartCoroutine(Catching());

            
            
            
            //rodAnimator.enabled = true;
            //rodMovement.enabled = false;
            //camAnimator.SetBool("Catching", true);
            //camAnimator.SetTrigger("LookUp");

            //rodAnimator.SetTrigger("Catch");
            //fishAnimator.SetTrigger("LookUp");
        }

        if(GameManager.instance.gameState != GameState.catching)
        {
            //bobberAnimator.enabled = false;
            bobberMovement.enabled = true;

            //rodAnimator.enabled = false;
            rodMovement.enabled = true;

            bobber.SetActive(true);

        }

    }

    //StartCoroutine(SendRequest());
    private IEnumerator Catching(){
        GameManager.instance.gameState = GameState.catching;
        caughtFish = fishes[0];
        fishes.Clear();

        rodMovement.enabled = false;


        yield return new WaitForSeconds(0.1f);
        Camera.main.GetComponent<CameraSwitcher>().SwitchPriority(1);

        
        yield return new WaitForSeconds(1);
        bobber.SetActive(false);

        GameManager.instance.score += caughtFish.GetComponent<FishMovement>().newScore;
        
        yield return new WaitForSeconds(2);
        Camera.main.GetComponent<CameraSwitcher>().SwitchPriority(0);

        yield return new WaitForSeconds(1);

        GameManager.instance.gameState = GameState.gameplay;
    }

    private IEnumerator CatchingOLD(){
        GameManager.instance.gameState = GameState.catching;
        caughtFish = fishes[0];
        fishes.Clear();
        //bobberAnimator.enabled = true;
        //bobberMovement.enabled = false;

        //rodAnimator.enabled = true;
        rodMovement.enabled = false;


        //bobberAnimator.SetTrigger("Catch");

        //rodAnimator.SetTrigger("Catch");

        yield return new WaitForSeconds(0.1f);
        Camera.main.GetComponent<CameraSwitcher>().SwitchPriority(1);
        //camAnimator.SetTrigger("LookUp");
        
        yield return new WaitForSeconds(1);
        bobber.SetActive(false);
        /*
        for(int i = 0; i < fishes.Count; i++)
        {
            fishes[i].GetComponent<FishMovement>().playerInFov = false;
        }*/

        //uiFishAnimator.SetTrigger("LookUp");
        GameManager.instance.score += caughtFish.GetComponent<FishMovement>().newScore;
        //GameManager.instance.activeFishes.Remove(fishes[0]);
        //Destroy(fishes[0]);
        //fishes.Clear();
        
        yield return new WaitForSeconds(4);
        //fishes.RemoveAt(0);
        
        //uiFishAnimator.SetTrigger("LookDown");

        //camAnimator.SetTrigger("LookDown");
        Camera.main.GetComponent<CameraSwitcher>().SwitchPriority(0);

        yield return new WaitForSeconds(1);

        //bobberAnimator.SetTrigger("Cast");

        yield return new WaitForSeconds(1);
        /*
        for(int i = 0; i < fishes.Count; i++)
        {
            fishes[i].GetComponent<FishMovement>().bobber = GameObject.Find("Bobber");
        }*/
        
        //camAnimator.SetBool("Catching", false);
        GameManager.instance.gameState = GameState.gameplay;
    }
}

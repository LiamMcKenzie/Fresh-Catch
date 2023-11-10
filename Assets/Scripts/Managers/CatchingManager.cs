using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public TMP_Text fishName;
    public TMP_Text fishDescription;
    public TMP_Text gainedPoints;

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

        ClearText();
        rodMovement = fishingRod.GetComponent<DragObject>();
        bobberMovement = bobber.GetComponent<MoveToPosition>();
    }

    void Update()
    {
        if(SwipeDetect.instance.isSwipingUp && fishes.Count != 0 && GameManager.instance.gameState != GameState.catching)
        {
            StartCoroutine(Catching());
        }

        if(GameManager.instance.gameState != GameState.catching)
        {
            bobberMovement.enabled = true;

            rodMovement.enabled = true;

            bobber.SetActive(true);

        }

    }

    private IEnumerator Catching(){
        GameManager.instance.gameState = GameState.catching;
        bobber.SetActive(false);
        caughtFish = fishes[0];

        rodMovement.enabled = false;
        FishMovement fishScript = caughtFish.GetComponent<FishMovement>();

        yield return new WaitForSeconds(0.1f);
        Camera.main.GetComponent<CameraSwitcher>().SwitchPriority(1);
        caughtFish.GetComponent<FishCaught>().StartLerp();
        fishScript.enabled = false;
        fishes.Clear();
        UpdateText(fishScript);
        yield return new WaitForSeconds(1);

        GameManager.instance.score += fishScript.newScore;
        //Debug.Log(GameManager.instance.score + caughtFish.GetComponent<FishMovement>().newScore);
        
        yield return new WaitForSeconds(2);
        Camera.main.GetComponent<CameraSwitcher>().SwitchPriority(0);
        ClearText();
        fishes.Clear();


        yield return new WaitForSeconds(1);

        GameManager.instance.gameState = GameState.gameplay;
        GameManager.instance.activeFishes.Remove(caughtFish);
        Destroy(caughtFish);
        caughtFish = null;
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

    public void UpdateText(FishMovement fishScript)
    {
        fishName.text = fishScript.fish.name;
        fishDescription.text = fishScript.fish.description;
        gainedPoints.text = "+" + fishScript.newScore.ToString();
    }

    public void ClearText()
    {
        fishName.text = "";
        fishDescription.text = "";
        gainedPoints.text = "";
    }
}

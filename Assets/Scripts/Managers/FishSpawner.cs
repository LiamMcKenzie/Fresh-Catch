using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public float minimumXPos = -10;
    public float maximumXPos = 10;

    public float minimumZPos = 5f;
    public float maximumZPos = 30f;
    public GameObject fishPrefab;

    
    public int maxFish = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.activeFishes.Count < maxFish && GameManager.instance.gameState == GameState.gameplay)
        {
            SpawnFish();
        }
    }

    void SpawnFish()
    {

        Vector3 randomSpawnPosition = new Vector3(Random.Range(minimumXPos, maximumXPos), 1, Random.Range(minimumZPos, maximumZPos));
        GameObject newFish = Instantiate(fishPrefab, randomSpawnPosition, Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0)));
        GameManager.instance.activeFishes.Add(newFish);
        //newFish.GetComponent<FishMovement>().Fish;

        float randomSize = Random.Range(0, 3);
        float sizeModifier;
        switch (randomSize)
        {
        case 0:
            sizeModifier = 0.75f;
            break;

        default:
        case 1:
            sizeModifier = 1f;
            break;
        case 2:
            sizeModifier = 1.25f;
            break;
        }

        newFish.GetComponent<FishMovement>().fish.score *= sizeModifier;
        newFish.transform.localScale = new Vector3(newFish.transform.localScale.x * sizeModifier,newFish.transform.localScale.y * sizeModifier,newFish.transform.localScale.z * sizeModifier);
        Debug.Log(randomSize);
        Debug.Log(newFish.GetComponent<FishMovement>().fish.score);
    }
}

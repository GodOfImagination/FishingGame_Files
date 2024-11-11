using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> FishList = new List<GameObject>();   // Contains the different fishes that can be spawned.
    public List<Vector3> SpawnPoints = new List<Vector3>();      // Contains the different points that the fishes can be spawned at.

    public int RandomFish;                                       // The fish chosen to be summoned.
    public int RandomPoint;                                      // The spawn point chosen for the fish to be summoned at.

    void Start()
    {
        StartCoroutine(SpawnFish());
    }

    public void FishCaught()
    {
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        RandomFish = Random.Range(0, FishList.Count);
        RandomPoint = Random.Range(0, SpawnPoints.Count);

        yield return new WaitForSeconds(10f);

        Instantiate(FishList[RandomFish], SpawnPoints[RandomPoint], Quaternion.identity);
    }
}

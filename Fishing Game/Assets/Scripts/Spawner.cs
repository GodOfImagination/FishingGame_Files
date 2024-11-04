using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Fish;

    public void FishCaught()
    {
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        yield return new WaitForSeconds(10f);

        Instantiate(Fish, transform.position, Quaternion.identity);
    }
}

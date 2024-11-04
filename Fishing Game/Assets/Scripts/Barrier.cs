using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private Fishing FishingScript;

    void Start()
    {
        FishingScript = GameObject.FindObjectOfType<Fishing>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            FishingScript.NearPond();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            FishingScript.NotNearPond();
        }

    }
}

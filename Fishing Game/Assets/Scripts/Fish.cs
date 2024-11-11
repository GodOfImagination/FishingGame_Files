using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float NibbleTimer = 5.0f;      // Used to determine how much time the player needs to wait until the fish is ready to be caught.
    public bool TimerIsRunning = false;   // Used to determine whether the timer is running or not.
    public bool CanLookAt = false;        // Used to determine whether the fish can look at the bait or not.
    public bool BaitTaken = false;        // Used to determine whether the fish is ready to be caught or not.

    private Vector3 Offset = new Vector3(0, 0, 0.01f);
    private Vector3 OffsetRotate = new Vector3(0, -1f, 0);

    private GameObject Bait;
    private GameObject CatchBox;
    private Fishing FishingScript;
    private Catch CatchScript;

    void Start()
    {
        Bait = GameObject.Find("Bait");
        CatchBox = GameObject.Find("CatchBox");
        FishingScript = GameObject.FindObjectOfType<Fishing>();
        CatchScript = GameObject.FindObjectOfType<Catch>();

        CatchBox.transform.position = new Vector3(CatchBox.transform.position.x, -500, CatchBox.transform.position.z);
    }

    void Update()
    {
        if (TimerIsRunning)
        {
            if (NibbleTimer > 0)
            {
                NibbleTimer -= Time.deltaTime;
            }
            else
            {
                NibbleTimer = 0;
                TimerIsRunning = false;
                TimerEnded();
            }
        }

        if (CanLookAt)
        {
            Vector3 BaitPostition = new Vector3(Bait.transform.position.x, transform.position.y, Bait.transform.position.z);
            transform.LookAt(BaitPostition);
        }

        if (BaitTaken)
        {
            transform.position = transform.position + (transform.rotation * Offset);
            transform.rotation = transform.rotation * Quaternion.Euler(OffsetRotate);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bait")
        {
            TimerIsRunning = true;
            CanLookAt = true;
        }
    }

    private void TimerEnded()
    {
        CanLookAt = false;
        BaitTaken = true;
    }

    public void ReelIn()
    {
        if (BaitTaken)
        {
            CatchBox.transform.position = new Vector3(CatchBox.transform.position.x, 150, CatchBox.transform.position.z);

            if (gameObject.name == "CrucianCarp" | gameObject.name == "CrucianCarp(Clone)")
            {
                CatchScript.CaughtCarp();
            }
            else if (gameObject.name == "Dace" | gameObject.name == "Dace(Clone)")
            {
                CatchScript.CaughtDace();
            }
            else if (gameObject.name == "BlackBass" | gameObject.name == "BlackBass(Clone)")
            {
                CatchScript.CaughtBass();
            }

            CatchScript.CaughtFish();
            Destroy(this.gameObject);
        }
        else
        {
            NibbleTimer = 5.0f;
            TimerIsRunning = false;
            CanLookAt = false;
        }
    }
}

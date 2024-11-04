using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float RemainingTime = 5.0f;
    public bool TimerIsRunning = false;
    public bool IsReady = false;

    public Vector3 offset;
    public Vector3 offsetRotate;

    void Update()
    {
        if (TimerIsRunning)
        {
            if (RemainingTime > 0)
            {
                RemainingTime -= Time.deltaTime;
            }
            else
            {
                RemainingTime = 0;
                TimerIsRunning = false;
                TimerEnded();
            }
        }

        if (IsReady)
        {
            transform.rotation = transform.rotation * Quaternion.Euler(offsetRotate);
            transform.position = transform.position + (transform.rotation * offset);
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bait")
        {
            TimerIsRunning = true;
        }
    }

    private void TimerEnded()
    {
        IsReady = true;
    }

    public void ReelIn()
    {
        if (IsReady)
        {
            Destroy(this.gameObject);
        }
        else
        {
            TimerIsRunning = false;
            RemainingTime = 5.0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public bool LineCasted = false;
    public bool IsNearPond = false;

    private GameObject Bait;
    private LineRenderer FishingLine;
    private Player PlayerScript;
    private Fish FishScript;

    void Start()
    {
        Bait = GameObject.Find("Bait");

        FishingLine = GetComponent<LineRenderer>();
        FishingLine.startWidth = 0.05f;
        FishingLine.endWidth = 0.05f;
        FishingLine.positionCount = 2;

        PlayerScript = GameObject.FindObjectOfType<Player>();
    }

    public void NearPond()
    {
        IsNearPond = true;
    }

    public void NotNearPond()
    {
        IsNearPond = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (LineCasted)
            {
                LineCasted = false;
                PlayerScript.ReelIn();
                Bait.transform.position = Bait.transform.position + new Vector3(0, 2, 0);

                Rigidbody BaitRigidbody = Bait.GetComponent<Rigidbody>();
                Destroy(BaitRigidbody);

                FishScript.ReelIn();
            }
            else if (LineCasted == false && IsNearPond)
            {
                LineCasted = true;
                PlayerScript.CastLine();
                Bait.transform.position = Bait.transform.position + new Vector3(0, -2, 0);

                Rigidbody BaitRigidbody = Bait.AddComponent<Rigidbody>();
            }
        }

        FishingLine.SetPosition(0, transform.position);
        FishingLine.SetPosition(1, Bait.transform.position);

        FishScript = GameObject.FindObjectOfType<Fish>();
    }
}

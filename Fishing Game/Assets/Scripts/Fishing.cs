using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public GameObject FishingBait;
    public bool LineCasted = false;
    public bool IsNearPond = false;

    private LineRenderer FishingLine;
    private Player PlayerScript;
    private Fish FishScript;

    void Start()
    {
        FishingLine = GetComponent<LineRenderer>();
        FishingLine.startWidth = 0.05f;
        FishingLine.endWidth = 0.05f;
        FishingLine.positionCount = 2;

        PlayerScript = GameObject.FindObjectOfType<Player>();
        FishScript = GameObject.FindObjectOfType<Fish>();
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
                FishingBait.transform.position = FishingBait.transform.position + new Vector3(0, 2, 0);

                Rigidbody BaitRigidbody = FishingBait.GetComponent<Rigidbody>();
                Destroy(BaitRigidbody);

                FishScript.ReelIn();
            }
            else if (LineCasted == false && IsNearPond)
            {
                LineCasted = true;
                PlayerScript.CastLine();
                FishingBait.transform.position = FishingBait.transform.position + new Vector3(0, -2, 0);

                Rigidbody BaitRigidbody = FishingBait.AddComponent<Rigidbody>();
            }
        }

        FishingLine.SetPosition(0, transform.position);
        FishingLine.SetPosition(1, FishingBait.transform.position);
    }
}

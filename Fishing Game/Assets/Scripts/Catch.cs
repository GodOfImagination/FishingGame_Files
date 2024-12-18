using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Catch : MonoBehaviour
{
    public List<Material> FishList = new List<Material>();

    private GameObject MainCamera;
    private GameObject CatchCamera;

    private GameObject Arm;
    private GameObject ArmCatch;

    private GameObject CatchFish;
    private GameObject CatchBox;
    private TMP_Text CatchText;

    private Spawner SpawnerScript;
    private Player PlayerScript;
    private bool CutsceneIsPlaying = false;

    void Start()
    {
        MainCamera = GameObject.Find("MainCamera");
        CatchCamera = GameObject.Find("CatchCamera");

        Arm = GameObject.Find("ArmLeft");
        ArmCatch = GameObject.Find("FakeArm");

        CatchFish = GameObject.Find("FakeFish");
        CatchBox = GameObject.Find("CatchBox");
        CatchText = GetComponent<TMP_Text>();

        SpawnerScript = GameObject.FindObjectOfType<Spawner>();
        PlayerScript = GameObject.FindObjectOfType<Player>();


        CatchCamera.SetActive(false);

        ArmCatch.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && CutsceneIsPlaying)
        {
            MainCamera.SetActive(true);
            CatchCamera.SetActive(false);

            Arm.SetActive(true);
            ArmCatch.SetActive(false);

            CatchBox.transform.position = new Vector3(CatchBox.transform.position.x, -500, CatchBox.transform.position.z);

            SpawnerScript.FishCaught();
            PlayerScript.CutsceneEnd();
            CutsceneIsPlaying = false;
        }
    }

    public void CaughtFish()
    {
        MainCamera.SetActive(false);
        CatchCamera.SetActive(true);

        Arm.SetActive(false);
        ArmCatch.SetActive(true);

        PlayerScript.CutsceneStart();
        CutsceneIsPlaying = true;
    }

    public void CaughtCarp()
    {
        CatchFish.GetComponent<MeshRenderer>().material = FishList[0];
        CatchText.SetText("I caught a Crucian Carp!");
    }

    public void CaughtDace()
    {
        CatchFish.GetComponent<MeshRenderer>().material = FishList[1];
        CatchText.SetText("I caught a Dace!");
    }

    public void CaughtBass()
    {
        CatchFish.GetComponent<MeshRenderer>().material = FishList[2];
        CatchText.SetText("I caught a Black Bass!");
    }
}

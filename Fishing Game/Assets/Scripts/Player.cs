using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera PlayerCamera;
    public float PlayerWalkSpeed = 2.0f;
    public float PlayerRunSpeed = 6.0f;
    public bool LineCasted = false;

    private CharacterController PlayerController;
    private Vector3 PlayerVelocity;
    private float PlayerSpeed;
    private float GravityValue = -9.81f;

    void Start()
    {
        PlayerController = GetComponent<CharacterController>();
    }

    public void CastLine()
    {
        LineCasted = true;
    }

    public void ReelIn()
    {
        LineCasted = false;
    }

    void Update()
    {
        PlayerCamera.transform.position = transform.position + new Vector3(0, 3, -5);

        if (LineCasted == false)
        {
            if (PlayerVelocity.y < 0)
            {
                PlayerVelocity.y = 0f;
            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                PlayerSpeed = PlayerRunSpeed;
            }
            else
            {
                PlayerSpeed = PlayerWalkSpeed;
            }

            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            Vector3 Movement = new Vector3(Horizontal, 0, Vertical);
            PlayerController.Move(Movement * Time.deltaTime * PlayerSpeed);

            if (Movement != Vector3.zero)
            {
                gameObject.transform.forward = Movement;
            }

            PlayerVelocity.y += GravityValue * Time.deltaTime;
            PlayerController.Move(PlayerVelocity * Time.deltaTime);
        }
    }
}

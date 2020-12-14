using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float horsePower = 0;
    [SerializeField] float rpm;
    [SerializeField] float turnSpeed = 45f;
    private float hInput;
    private float fInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hInput = Input.GetAxis("Horizontal");
        fInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * fInput);
            // Rotates the vehicle left and right based on horizontal input
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * hInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); // For kph, change 2.237 to 3.6
            speedometerText.SetText("Speed: " + speed + "mph");

            rpm = Mathf.Round((speed % 30)*40);
            rpmText.SetText("RPM: " + rpm);
        }   
    }



    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

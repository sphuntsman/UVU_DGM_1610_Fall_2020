﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce;
    public float gravityMod;

    private bool isGrounded = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("GAME OVER MAN! -- GAME OVER!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Forgot to declare the variable after I saved the code
    public float vInput;
    // Player's movement speed
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Collecting the input
        vInput = Input.GetAxis("Vertical");
        // Move up or down based on the arrow keys
        transform.Translate(Vector3.forward * vInput * Time.deltaTime * speed);
        // Boundaries for the player
        if(transform.position.z < -4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4);
        }

        if(transform.position.z > 4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 4);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerMover : MonoBehaviour
{
    // Rotates the plane's propeller
    private float RotationSpeed = 500;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the propeller on the plane at a constant rate
        transform.Rotate(Vector3.forward * RotationSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBounds = 30f;

    public float lowerBounds = -20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy any object entering the topbounds
        if(transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        // Destroy any object entering the lowerbounds
        else if(transform.position.z < lowerBounds)
        {
            Destroy(gameObject);
        }
    }
}

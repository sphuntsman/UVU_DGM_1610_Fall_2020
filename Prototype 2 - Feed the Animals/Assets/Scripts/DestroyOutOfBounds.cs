using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBounds = 30f;

    public float lowerBounds = -20f;

    void Awake()
    {
        Time.timeScale = 1;
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
            Debug.Log("GAME OVER");
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}

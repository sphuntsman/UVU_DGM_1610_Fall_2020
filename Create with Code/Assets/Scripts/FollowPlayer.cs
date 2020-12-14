using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Sets the target for the camera to follow
    public GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 5, -10);

    // Update is called once per frame
    void LateUpdate()
    {
        // Makes the main camera follow the player position
        transform.position = player.transform.position +  offset;
    }
}

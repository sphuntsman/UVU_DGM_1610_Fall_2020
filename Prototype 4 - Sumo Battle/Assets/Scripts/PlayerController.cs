using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    public bool hasPowerUp;
    
    public GameObject focalPoint;

    private float powerUpStr = 15.0f;

    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput * Time.deltaTime);

        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Debug.Log("PowerUp = " + hasPowerUp);
            Destroy(collider.gameObject);
            StartCoroutine(PowerUpCountDown());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Player collided with " + collision.gameObject + " with powerup set to " + hasPowerUp);

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStr, ForceMode.Impulse);

        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(7); hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
}

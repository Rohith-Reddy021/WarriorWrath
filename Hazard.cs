using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player GameObject
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // Check if the PlayerHealth component exists and call the Die method
            if (playerHealth != null)
            {
                playerHealth.Die();
            }
        }
    }
}

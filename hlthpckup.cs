using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToRestore = 100; // Amount of health to restore

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Restore the player's health
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.RestoreHealth(healthToRestore);
            }

            // Destroy the cube
            Destroy(gameObject);
        }
    }
}

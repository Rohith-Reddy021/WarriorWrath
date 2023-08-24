using UnityEngine;

public class TankExplosion : MonoBehaviour
{
    public ParticleSystem explosionPrefab; // Reference to the particle system prefab
    public float explosionRadius = 5.0f; // Radius of the explosion
    public float damageAmount = 50.0f; // Amount of damage to apply to enemies

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Instantiate the explosion particle system
            ParticleSystem explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Play the particle system and destroy it after its duration
            Destroy(explosion.gameObject, explosion.main.duration);

            // Find all colliders within the explosion radius
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Apply damage to enemies within the explosion radius
                    enemyhlth enemyHealth = col.GetComponent<enemyhlth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damageAmount);
                    }
                }
            }

            // Destroy the tank GameObject after the collision
            Destroy(gameObject);
        }
    }
}

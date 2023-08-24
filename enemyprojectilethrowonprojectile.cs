using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10.0f; // Speed of the projectile
    public int damage = 10; // Amount of damage to deal

    private Transform player; // Reference to the player's transform

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
    }

    private void Update()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Move the projectile towards the player's position
        transform.Translate(directionToPlayer * speed * Time.deltaTime);

        // Destroy the projectile after a certain distance
       // if (Vector3.Distance(transform.position, player.position) > 10.0f)
        //{
          //  Destroy(gameObject);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Damage the player
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Destroy the projectile on collision
                    Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class EnemyProjectileThrow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public GameObject projectilePrefab; // Projectile prefab to be thrown
    public float throwForce = 10.0f; // Force to throw the projectile
    public float fireCooldown = 2.0f; // Cooldown between each fireball

    private Animator animator;
    private bool isFiring = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 playerDirection = player.position - transform.position;
        float angle = Vector3.Angle(playerDirection, transform.forward);

        // Check if the angle between enemy's forward direction and player direction is within a certain threshold
        if (angle < 30.0f && !isFiring)
        {
            animator.SetBool("fire", true);
        }
        else
        {
            animator.SetBool("fire", false);
        }
    }

    // Called from animation event
    public void FireProjectile()
    {
        isFiring = true;

        // Create a new projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate the direction to throw the projectile
        Vector3 throwDirection = (player.position - transform.position).normalized;

        // Apply force to the projectile
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Destroy the projectile after a delay
        Destroy(projectile, 2.0f);

        // Set a delay before the enemy can fire again
        Invoke(nameof(ResetFire), fireCooldown);
    }

    private void ResetFire()
    {
        isFiring = false;
    }
}

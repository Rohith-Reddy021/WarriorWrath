using UnityEngine;
using UnityEngine.UI;

public class enemyhlth1 : MonoBehaviour
{
    public float maxHealth; // Maximum health of the enemy
    private float currentHealth;   // Current health of the enemy
public vic victoryController;
    public Slider healthSlider;    // Reference to the health bar slider
    public Animator animator;      // Reference to the enemy's Animator

    public float damageRange; // Range within which the enemy can take damage

    private bool isDead = false;    // Flag to track if the enemy is dead

    private GameObject player;      // Reference to the player GameObject

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();

        player = GameObject.FindGameObjectWithTag("Player"); // Find the player GameObject
    }

    public void TakeDamage(float damage)
    {
        if (isDead || player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= damageRange)
        {
            currentHealth -= damage;
            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    private void Die()
    {
        isDead = true;

        // Play the death animation
        animator.SetBool("ded", true);

        // Disable components that are no longer needed (e.g., Collider, movement scripts)
        // ...

        // Perform other actions when the enemy dies (e.g., drop loot, trigger events)
        // ...

        // Destroy the GameObject after the death animation has played
        // Change the delay based on your animation duration
               Invoke(nameof(death), 2.0f);
    }
    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("PlayerWeapon"))
            {
                // Assuming the player's axe weapon has a Collider component
                // that is set to detect collisions
                TakeDamage(10f); // Call the TakeDamage method
            }
        }
                void death()
                {
                     if (victoryController != null)
                                    {
                                        victoryController.EnemyDestroyed();
                                    }
                }
}

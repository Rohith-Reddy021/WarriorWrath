using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator enemyAnimator; // Reference to the enemy's Animator
    public int attackDamage = 10;   // Damage inflicted on the player

    // Called by animation event in the "Mutant Swiping" animation
    public void OnAttackAnimationEvent()
    {
        // Get the PlayerHealth script from the player GameObject
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

        // If the playerHealth script is found, call the TakeDamage method
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}

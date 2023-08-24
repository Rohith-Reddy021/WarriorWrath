using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;
    private AudioSource audioSource; // Reference to the AudioSource

    public Slider healthSlider; // Reference to the health slider
    public AudioClip hitSound;  // Assign the hit sound in the Inspector

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        UpdateHealthSlider();
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            UpdateHealthSlider(); // Update the slider when health changes

            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                // Play the hit sound
                if (hitSound != null)
                {
                    audioSource.PlayOneShot(hitSound);
                }
            }
        }
    }

    public void RestoreHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthSlider(); // Update the slider when health changes
    }

    public void Die()
    {
        // Play death animation
        animator.SetBool("isDead", true);
        Invoke(nameof(death), 2.0f);
        // Disable player controls or other actions
        // For example: GetComponent<PlayerMovement>().enabled = false;
    }

    void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    void death()
    {
        SceneManager.LoadScene("dea");
    }
}

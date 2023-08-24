using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public float damage;
    public ParticleSystem ex;
    public AudioClip explosionSound;

    private Rigidbody rb;
    private AudioSource audioSource;

    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Make sure only to stick to the first target you hit
        if (targetHit)
            return;
        else
            targetHit = true;

        // Check if you hit an enemy
        if (collision.gameObject.GetComponent<enemyhlth>() != null)
        {
            enemyhlth enemy1 = collision.gameObject.GetComponent<enemyhlth>();
            enemy1.TakeDamage(damage);

            // Play explosion sound
            if (audioSource != null && explosionSound != null)
            {
                audioSource.PlayOneShot(explosionSound);
            }

            // Destroy projectile
            Destroy(gameObject);
            Instantiate(ex, transform.position, transform.rotation);
        }

        // Make sure projectile sticks to surface
        rb.isKinematic = true;

        // Destroy object and instantiate explosion
        Destroy(gameObject);
        Instantiate(ex, transform.position, transform.rotation);

        // Make sure projectile moves with target
        transform.SetParent(collision.transform);
    }
}

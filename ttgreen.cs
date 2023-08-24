using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ttgreen : MonoBehaviour
{
    [Header("References")]
    public Transform target; // Reference to the character's Transform
    public Transform attackPoint;
    public GameObject objectToThrow;
    public GameObject button;
    public Animator animator;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;
    bool click;
    int tt;

    private void Start()
    {
        tt = totalThrows;
        readyToThrow = true;
    }



    private void Throw()
    {
        readyToThrow = false;
        click = false;
        animator.SetBool("ball", false);
        // Instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, Quaternion.identity);

        // Get Rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Calculate throw direction
        Vector3 forceDirection = target.transform.forward;

        RaycastHit hit;

        // Check if there's an object in front of the camera and adjust throw direction
        if (Physics.Raycast(target.position, target.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // Add force to the object to simulate the throw
        Vector3 forceToAdd = forceDirection * throwForce + target.transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // Implement throwCooldown
        if (totalThrows <= 0)
            Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        totalThrows = tt;
        readyToThrow = true;
        button.SetActive(true);
    }

    public void buttonclick()
    {
        click = true;
        animator.SetBool("ball", true);
        button.SetActive(false);
          if (click == true && readyToThrow == true)
                        {
                            Invoke(nameof(Throw), 1.0f);
                        }
    }
}

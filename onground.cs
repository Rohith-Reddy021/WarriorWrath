using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounding : MonoBehaviour
{
    public float groundOffset = 0.2f; // Offset to keep the player above the ground
    public LayerMask groundLayer;    // Layer mask for detecting the ground

    private CharacterController characterController; // Reference to the CharacterController component

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        UpdateGrounding();
    }

    private void UpdateGrounding()
    {
        // Cast a ray downwards from the player's position to detect the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            // Calculate the desired position based on the hit point and offset
            Vector3 desiredPosition = hit.point + Vector3.up * groundOffset;

            // Move the character controller to the desired position
            characterController.Move(desiredPosition - transform.position);
        }
    }
}

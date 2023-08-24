using UnityEngine;

public class DestroyLinkedObject : MonoBehaviour
{
    public GameObject linkedObject; // Reference to the object to be destroyed

    private void OnDestroy()
    {
        if (linkedObject != null)
        {
            Destroy(linkedObject); // Destroy the linked object
        }
    }
}

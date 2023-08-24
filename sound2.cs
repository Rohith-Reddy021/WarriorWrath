using UnityEngine;

public class SoundAnimationTrigger2 : MonoBehaviour
{
    public AudioClip soundClip; // Assign the sound clip in the Inspector
    public GameObject objectToDestroy; // Assign the object to destroy in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // This method is called from the animation event
    public void PlayOneShotSound()
    {
        if (objectToDestroy == null)
        {
            audioSource.PlayOneShot(soundClip); // Play the sound
        }
    }
}

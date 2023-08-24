using UnityEngine;

public class SoundAnimationTrigger : MonoBehaviour
{
    public AudioClip soundClip; // Assign the sound clip in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // This method is called from the animation event
    public void PlayOneShotSound()
    {
        audioSource.PlayOneShot(soundClip);
    }
}

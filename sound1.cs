using UnityEngine;

public class SoundAnimationTrigger1 : MonoBehaviour
{
    public AudioClip soundClip; // Assign the sound clip in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // This method is called from the animation event
    public void PlayOneShotS()
    {
        audioSource.PlayOneShot(soundClip);
    }
}

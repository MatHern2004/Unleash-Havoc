using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine; // For Unity functions

public class SoundEffectsManager : MonoBehaviour
{
    // To call our sounds from any function without the getComponent aspects
    public static SoundEffectsManager instance;
    // Invisible Prefab that is created whenever a sound is played
    [SerializeField] private AudioSource soundEffectObject;
    // Call to set object appropriately 
    private void Awake()
    {
        if (instance == null)
        {
            // If the SoundEffectsManager object is null, then set it to the current object
            instance = this;
        }
    }

    // Plays a sound when an action occurs with the sound manager
    public void PlaySoundEffecsClip(AudioClip audioClip, Transform spwnTransform, float volume)
    {
        // Spawn the invisible audioSource object
        AudioSource audioSource = Instantiate(soundEffectObject, spwnTransform.position, Quaternion.identity);

        // Set the audio clip
        audioSource.clip = audioClip;

        // Play the audio clip
        audioSource.Play();

        // Get the length of the audio clip
        float clipLength = audioSource.clip.length;

        // Destory the audio once it finishes playing
        Destroy(audioSource.gameObject, clipLength);

    }
}

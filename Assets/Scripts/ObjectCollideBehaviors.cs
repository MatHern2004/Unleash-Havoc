using UnityEngine;

public class ObjectCollideBehaviors : MonoBehaviour
{
    // Sound effect array for multiple sounds
    [SerializeField] private AudioClip[] objectHitGroundSounds;
     void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;

        if (collidedWith.CompareTag("Ground") && gameObject.CompareTag("Box"))
        {
            // Play the sound effects if the object collided with the ground
            SoundEffectsManager.instance.PlayRandomSoundEffecsClip(objectHitGroundSounds, transform, 1f);
        }
    }
}

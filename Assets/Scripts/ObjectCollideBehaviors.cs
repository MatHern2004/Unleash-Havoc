using UnityEngine; // for Unity functions

public class ObjectCollideBehaviors : MonoBehaviour
{
    // Sound effect array for multiple sounds
    [SerializeField] private AudioClip[] objectHitGroundSounds;
    [SerializeField] private AudioClip[] objectBallGroundSounds;
     void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;

        if (collidedWith.CompareTag("Ground") && gameObject.CompareTag("Box"))
        {
            // Play the sound effects if the object collided with the ground
            SoundEffectsManager.instance.PlayRandomSoundEffecsClip(objectHitGroundSounds, transform, 1f);
        }

        if (collidedWith.CompareTag("Ground") && gameObject.CompareTag("Ball"))
        {
            // Play the sound effects if the ball object collided with the ground
            SoundEffectsManager.instance.PlayRandomSoundEffecsClip(objectBallGroundSounds, transform, 1f);
        }
    }
}

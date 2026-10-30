using UnityEngine; // For Unity functions

public class Powerups : MonoBehaviour
{
    // Duration of time
    [SerializeField] private float duration = 10f;
    // Powerup grab sound
    [SerializeField] private AudioClip powerupGrab; 
    // When the player touches the powerup
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the powerup collides with the Player
        if (collision.CompareTag("Player"))
        {
            // Play the powerup noise
            SoundEffectsManager.instance.PlaySoundEffecsClip(powerupGrab, transform, 1f);
            // Get the grabObject code to modify its values
            GrabObjects grabCode = collision.GetComponent<GrabObjects>();
            if (grabCode != null)
            {
                // Set the grabObjects powerupGrabbed to true
                // Set powerUp time based on set duration
                grabCode.powerupGrabbed = true;
                grabCode.powerupTime = Time.time + duration;
            }
            // After you get the object, destroy it
            Destroy(gameObject);
        }
       
    }
}

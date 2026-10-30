using UnityEngine; // For Unity functions

public class Powerups : MonoBehaviour
{
    [SerializeField] private float duration = 10f;
    // When the player touches the powerup
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the grabObject code to modify its values
            GrabObjects grabCode = collision.GetComponent<GrabObjects>();
            if (grabCode != null)
            {
                // Set the grabObjects powerupGrabbed to true
                // Set powerUp time based on set duration
                grabCode.powerupGrabbed = true;
                grabCode.powerupTime = Time.time + duration;
                // After you collect the powerup, destroy it
            }
            Destroy(gameObject);
        }
       
    }
}

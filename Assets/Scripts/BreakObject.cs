using UnityEngine; // For using Unity Collections

public class BreakObject : MonoBehaviour
{

    // For Spawning Glass Shards
    [SerializeField] private GameObject glassShard;
    // SoundFX for breaking glass
    [SerializeField] private AudioClip breakGlassSound;
    // For glass breaking sound effect
    // To rotate glass
    private float rotateGlass;
    // Glass Shard count
    private int glassCount  = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check which object was collided with
        GameObject collidedWith = collision.gameObject;

        // If a box was thrown at glass
        if (collidedWith.CompareTag("Box") && gameObject.CompareTag("Glass"))
        {// Play SFX
            SoundEffectsManager.instance.PlaySoundEffecsClip(breakGlassSound, transform, 1f);
            // Shatter the glass
            Destroy(gameObject);
            // Spawn the glass shards 
            for (int i = 0; i < glassCount; i++)
            {
                // Randomly rotate things
                rotateGlass = Random.Range(-150, 150f);
                // Create glass shards for things
                Instantiate(glassShard, transform.position, Quaternion.Euler(rotateGlass, rotateGlass, rotateGlass));
            }
            
        }
    }
}

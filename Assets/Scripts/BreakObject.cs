using UnityEngine; // For using Unity Collections

public class BreakObject : MonoBehaviour
{

    // For Spawning Glass Shards
    [SerializeField] private GameObject glassShard;
    // SoundFX for breaking glass
    [SerializeField] private AudioClip breakGlassSound;
    // For obtaining the sound itself
    private AudioSource audioSource;
    // For glass breaking sound effect
    // To rotate glass
    private float rotateGlass;
    // Collision glass
    private BoxCollider2D glassCollision;
    // Glass Shard count
    private int glassCount  = 10;
    
    // Awake Function
    private void Awake()
    {
        // Awake with the glass collision initialized
        glassCollision = glassShard.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        // Start with the audio source initialized
         audioSource = GetComponent<AudioSource>(); 
    }

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

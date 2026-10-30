using System;
using UnityEngine; // For using Unity functions

public class EnemyMovement : MonoBehaviour
{
    // Right side of the field
    [SerializeField] private Transform rightSide;
    // Left side of the field
    [SerializeField] private Transform leftSide;
    // For modifying enemy speed
    [SerializeField] private float speed = 10f;
    // For updating player health
    [SerializeField] private PlayerHealth health;
    // For playing sound for the enemy being hit
    [SerializeField] private AudioClip hitEnemySound;
    // For enemy death sound
    [SerializeField] private AudioClip deathEnemySound;
    // bounceOffEnemySound;
    [SerializeField] private AudioClip boundOffEnemySound;
    // Tag to determine the enemyType used for damage scaling
    public String enemyType { get; private set; }
    // Document which direction the enemy is facing
    private float facing = 1;  
    // Bool to stop updating of the body.linearVelocity
    bool isHit = false;
    // Minimum speed required for a hit
    [SerializeField] private float minHitSpeed;
    // Create variable for RigidBody2D
    private Rigidbody2D body;
    // Create variable for object Rigid2DBody
    private Rigidbody2D objectBody;

    // Function used to initiate enemy component
    private void Awake()
    {
        // To update the enemy's location
        body = GetComponent<Rigidbody2D>();
    }

    // Function to get the tag of the current enemy
    private void Start()
    {
        // Grab the enemy type tag to differntiate damage taken for each enemy
        enemyType = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        // Basic enemy patrol that only works when isHit is false
        if (!isHit)
        {
            if (gameObject.CompareTag("Basic"))
                body.linearVelocity = new Vector2(speed * facing, body.linearVelocity.y);
            else if (gameObject.CompareTag("Big"))
                body.linearVelocity = new Vector2(speed/2 * facing, body.linearVelocity.y);
            // If we reach to the right, then change the direction
            if (body.position.x > rightSide.GetComponent<Transform>().position.x)
                facing = -1;
            // If we reach the left side, then change the direction
            else if (body.position.x < leftSide.GetComponent<Transform>().position.x)
                facing = 1;
            
        }
    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Find out what object hit the player
        GameObject collidedWith = collision.gameObject;
        // If it was a basic box and the velocity of the collison was greater than the minimum speed
        float objectSpeed = collision.rigidbody.linearVelocity.magnitude;
        Debug.Log(objectSpeed);
        if (collidedWith.CompareTag("Box") && objectSpeed > minHitSpeed && gameObject.CompareTag("Basic"))
        {
            // Set isHit to true to stop updates
            isHit = true;
            // Play the enemy hit sound
            SoundEffectsManager.instance.PlaySoundEffecsClip(hitEnemySound, transform, 1f);
            // Play the enemy death scream
            SoundEffectsManager.instance.PlaySoundEffecsClip(deathEnemySound, transform, 1f);
            // Push the enemy back
            body.AddForce(body.linearVelocity, ForceMode2D.Impulse);
            // Destroy the enemy!
            Destroy(gameObject, 0.4f);
        }

        // If the enemy collides with a player, have a life bars
        if (collidedWith.CompareTag("Player"))
        {
            // Take damage from the basic enemy
            health.TakeDamage(enemyType);
        }

        if (collidedWith.CompareTag("Box") && gameObject.CompareTag("Big"))
        {
            objectBody = collidedWith.gameObject.GetComponent<Rigidbody2D>();
            objectBody.AddForce(-objectBody.linearVelocity * 3, ForceMode2D.Impulse);
            SoundEffectsManager.instance.PlaySoundEffecsClip(boundOffEnemySound, transform, 1f);
        }

        if (collidedWith.CompareTag("Fall"))
        {
            // Set isHit to true to stop updates
            isHit = true;
            // Kill the object
             // Play the enemy hit sound
            SoundEffectsManager.instance.PlaySoundEffecsClip(hitEnemySound, transform, 1f);
            // Play the enemy death scream
            SoundEffectsManager.instance.PlaySoundEffecsClip(deathEnemySound, transform, 1f);
            // Destroy the object and entity once the object hits them!
            Destroy(collidedWith, 0.2f);
            Destroy(gameObject, 0.2f);
        }
    }
}

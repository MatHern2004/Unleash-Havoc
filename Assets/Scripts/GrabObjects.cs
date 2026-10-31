using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine; // For using Unity methods

public class GrabObjects : MonoBehaviour
{
    // Field with Modifiable Values in GUI for the grab location
    [SerializeField] private Transform grabPoint;

    // Field with Modifiable Values in GUI for the ray location
    [SerializeField] private Transform rayPoint;

    // Amount of force need for the throw
    [SerializeField] private float throwForce = 10f;

    // Field with Modifiable Values for the ray distance
    [SerializeField] private float rayDistance;

    // Initialize the pivotPoint;
    [SerializeField] private Aiming pivotPoint;
    // Audio for Throwing
    [SerializeField] private AudioClip[] throwSounds;
    // When the object is grabbed by the player
    [SerializeField] private AudioClip grabObjectSound;
    // Enemy grab sound
    [SerializeField] private AudioClip enemyThrowSound;
    // powerup Bool for grabbing enemie
    public bool powerupGrabbed;
    // powerup last time
    public float powerupTime;
    


    // For updating the direction the player is facing for updating the grabbed object
    private float facing;

    // Initialize grab object
    private GameObject grabbedObject;

    // To set the index 'Object' layer we created
    private int layerIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtain the layerIndex that is needed to grab the game object in front of the player
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    // Update is called once per frame
    void Update()
    {
        // If the powerup is shorter than the normal time, end it
        if (powerupGrabbed && Time.time >= powerupTime)
            powerupGrabbed = false;

        // If the powerup was obtained
        if (powerupGrabbed && Time.time < powerupTime)
            layerIndex = LayerMask.NameToLayer("Enemy");
        else
            // Else reset the layer back to objects
            layerIndex= LayerMask.NameToLayer("Objects");

        // Used to determine the direction the player is facing for the parent object and its children
        facing = Mathf.Sign(transform.localScale.x);
        // Change the throwing angle
        float throwAngle = pivotPoint.pivotAngle * Mathf.Deg2Rad;
        // Create the direction vector for it
        // Use the sin and cosine to properly direct the object in flight 
        Vector2 direction = new Vector2(Mathf.Cos(throwAngle) * facing, Mathf.Sin(throwAngle));
        // Create Raycast object to grab what is nearby the player
        // Checks for the ray's position, places it to the right, and its distance from the player
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, direction, rayDistance);

        // If the there is a collider being met and the specific object being collided is in the objects layer
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {  
            // Grab object
            if (Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
            {
                // Play grabObject SFX
                SoundEffectsManager.instance.PlaySoundEffecsClip(grabObjectSound, transform, 1f);
                // Set the object found in our collider and set to as our currently grabbed object
                grabbedObject = hitInfo.collider.gameObject;
                // Set the object to kinematic so it isn't affected by gravity anymore
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                // Set grab object to the grab point position
                grabbedObject.transform.position = grabPoint.position;
                // Set player as the parent object
                grabbedObject.transform.SetParent(transform);
            }
            
            // To drop the object
            else if (Input.GetKeyDown(KeyCode.E))
            {
                // Reverse the object to begin experiencing gravity
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                // Set the parent to null 
                grabbedObject.transform.SetParent(null);
                // Reset the grabbedObject variable to null to leave us empty handed
                grabbedObject = null;
            }
        }

        // View the ray in the scene window when playing
        Debug.DrawRay(rayPoint.position, direction * rayDistance, Color.red);
        // Update box location as it moves
        if (grabbedObject != null)
            grabbedObject.transform.position = grabPoint.position;
        
        // Throw the object
        if (Input.GetMouseButton(0) && grabbedObject != null)
            {
                // Play Throw sounds
                SoundEffectsManager.instance.PlayRandomSoundEffecsClip(throwSounds, transform, 1f);
                // Reverse the object to begin experiencing gravity
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                // Make sure the physics is being simulated properly
                grabbedObject.GetComponent<Rigidbody2D>().simulated = true;
                // If the object itself is an enemy make em scream
                if (grabbedObject.CompareTag("Basic"))
                {
                    // Sound effect for enemy being thrown
                    SoundEffectsManager.instance.PlaySoundEffecsClip(enemyThrowSound, transform , 1f);
                    // Stop the enemy movement
                    grabbedObject.GetComponent<EnemyMovement>().enabled = false;
                     // Apply an immediate force to the object
                    grabbedObject.GetComponent<Rigidbody2D>().AddForce(direction * throwForce*2, ForceMode2D.Impulse);
                }
                else
                {
                    grabbedObject.GetComponent<Rigidbody2D>().AddForce(direction * throwForce, ForceMode2D.Impulse);
                }
                // Set parent to null 
                grabbedObject.transform.SetParent(null); 
                // grabbedObject is reset because it was thrown
                grabbedObject = null;
            }
    }
    
}

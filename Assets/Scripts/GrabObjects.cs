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
                Debug.Log("Dropping Object!");
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
                // Reverse the object to begin experiencing gravity
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                // Make sure the physics is being simulated properly
                grabbedObject.GetComponent<Rigidbody2D>().simulated = true;
                // Apply an immediate force to the object
                grabbedObject.GetComponent<Rigidbody2D>().AddForce(direction * throwForce, ForceMode2D.Impulse);
                // Set parent to null 
                grabbedObject.transform.SetParent(null); 
                // grabbedObject is reset because it was thrown
                grabbedObject = null;
            }
    }
    
}

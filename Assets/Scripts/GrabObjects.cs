using Unity.VisualScripting;
using UnityEngine; // For using Unity methods

public class GrabObjects : MonoBehaviour
{
    // Field with Modifiable Values in GUI for the grab location
    [SerializeField] private Transform grabPoint;

    // Field with Modifiable Values in GUI for the ray location
    [SerializeField] private Transform rayPoint;

    // Field with Modifiable Values for the ray distance
    [SerializeField] private float rayDistance;

    // Initialize grab object
    private GameObject grabbedObject;

    // To set the index 'Object' layer we created
    private int layerIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    // Update is called once per frame
    void Update()
    {
        // Create Raycast object to grab what is nearby the player
        // Checks for the ray's position, places it to the right, and its distance from the player
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        // If the there is a collider being met and the specific object being collided is in the objects layer
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {  
            // Grab object
            if (Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
            {
                Debug.Log("I am pressing E with an object near me!");
                // Set the object found in our collider and set to as our currently grabbed object
                grabbedObject = hitInfo.collider.gameObject;
                // Set the object to kinematic so it isn't affected by gravity anymore
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                // Set grab object to the grab point position
                grabbedObject.transform.position = grabPoint.position;
                // Set player as the parent object
                grabbedObject.transform.SetParent(transform);
            }
            // Throw the object
            else if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
            // To drop the object
            else if (Input.GetKeyDown(KeyCode.W))
            {
                // Reverse the object to begin experiencing gravity
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                // Set the parent to null and not the player
                grabbedObject.transform.SetParent(null);
                // Reset the grabbedObject variable to null to leave us empty handed
                grabbedObject = null;
            }
        }

        // View the ray in the scene window when playing
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance, Color.red);
    }
}

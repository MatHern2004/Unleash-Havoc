using UnityEngine; /// Unity library for its functions
 
public class PlayerMovement : MonoBehaviour
{
    // Create variable for RigidBody2D
    private Rigidbody2D body;
    // Player Speed (Serialized to Edit Within Unity)
    [SerializeField] private float speed = 10f;

    // Function to initialize object
    private void Awake()
    {
        // Obtain the component information within the Rigidbody2D object
        body = GetComponent<Rigidbody2D>();
    }

    // Updates per frame of the game
    private void Update()
    {
        // Input.GetAxis("Horizontal") shifts the distance -1 and 1. This shifts based on the A or D / left or right key
        // Then we set the body.linearVelocity of Y to 0 because we don't want it to move as we move 
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);
    }
    
}

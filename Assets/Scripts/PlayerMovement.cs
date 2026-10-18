using UnityEngine; /// Unity library for its functions
using UnityEngine.Scripting.APIUpdating; // May Need to Delete Later

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

    // Grab the ball
    private void Grab()
    {
        
    }

    // Throw the ball
    private void Throw()
    {
        
    }

    // Updates per frame of the game
    private void Update()
    {

        // Left and Right Movement (Running)
        // Input.GetAxis("Horizontal") shifts the distance -1 and 1. This shifts based on the A or D / left or right key
        // Then we set the body.linearVelocity of Y to 0 because we don't want it to move as we move 
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        // Jumping (Up) 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Modify linear velocity as we mantain the x velocity, but increase the y velocity by 10
            // This creates jumping
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        }

        // Fast falling (down)
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Keep the x velocity the same, but decrease time in the air if we hold s
            body.linearVelocity = new Vector2(body.linearVelocity.x, -speed);
        }
    }
    
}

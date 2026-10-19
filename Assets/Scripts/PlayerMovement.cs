using UnityEngine; /// Unity library for its functions
using UnityEngine.Scripting.APIUpdating; // May Need to Delete Later

public class PlayerMovement : MonoBehaviour
{
    // Create variable for RigidBody2D
    private Rigidbody2D body;
    // To obtain the direction the player is traveling
    private float inputHorizontal;
    // Boolean to check direction
    private bool facingRight = true;
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

    // For flipping the player
    private void FixedUpdate()
    {
        // Obtain the direction of the player
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        // If I am not facing the right and moving right, then flip the player
        if (inputHorizontal > 0 && !facingRight)
            Flip();
        // IF I am facing the left and am facing hte right, then flip the player
        if (inputHorizontal < 0 && facingRight)
            Flip();
    }

    // Function to assist with flipping the player sprite
    private void Flip()
    {
        // Obtain the current scale for the user
        Vector3 currentScale = gameObject.transform.localScale;
        // Flip directions for the player
        currentScale.x *= -1;
        // Update the currentScale
        gameObject.transform.localScale = currentScale;
        // Flip the character boolean with every call
        facingRight = !facingRight;
    }
    
}

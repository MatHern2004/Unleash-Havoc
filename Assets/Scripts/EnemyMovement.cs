using UnityEngine; // For using Unity functions

public class EnemyMovement : MonoBehaviour
{

    // Right side of the field
    [SerializeField] private Transform rightSide;
    // Left side of the field
    [SerializeField] private Transform leftSide;
    // For modifying enemy speed
    [SerializeField] private float speed = 10f;
    // Document which direction the enemy is facing
    private float facing = 1; 
    // Create variable for RigidBody2D
    private Rigidbody2D body;

    // Function used to initiate enemy component
    private void Awake()
    {
        // To update the enemy's location
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Basic enemy patrol
        body.linearVelocity = new Vector2(speed * facing, body.linearVelocity.y);
        // If we reach to the right, then change the direction
        if (body.position.x > rightSide.GetComponent<Transform>().position.x)
            facing = -1;
        // If we reach the left side, then change the direction
        else if (body.position.x < leftSide.GetComponent<Transform>().position.x)
            facing = 1;
    }
}

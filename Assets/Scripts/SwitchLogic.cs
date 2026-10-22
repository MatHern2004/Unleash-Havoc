using Unity.VisualScripting.FullSerializer;
using UnityEngine; // For Unity functions

public class ScriptLogic : MonoBehaviour
{
    // For the minimum required speed to hit the switch
    private float minHitSpeed = 1.0f;
    // Gate opening speed
    private float gateOpenSpeed = 3.0f;
    // Extra assistance for weird angle
    private float weirdAngleAdd = 3.0f;
    // For updating the Switch color
    [SerializeField] private GameObject switchChange;
    // For updating the Gate and Opening it
    [SerializeField] private GameObject gate;
    // To open the gate
    private Rigidbody2D gateOpen;
    // For color changes
    private SpriteRenderer colorChange;
    

    private void Awake()
    {
        colorChange = switchChange.GetComponent<SpriteRenderer>();
        gateOpen = gate.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Stop gate once it reaches a threshold
        if (gateOpen.position.y > 13)
            gateOpen.linearVelocity = new Vector2(gateOpen.linearVelocity.x, 0 * gateOpen.linearVelocity.y);
    }

    // Collision Logic

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the object name
        // Find out what object hit the player
        GameObject collidedWith = collision.gameObject;
        float objectSpeed = collision.rigidbody.linearVelocity.magnitude;
        // If it was a basic box and the velocity osf the collison was greater than 3
        if (collidedWith.CompareTag("Box") && objectSpeed * weirdAngleAdd > minHitSpeed && colorChange.color != Color.green)
        {
            // Change the color to show it was hit
            colorChange.color = Color.green;
            // Raise the gate 
            gateOpen.bodyType = RigidbodyType2D.Kinematic;
            // Let the gate rise at a speed of 3.0f
            gateOpen.linearVelocity = new Vector2(gateOpen.linearVelocity.x, gateOpenSpeed);
        }
    }
}   

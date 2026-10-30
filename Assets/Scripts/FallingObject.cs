using UnityEngine; // For Unity Functions

public class FallingObject : MonoBehaviour
{
    // Transform falling object
    private Rigidbody2D fallingObjectBody;
    // Awake function 
    private void Awake()
    {
       fallingObjectBody = gameObject.GetComponent<Rigidbody2D>();
    }
    // Collison for Things
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // What did the object collide with
       GameObject collidedWith = collision.gameObject;
       if ((collidedWith.CompareTag("Box") || collidedWith.CompareTag("Ball")) && gameObject.CompareTag("Fall"))
        {
            // Make it dynamic and heavy
            fallingObjectBody.bodyType = RigidbodyType2D.Dynamic;
            fallingObjectBody.mass = 100f;
        }        
    }
}

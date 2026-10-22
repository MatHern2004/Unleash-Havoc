using UnityEngine; // For unity scripts

public class Aiming : MonoBehaviour
{
    // What we use to assist with mouse aiming
    private Camera mainCamera;

    // Obtain mouse position
    private Vector3 mousePos;

    // Create a public version of the pivotAngle for the grabObjects to use
    public float pivotAngle { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the maincamera object data
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the mouse position to take in world coordinates instead of just screen
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        // Create a rotation vector that updates based on the mouse position and transform.position
        Vector3 toMouse = mousePos - transform.position;
        // Obtain the rotation obtained by z
        float rotateZ = Mathf.Atan2(toMouse.y, Mathf.Abs(toMouse.x)) * Mathf.Rad2Deg;
        // Rotate to only make it so they can move within a range of 116 degrees
        rotateZ = Mathf.Clamp(rotateZ, -75f, 75f);
        // Set the aimAngle for throwing in grabbedObjects
        pivotAngle = rotateZ;
        // Rotate using Quaternion with local rotation to let the parent do the flipping for us
        transform.localRotation = Quaternion.Euler(0, 0, rotateZ);
    }
}

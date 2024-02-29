using UnityEngine;

public class SwipeController : MonoBehaviour
{
    Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
    float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to control throw force in Z direction

    [SerializeField] float throwForceInXandY = 1f; // to control throw force in X and Y directions
    [SerializeField] float throwForceInZ = 50f; // to control throw force in Z direction
    [SerializeField] AudioSource throwSFX; // Reference to the AudioSource for throw sound effect

    Rigidbody rb;
    private bool isThrown = false; // Flag to track if the ball has been thrown

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the ball has already been thrown, return early to prevent further input handling
        if (isThrown)
            return;

        // if you touch the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // getting touch position and marking time when you touch the screen
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        // if you release your finger
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            // marking time when you release it
            touchTimeFinish = Time.time;

            // calculate swipe time interval 
            timeInterval = touchTimeFinish - touchTimeStart;

            // getting release finger position
            endPos = Input.GetTouch(0).position;

            // calculating swipe direction in 2D space
            direction = startPos - endPos;

            // add force to balls rigidbody in 3D space depending on swipe time, direction, and throw forces
            rb.isKinematic = false;
            rb.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval);

            // Set the flag to indicate that the ball has been thrown
            isThrown = true;

            // Disable the script component attached to this GameObject
            enabled = false;

            // Check if the throw sound effect and AudioSource are assigned
            if (throwSFX != null)
            {
                // Play the throw sound effect once
                throwSFX.PlayOneShot(throwSFX.clip);
            }
            else
            {
                Debug.LogWarning("Throw sound effect reference not set in SwipeController script!");
            }

            // Call the HandleBallThrown method of the BallCollisionFX script attached to any child GameObjects
            HandleBallThrown();
        }
    }

    // Method to find the BallCollisionFX component in the children of the ball GameObject and call its HandleBallThrown method
    void HandleBallThrown()
    {
        // Get the BallCollisionFX component attached to the ball or its children
        BallCollisionFX ballCollisionFX = GetComponentInChildren<BallCollisionFX>();
        // Call the HandleBallThrown method if the BallCollisionFX component exists
        if (ballCollisionFX != null)
        {
            ballCollisionFX.BallThrown();
        }
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerMovement playerMovement;

    public float forwardForce = 10f;
    public float sidewaysForce = 5f;

    // initializes the PlayerMovement variable
    // execution the PlayerMovement reference before any scripts loading
    private void Awake()
    {
        playerMovement = new PlayerMovement(rb, forwardForce, sidewaysForce);
    }

    // Moving the player with keys
    // bool in this script, is a refrence to the bool that i use in the PlayerMovement script
    void FixedUpdate()
    {
        bool moveForward = Input.GetKey("w");
        bool moveBackward = Input.GetKey("s");
        bool moveRight = Input.GetKey("d");
        bool moveLeft = Input.GetKey("a");
        bool Stop = Input.GetKey("space");
        
        // calling the Move fuction that i use in MovementPlayer script, for controlling the player movement
        playerMovement.Move(moveForward, moveBackward, moveRight, moveLeft, Stop, Time.deltaTime);
    }
}

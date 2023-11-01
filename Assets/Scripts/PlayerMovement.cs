using UnityEngine;

public class PlayerMovement
{
    private Rigidbody rb;
    private float forwardForce;
    private float sidewaysForce;

    // Constructor for playerMovement class (make a refrence for PlayerController script which includes MonoBehviour class)
    public PlayerMovement(Rigidbody rb, float forwardForce, float sidewaysForce)
    {
        this.rb = rb;
        this.forwardForce = forwardForce;
        this.sidewaysForce = sidewaysForce;
    }

    // Move the player
    // It takes boolean parameters to control movement
    public void Move(bool moveForward, bool moveBackward, bool moveRight, bool moveLeft, bool Stop, float deltaTime)
    {
        // If (x) is true then add a forward force to the Rigidbody
        if(moveForward)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if(moveBackward)
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }
        if(moveRight)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
        if(moveLeft)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
        // If Stop is true, set the velocity of the Rigidbody to zero to stop the movement
        if(Stop)
        {
            rb.velocity = Vector3.zero;
        }
    }
}

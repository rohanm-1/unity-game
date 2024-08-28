using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // reference to the Rigidbody component called rb
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start(){

    }

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    // Update is called once per frame
    // Use FixedUpdate() instead of Update() when dealing with physics
    void FixedUpdate()
    {
        // adding a forward and adjustable force
        // Use Time.deltaTime for smoother movement on all devices
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        
        // checking player movement (assuming they use wasd)
        if (Input.GetKey("d")) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a")) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f){
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}

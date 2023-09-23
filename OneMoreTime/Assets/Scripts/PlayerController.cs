using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;

    private float inputHorizontal;
    private float inputVertical;

    public float speed;
    public float maxSpeed;

    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoviment();
    }

    public void PlayerMoviment()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.right * speed * inputHorizontal);

        if (Mathf.Abs(playerRb.velocity.x) > maxSpeed)
        {
            playerRb.velocity = new Vector2(Mathf.Sign(playerRb.velocity.x) * maxSpeed, playerRb.velocity.y);
        }

        playerRb.AddForce(Vector3.forward * speed * inputVertical);

        if (Mathf.Abs(playerRb.velocity.z) > maxSpeed)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, Mathf.Sign(playerRb.velocity.z) * maxSpeed);
        }

        if (inputHorizontal > 0 && !facingRight || inputHorizontal < 0 && facingRight)
        {
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        facingRight = !facingRight;

        transform.rotation = Quaternion.Euler(0, 0, facingRight ? 0 : 180);
    }

}

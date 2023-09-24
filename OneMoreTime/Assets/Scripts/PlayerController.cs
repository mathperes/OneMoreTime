using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;

    public GameObject teclaE;


    [SerializeField] private float inputHorizontal;
    [SerializeField] private float inputVertical;

    public float speed;
    public float maxSpeed;

    public bool facingRight;
    public static bool canMove;

    [Header("Area booleanas")]
    public bool inCafe = false;
    public bool inVomit = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        canMove = false;
    }
    private void Update()
    {
        if (inCafe)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.tomouCafe = true;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            PlayerMoviment();
        }
             
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PrimeiraLembranca"))
        {
            DialogController.dialogIndex = 1;
            DialogController.dialogStart = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Cafe"))
        {
            teclaE.gameObject.SetActive(true);
            inCafe = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cafe"))
        {
            teclaE.gameObject.SetActive(false);
            inCafe = false;
        }
    }

    

}

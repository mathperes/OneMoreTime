using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public int playerID;

    public GameObject teclaE;
    public GameObject miniGamePanel;

    public GameObject vomito;

    public SpriteRenderer semRoupaSprite;
    public SpriteRenderer comRoupaSprite;

    public GameObject mala;
    public GameObject chave;
    public GameObject pensandoLixo;
    public GameObject saida;

    [SerializeField] private float inputHorizontal;
    [SerializeField] private float inputVertical;

    public float speed;
    public float maxSpeed;

    public bool facingRight;
    public static bool canMove;

    [Header("Area booleanas")]
    public bool inCafe = false;
    public bool inVomit = false;
    public bool comRoupa = false;
    public static bool controleVomito = false;
    public bool finalAcabou = false;

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
                GameManager.horaVomito = true;
                controleVomito = true;
                Destroy(GameObject.Find("AreaCafe"));
                teclaE.gameObject.SetActive(false);
            }
        }
        Debug.Log(playerID);
        if (GameManager.horaVomito && playerID == 1 && controleVomito)
        {

            playerRb.position = new Vector3(79, 0.55f, 0);
            controleVomito = false;

        }

        if (GameManager.StartMiniGame)
        {
            canMove = false;
        }

        /*if (TImerController.countdown <= 0)
        {
            GameManager.StartMiniGame = true;
        }*/

        if (finalAcabou)
        {
            SceneManager.LoadScene("Final1");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove /*&& GameManager.canMove*/)
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

    IEnumerator timerFinal()
    {
        yield return new WaitForSeconds(5);
        finalAcabou = true;
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

        if (other.gameObject.CompareTag("Vomito"))
        {
            teclaE.gameObject.SetActive(true);
            if (GameManager.tomouCafe == true)
            {
                DialogController.dialogIndex = 3;
                DialogController.dialogStart = true;
            }
            else
            {
                DialogController.dialogIndex = 2;
                DialogController.dialogStart = true;
            }

        }

        if (other.gameObject.CompareTag("Vomito2"))
        {
            DialogController.dialogIndex = 3;
            DialogController.dialogStart = true;
            GameManager.lembroDaRoupa = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("ChegouVomito"))
        {
            vomito.SetActive(false);
            TImerController.isVomiting = false;
            Destroy(other.gameObject);
            DialogController.dialogIndex = 6;
            DialogController.dialogStart = true;
            TImerController.cleanTimer = true;
        }

        if (other.gameObject.CompareTag("Roupa"))
        {
            DialogController.dialogIndex = 6;
            DialogController.dialogStart = true;
            semRoupaSprite.gameObject.SetActive(false);
            comRoupaSprite.gameObject.SetActive(true);
            mala.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Mala"))
        {
            DialogController.dialogIndex = 7;
            DialogController.dialogStart = true;
            chave.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Chave"))
        {
            DialogController.dialogIndex = 8;
            DialogController.dialogStart = true;
            saida.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Saida"))
        {
            DialogController.dialogIndex = 9;
            DialogController.dialogStart = true;
            pensandoLixo.SetActive(true);
            canMove = false;
            StartCoroutine(timerFinal());
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cafe"))
        {
            teclaE.gameObject.SetActive(false);
            inCafe = false;
        }

        if (other.gameObject.CompareTag("Vomito"))
        {
            teclaE.gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Vomito") && GameManager.tomouCafe && GameManager.lembroDaRoupa)
        {
            GameManager.StartMiniGame = true;
            //playerRb.position = new Vector3(125, 0.55f, -10);
            DialogController.dialogIndex = 4;
            DialogController.dialogStart = true;
        }
        if (collision.gameObject.CompareTag("Vomito") && GameManager.tomouCafe && !GameManager.lembroDaRoupa)
        {
            DialogController.dialogIndex = 5;
            DialogController.dialogStart = true;
        }
        if (collision.gameObject.CompareTag("Vomito") && !GameManager.tomouCafe && !GameManager.lembroDaRoupa)
        {
            DialogController.dialogIndex = 1;
            DialogController.dialogStart = true;
        }


    }
}

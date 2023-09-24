using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playerMundo1;
    public GameObject playerMundo2;

    public GameObject camera1;
    public GameObject camera2;

    public GameObject areaPreta;
    public GameObject areaVomito;
    public GameObject miniGamePanel;

    public static bool tomouCafe = false;
    public static bool horaVomito = false;
    public static bool lembroDaRoupa = false;
    public static bool StartMiniGame = false;
    public static bool InMiniGame = false;
    public static bool miniGameCompleto = false;
    public static bool tiraPreto = false;
    public static bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeView();
        }

        if (tomouCafe)
        {
            areaPreta.gameObject.SetActive(false);
        }

        if (StartMiniGame)
        {
            //StartCoroutine(CooldownTelaPreta());
            playerMundo1.transform.position = new Vector3 (playerMundo1.transform.position.x + 2, playerMundo1.transform.position.y, playerMundo1.transform.position.z);
            areaPreta.gameObject.SetActive(true);
            miniGamePanel.SetActive(true);
            ChangeView();
            playerMundo2.transform.position = new Vector3(125, 0.55f, -10);
            StartMiniGame = false;
        }

        if (tiraPreto)
        {
            areaPreta.gameObject.SetActive(false);
            tiraPreto = false;
        }


    }

    public void ChangeView()
    {
        if (playerMundo1.activeInHierarchy == true)
        {
            playerMundo2.SetActive(true);
            camera2.SetActive(true);
            playerMundo1.SetActive(false);
            camera1.SetActive(false);
        }
        else if (playerMundo2.activeInHierarchy == true)
        {
            playerMundo1.SetActive(true);
            camera1.SetActive(true);
            playerMundo2.SetActive(false);
            camera2.SetActive(false);
        }
    }

    IEnumerator CooldownTelaPreta()
    {
        areaPreta.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        StartMiniGame = false;
    }

    public void IsVomiting()
    {
        TImerController.isVomiting = true;
        areaVomito.SetActive(true);
    }
}

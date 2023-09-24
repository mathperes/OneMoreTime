using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playerMundo1;
    public GameObject playerMundo2;

    public GameObject camera1;
    public GameObject camera2;

    public GameObject areaPreta;
    public static bool tomouCafe = false;
    public static bool horaVomito = false;

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
    }

    void ChangeView()
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

    void Tutorial()
    {

    }
}

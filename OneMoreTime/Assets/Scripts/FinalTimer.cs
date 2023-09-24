using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTimer : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 15;   
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if (timer < 0)
        {
            SceneManager.LoadScene("Final2");
        }
    }
}

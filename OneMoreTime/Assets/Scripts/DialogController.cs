using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public string[] dialogContent;
    public int dialogIndex = 0;
    public float chatSpeed;

    public bool canDialog = true;

    // Start is called before the first frame update
    void Start()
    {
        chatSpeed = 0.025f;
        dialogPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            
        if(canDialog)
        {
            canDialog = false;
            StartDialog();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CleanDialog();
        }
    }

    IEnumerator ShowDialog()
    {
        foreach (var letter in dialogContent[dialogIndex])
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(chatSpeed);
        }        
    }

    void StartDialog()
    {
        dialogPanel.SetActive(true);
        StartCoroutine(ShowDialog());        
    }

    void CleanDialog()
    {
        dialogText.text = "";
        dialogPanel.SetActive(false);
        PlayerController.canMove = true;
    }
}

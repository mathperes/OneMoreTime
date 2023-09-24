using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject tutorialPanel;    
    public TextMeshProUGUI dialogText;
    public string[] dialogContent;
    public static int dialogIndex = 0;
    public float chatSpeed;

    public bool canDialog = true;
    public bool firstTutorial = true;
    public static bool dialogStart = false;
    

    // Start is called before the first frame update
    void Start()
    {
        chatSpeed = 0.015f;
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

        if(dialogStart)
        {
            dialogStart = false;
            StartDialog();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CleanDialog();
        }

        if (firstTutorial)
        {
            TutorialText();
        }


    }

    IEnumerator ShowDialog(int index)
    {
        foreach (var letter in dialogContent[index])
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(chatSpeed);
        }        
    }

    public void StartDialog()
    {
        dialogPanel.SetActive(true);
        StartCoroutine(ShowDialog(dialogIndex));        
    }

    void CleanDialog()
    {
        dialogText.text = "";
        dialogPanel.SetActive(false);
        PlayerController.canMove = true;
    }

    void TutorialText()
    {
        tutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        firstTutorial = false;
    }
}

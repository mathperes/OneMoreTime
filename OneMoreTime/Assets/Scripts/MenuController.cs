using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelTutorial;
    [SerializeField] private GameObject painelTutorialDois;
    [SerializeField] private GameObject painelTutorialTres;
    public void Jogoar() 
    {
        SceneManager.LoadScene(1);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
        
    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
        
    }

    public void AbrirTutorial()
    {
        painelMenuInicial.SetActive(false);
        painelTutorial.SetActive(true);
    }

    public void AbrirTutorialDois()
    {
        painelTutorial.SetActive(false);
        painelTutorialDois.SetActive(true);
    }

    public void AbrirTutorialTres()
    {
        painelTutorialDois.SetActive(false);
        painelTutorialTres.SetActive(true);
    }

    public void FecharTutorial()
    {
        painelTutorialTres.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Sair do jogo");
    }
}

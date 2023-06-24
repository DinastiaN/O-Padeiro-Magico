using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuJogo : MonoBehaviour
{
    [Header("Botões do Menu")]

    [SerializeField] private Button NewGameButton;
    [SerializeField] private Button ContinueButton;
    [SerializeField] private GameObject painelMainMenu;
    [SerializeField] private GameObject painelOpcoes;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if (!DataPersistenceManager.instance.HasGameData())
        {
            ContinueButton.interactable = false;
        }
    }
    public void Jogar()
    {
        DesativarBotoes();
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("Jogo");
    }

    public void Continuar()
    {
        DesativarBotoes();
        SceneManager.LoadScene(1);
    }

    public void Opcoes()
    {
        painelMainMenu.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMainMenu.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("Fechar o Jogo.");
        Application.Quit();
    }

    private void DesativarBotoes()
    {
        NewGameButton.interactable = false;
        ContinueButton.interactable = false;
    }
}

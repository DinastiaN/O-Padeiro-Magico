using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuPausa;
    [SerializeField] private GameObject painelOpcoes;

    private bool menuAberto = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuAberto)
                AbrirMenu();
            else
                FecharMenu();
        }
    }

    public void AbrirMenu()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        painelMenuPausa.SetActive(true);
        menuAberto = true;
    }

    public void FecharMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        painelMenuPausa.SetActive(false);
        menuAberto = false;
    }

    public void SairJogo()
    {
        Debug.Log("Fechar o Jogo.");
        Application.Quit();
    }

    public void ResumirJogo()
    {
        FecharMenu();
    }

    public void VoltarMenuInicial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void AbrirOpcoes()
    {
        painelOpcoes.SetActive(true);
        painelMenuPausa.SetActive(false);
    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuPausa.SetActive(true);
    }

    public void Salvar()
    {
        DataPersistenceManager.instance.SaveGame();
    }
}
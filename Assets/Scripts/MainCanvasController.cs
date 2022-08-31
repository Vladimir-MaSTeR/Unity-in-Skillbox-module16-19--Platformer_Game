using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvasController : MonoBehaviour
{
    [Header("Панели главного меню")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject autorPanel;

    private void Awake()
    {
        autorPanel.SetActive(false);
        mainPanel.SetActive(true);
    }


    public void onClickAutorButton()
    {
        autorPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void onClickExitAutorButton()
    {
        autorPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void onClickQuitGameButton()
    {
        Application.Quit();
    }

    


    public void OnClickRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

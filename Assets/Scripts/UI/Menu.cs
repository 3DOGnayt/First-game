using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu = null;
    [SerializeField] private GameObject settingsMenu = null;

    [Space]
    [SerializeField] private Button startGame = null;
    [SerializeField] private Button showSettings = null;
    [SerializeField] private Button quiteGame = null;

    private void Awake()
    {
        startGame.onClick.AddListener(StartGame);
        showSettings.onClick.AddListener(ShowSettings);
        quiteGame.onClick.AddListener(QuiteGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ShowSettings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    private void QuiteGame()
    {
        Application.Quit();
    }
}

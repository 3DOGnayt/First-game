using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsInGame : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu = null;

    [Space]
    [SerializeField] private Toggle mute = null;
    [SerializeField] private Slider volume = null;
    [SerializeField] private Button closePanelGame = null;
    [SerializeField] private Button returnInMenu = null;
        
    private void Awake()
    {
        volume.onValueChanged.AddListener(SetVolume);
        mute.onValueChanged.AddListener(MuteGame);
        closePanelGame.onClick.AddListener(Resume);
        returnInMenu.onClick.AddListener(ReturnInMenu);
    }
       
    private void Resume()
    {
        Time.timeScale = 1f;
        settingsMenu.SetActive (false);
    }

    private void SetVolume(float value)
    {
        GameSettings.instance.volume = (int)value;
    }

    private void MuteGame(bool value)
    {
        GameSettings.instance.mute = value; 
    }
    
    private void ReturnInMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

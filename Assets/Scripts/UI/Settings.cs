using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu = null;
    [SerializeField] private GameObject settingsMenu = null;

    [Space]
    [SerializeField] private Toggle mute = null;
    [SerializeField] private Slider volume = null;

    [Space]
    [SerializeField] private Button closePanelGame = null;
    
    private void Awake()
    {
        volume.onValueChanged.AddListener(SetVolume);        
        mute.onValueChanged.AddListener(MuteGame);
        closePanelGame.onClick.AddListener(ShowSettings);
    }

    private void SetVolume(float value)
    {
        GameSettings.instance.volume = (int)value;
    }
    private void MuteGame(bool value)
    {
        GameSettings.instance.mute = value;
    }
    private void ShowSettings()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

}

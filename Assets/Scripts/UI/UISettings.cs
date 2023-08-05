using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISettings : MonoBehaviour
{
    [SerializeField] private Slider BGM_slider;
    [SerializeField] private Slider SFX_slider;
    [SerializeField] private GameObject ExitToMenuButton;
    
    public void Init()
    {
        BGM_slider.value = GameConfig.BGM_VOLUME;
        SFX_slider.value = GameConfig.SFX_VOLUME;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(GameConstant.SCENE_MAINMENU))
        {
            ExitToMenuButton.SetActive(false);
        }
        else
        {
            ExitToMenuButton.SetActive(true);
        }
    }
    public void SetBGMVolume()
    {
        GameConfig.BGM_VOLUME = BGM_slider.value;
    }
    public void SetSFXVolume()
    {
        GameConfig.SFX_VOLUME = SFX_slider.value;
    }
    public void Close()
    {
        Destroy(gameObject);
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(GameConstant.SCENE_MAINMENU);        
    }
}

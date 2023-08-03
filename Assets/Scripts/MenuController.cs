using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private UISettings UISettings;
    [SerializeField] private GameObject Menu;
    private UISettings uiSettings;
    [SerializeField] private TMP_InputField PlayerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM(BackgroundMusic.BGM_01);
    }

    // Update is called once per frame
    void Update()
    {
        GameConfig.PLAYER_NAME = PlayerNameInput.text;
    }
    public void Multiplayer()
    {
        LoadingData.sceneToLoad = GameConstant.SCENE_LOBBY;
        SceneManager.LoadSceneAsync(GameConstant.SCENE_LOBBY);
        SoundManager.Instance.StopBGM();
    }
    public void Play()
    {
        if (string.IsNullOrWhiteSpace(PlayerNameInput.text))
        {
            Debug.LogWarning("Player name missing!");
        }
        else
        {
            GameConfig.PLAYER_NAME = PlayerNameInput.text;
            LoadingData.sceneToLoad = GameConstant.SCENE_GAMEPLAY;
            SceneManager.LoadSceneAsync(GameConstant.SCENE_LOADING);
            SoundManager.Instance.StopBGM();
        }
    }
    public void Settings()
    {
        SoundManager.Instance.PlaySFX(SoundEffect.SFX_01);
        uiSettings = Instantiate(UISettings, GameObject.Find("Canvas").transform);
        uiSettings.Init();
    }
    public void QuitSettings()
    {
        SoundManager.Instance.PlaySFX(SoundEffect.SFX_02);
        uiSettings.Close();
    }
    public void Exit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject Setting;
    [SerializeField] private GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM(BackgroundMusic.BGM_01);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Play();
        }
    }
    public void Multiplayer()
    {
        LoadingData.sceneToLoad = GameConstant.SCENE_LOBBY;
        SceneManager.LoadSceneAsync(GameConstant.SCENE_LOBBY);
        SoundManager.Instance.StopBGM();
    }
    public void Play()
    {
        SceneManager.LoadSceneAsync(GameConstant.SCENE_GAMEPLAY);
        SoundManager.Instance.StopBGM();
    }
    public void Settings()
    {
        Setting.SetActive(true);
        Menu.SetActive(false);
    }
    public void QuitSettings()
    {
        Setting.SetActive(false);
        Menu.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}

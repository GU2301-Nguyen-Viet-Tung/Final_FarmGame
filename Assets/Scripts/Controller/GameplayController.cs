using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private UICropAction UIActionPref;
    [SerializeField] private UIInventory UIInventory;
    [SerializeField] private UICollect UICollect;
    private UICropAction uiAction;
    private UIInventory uiInventory;
    private UICollect uiCollect;


    [SerializeField] private UISettings UISettings;
    private UISettings uiSettings;
    // Start is called before the first frame update
    private void Start()
    {
        SoundManager.Instance.PlayBGM(BackgroundMusic.BGM_02);
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Menu();
        }
    }
    private void Menu()
    {
        SceneManager.LoadSceneAsync(GameConstant.SCENE_MAINMENU);
        SoundManager.Instance.StopBGM();
    }
    public void ShowCropAction(CropPlan crop)
    {
        uiAction = Instantiate(UIActionPref, GameObject.Find("UI").transform);
        uiAction.Init(this, crop);
        //UIAction.Init(this, crop);
    }
    public void HideCropAction()
    {
        uiAction.Hide();
        //Destroy(uiAction.gameObject);
    }
    public void OpenInventory()
    {
        SoundManager.Instance.PlaySFX(SoundEffect.SFX_01);
        uiInventory = Instantiate(UIInventory, GameObject.Find("UI").transform);
        uiInventory.Init(this);
    }
    public void CloseInventory()
    {
        SoundManager.Instance.PlaySFX(SoundEffect.SFX_02);
        uiInventory.Close();
        //Destroy(uiInventory.gameObject);
    }
    public void ShowCollectAction(Collectable collect)
    {
        uiCollect = Instantiate(UICollect, GameObject.Find("UI").transform);
        uiCollect.Init(this, collect);
        //uiCollect.Init(this, collect);
    }
    public void HideCollectAction()
    {
        uiCollect.Hide();
        //Destroy(uiCollect.gameObject);
    }
    public void Settings()
    {
        SoundManager.Instance.PlaySFX(SoundEffect.SFX_01);
        uiSettings = Instantiate(UISettings, GameObject.Find("UI").transform);
        uiSettings.Init();
    }
    public void QuitSettings()
    {
        SoundManager.Instance.PlaySFX(SoundEffect.SFX_02);
        uiSettings.Close();
    }
}


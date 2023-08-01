using System.Collections;
using System.Collections.Generic;
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
        uiInventory = Instantiate(UIInventory, GameObject.Find("UI").transform);
        uiInventory.Init(this);
    }
    public void CloseInventory()
    {
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
    /*
    public void Carrot()
    {
        //CropPlan.Carrot();
        Player.Carrot();
    }
    public void Corn()
    {
        //CropPlan.Corn();
        Player.Corn();
    }
    public void Eggplant()
    {
        //CropPlan.Eggplant();
        Player.Eggplant();
    }
    public void Pumpkin()
    {
        //CropPlan.Pumpkin();
        Player.Pumpkin();
    }
    public void Tomato()
    {
        //CropPlan.Tomato();
        Player.Tomato();
    }
    public void Turnip()
    {
        //CropPlan.Turnip();
        Player.Turnip();
    }
    */
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropPlan : MonoBehaviour
{
    [SerializeField] private GameObject carrot;
    [SerializeField] private GameObject corn;
    [SerializeField] private GameObject eggplant;
    [SerializeField] private GameObject pumpkin;
    [SerializeField] private GameObject tomato;
    [SerializeField] private GameObject turnip;
    [SerializeField] private List<GameObject> CarrotList;
    [SerializeField] private List<GameObject> CornList;
    [SerializeField] private List<GameObject> EggplantList;
    [SerializeField] private List<GameObject> PumpkinList;
    [SerializeField] private List<GameObject> TomatoList;
    [SerializeField] private List<GameObject> TurnipList;
    public MudState mudState = MudState.NONE;
    [SerializeField] private float time;
    [SerializeField] private int PlantTime = 10;
    private GameplayController controller;
    private bool UIActive = false;
    public int plantType;
    public enum MudState{
        NONE,
        PLANTING,
        DONE
    }
    private void Start()
    {
        controller = GameObject.Find("GameplayController").GetComponent<GameplayController>();
    }
    private void Update()
    {
        //float a = time/PlantTime;
        if (mudState == MudState.NONE)
        {
            time = 0;
        }
        else if (mudState == MudState.PLANTING)
        {
            float scaleVal = time / PlantTime;
            time += Time.deltaTime;
            if(time > PlantTime)
            {
                mudState = MudState.DONE;
                if (UIActive == true)
                {
                    controller.HideCropAction();
                    controller.ShowCropAction(this);
                }
            }
            switch (plantType)
            {
                case 1:
                    foreach (GameObject carrot in CarrotList)
                    {
                        carrot.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
                    }
                    break;
                case 2:
                    foreach (GameObject corn in CornList)
                    {
                        corn.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
                    }
                    break;
                case 3:
                    foreach (GameObject eggplant in EggplantList)
                    {
                        eggplant.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
                    }
                    break;
                case 4:
                    foreach (GameObject pumpkin in PumpkinList)
                    {
                        pumpkin.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
                    }
                    break;
                case 5:
                    foreach (GameObject tomato in TomatoList)
                    {
                        tomato.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
                    }
                    break;
                case 6:
                    foreach (GameObject turnip in TurnipList)
                    {
                        turnip.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
                    }
                    break;
            }
        }
        //else if (mudState == MudState.DONE)
        //{

        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstant.TAG_PLAYER))
        {
            controller.ShowCropAction(this);
            UIActive = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameConstant.TAG_PLAYER))
        {
            controller.HideCropAction();
            UIActive = false;
        }
    }
    public void Crop(int plant)
    {
        switch (plant)
        {
            case 1:
                if(PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_01) == 0)
                {
                    plantType = -1;
                    break;
                }
                carrot.SetActive(true);
                corn.SetActive(false);
                eggplant.SetActive(false);
                pumpkin.SetActive(false);
                tomato.SetActive(false);
                turnip.SetActive(false);
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_01, 1);
                mudState = MudState.PLANTING;
                plantType = 1;
                break;
            case 2:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_02) == 0)
                {
                    plantType = -1;
                    break;
                }
                carrot.SetActive(false);
                corn.SetActive(true);
                eggplant.SetActive(false);
                pumpkin.SetActive(false);
                tomato.SetActive(false);
                turnip.SetActive(false);
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_02, 1);
                mudState = MudState.PLANTING;
                plantType = 2;
                break;
            case 3:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_03) == 0)
                {
                    plantType = -1;
                    break;
                }
                carrot.SetActive(false);
                corn.SetActive(false);
                eggplant.SetActive(true);
                pumpkin.SetActive(false);
                tomato.SetActive(false);
                turnip.SetActive(false);
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_03, 1);
                mudState = MudState.PLANTING;
                plantType = 3;
                break;
            case 4:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_04) == 0)
                {
                    plantType = -1;
                    break;
                }
                carrot.SetActive(false);
                corn.SetActive(false);
                eggplant.SetActive(false);
                pumpkin.SetActive(true);
                tomato.SetActive(false);
                turnip.SetActive(false);
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_04, 1);
                mudState = MudState.PLANTING;
                plantType = 4;
                break;
            case 5:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_05) == 0)
                {
                    plantType = -1;
                    break;
                }
                carrot.SetActive(false);
                corn.SetActive(false);
                eggplant.SetActive(false);
                pumpkin.SetActive(false);
                tomato.SetActive(true);
                turnip.SetActive(false);
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_05, 1);
                mudState = MudState.PLANTING;
                plantType = 5;
                break;
            case 6:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_06) == 0)
                {
                    plantType = -1;
                    break;
                }
                carrot.SetActive(false);
                corn.SetActive(false);
                eggplant.SetActive(false);
                pumpkin.SetActive(false);
                tomato.SetActive(false);
                turnip.SetActive(true);
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_06, 1);
                mudState = MudState.PLANTING;
                plantType = 6;
                break;
            default:
                switch (plantType)
                {
                    case 1:
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_01, 9);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_01, 5);
                        break;
                    case 2:
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_02, 9);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_02, 5);
                        break;
                    case 3:
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_03, 9);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_03, 5);
                        break;
                    case 4:
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_04, 9);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_04, 5);
                        break;
                    case 5:
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_05, 9);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_05, 5);
                        break;
                    case 6:
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_06, 9);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_06, 5);
                        break;
                }
                carrot.SetActive(false);
                corn.SetActive(false);
                eggplant.SetActive(false);
                pumpkin.SetActive(false);
                tomato.SetActive(false);
                turnip.SetActive(false);
                mudState = MudState.NONE;
                plantType = 0;
                break;
        }
        if (plantType == 0)
        {
            PlayerProfile.Instance.IncreaseCoin(500);
        }
        else if(plantType == -1)
        {
            Debug.LogWarning("No seed");
        }
        else
        {
            PlayerProfile.Instance.DecreaseCoin(100);
        }
        controller.HideCropAction();
        controller.ShowCropAction(this);
    }
}

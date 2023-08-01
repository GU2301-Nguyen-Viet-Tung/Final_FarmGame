using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static CropPlan;

public class UICropAction : MonoBehaviour
{
    [SerializeField] private Button CarrotButton;
    [SerializeField] private TextMeshProUGUI CarrotNumber;
    [SerializeField] private Button CornButton;
    [SerializeField] private TextMeshProUGUI CornNumber;
    [SerializeField] private Button EggplantButton;
    [SerializeField] private TextMeshProUGUI EggplantNumber;
    [SerializeField] private Button PumpkinButton;
    [SerializeField] private TextMeshProUGUI PumpkinNumber;
    [SerializeField] private Button TomatoButton;
    [SerializeField] private TextMeshProUGUI TomatoNumber;
    [SerializeField] private Button TurnipButton;
    [SerializeField] private TextMeshProUGUI TurnipNumber;
    [SerializeField] private Image HarvestImage;
    [SerializeField] private Button HarvestButton;
    [SerializeField] private GameObject PlantButton;
    [SerializeField] private TextMeshProUGUI PlantingTxt;
    [SerializeField] private GameObject Harvest;

    private GameplayController gameplayController;
    public void Init(GameplayController controller, CropPlan crop)
    {
        gameplayController = controller;
        CarrotNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_01).ToString();
        CornNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_02).ToString();
        EggplantNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_03).ToString();
        PumpkinNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_04).ToString();
        TomatoNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_05).ToString();
        TurnipNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_06).ToString();
        switch (crop.mudState)
        {
            case MudState.NONE:
                PlantButton.SetActive(true);
                PlantingTxt.gameObject.SetActive(false);
                Harvest.SetActive(false);
                CarrotButton.onClick.RemoveAllListeners();
                CarrotButton.onClick.AddListener(delegate { crop.Crop(1); });
                CornButton.onClick.RemoveAllListeners();
                CornButton.onClick.AddListener(delegate { crop.Crop(2); });
                EggplantButton.onClick.RemoveAllListeners();
                EggplantButton.onClick.AddListener(delegate { crop.Crop(3); });
                PumpkinButton.onClick.RemoveAllListeners();
                PumpkinButton.onClick.AddListener(delegate { crop.Crop(4); });
                TomatoButton.onClick.RemoveAllListeners();
                TomatoButton.onClick.AddListener(delegate { crop.Crop(5); });
                TurnipButton.onClick.RemoveAllListeners();
                TurnipButton.onClick.AddListener(delegate { crop.Crop(6); });
                break;
            case MudState.PLANTING:
                PlantButton.SetActive(false);
                PlantingTxt.gameObject.SetActive(true);
                Harvest.SetActive(false);
                break;
            case MudState.DONE:
                PlantButton.SetActive(false);
                PlantingTxt.gameObject.SetActive(false);
                Harvest.SetActive(true);
                switch (crop.plantType)
                {
                    case 1:
                        HarvestImage.sprite = GameDataManager.Instance.GetItemSprite(GameItemId.ITEM_HARVESTED_01);
                        break;
                    case 2:
                        HarvestImage.sprite = GameDataManager.Instance.GetItemSprite(GameItemId.ITEM_HARVESTED_02);
                        break;
                    case 3:
                        HarvestImage.sprite = GameDataManager.Instance.GetItemSprite(GameItemId.ITEM_HARVESTED_03);
                        break;
                    case 4:
                        HarvestImage.sprite = GameDataManager.Instance.GetItemSprite(GameItemId.ITEM_HARVESTED_04);
                        break;
                    case 5:
                        HarvestImage.sprite = GameDataManager.Instance.GetItemSprite(GameItemId.ITEM_HARVESTED_05);
                        break;
                    case 6:
                        HarvestImage.sprite = GameDataManager.Instance.GetItemSprite(GameItemId.ITEM_HARVESTED_06);
                        break;
                }                
                HarvestButton.onClick.RemoveAllListeners();
                HarvestButton.onClick.AddListener(delegate { crop.Crop(0); });
                break;
            default:
                break;
        }
    }
    public void Hide() 
    {
        Destroy(gameObject);
    }
}

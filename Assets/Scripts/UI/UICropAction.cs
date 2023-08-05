using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static CropPlan;

public class UICropAction : MonoBehaviour
{
    [SerializeField] private Button HoeButton;

    [SerializeField] private Button BrokolyButton;
    [SerializeField] private TextMeshProUGUI BrokolyNumber;
    [SerializeField] private Button CabbageButton;
    [SerializeField] private TextMeshProUGUI CabbageNumber;
    [SerializeField] private Button CarrotButton;
    [SerializeField] private TextMeshProUGUI CarrotNumber;
    [SerializeField] private Button CornButton;
    [SerializeField] private TextMeshProUGUI CornNumber;
    [SerializeField] private Button CucumberButton;
    [SerializeField] private TextMeshProUGUI CucumberNumber;
    [SerializeField] private Button EggplantButton;
    [SerializeField] private TextMeshProUGUI EggplantNumber;
    [SerializeField] private Button PumpkinButton;
    [SerializeField] private TextMeshProUGUI PumpkinNumber;
    [SerializeField] private Button TomatoButton;
    [SerializeField] private TextMeshProUGUI TomatoNumber;

    [SerializeField] private Button WaterButton;

    [SerializeField] private Image HarvestImage;
    [SerializeField] private Button HarvestButton;

    [SerializeField] private GameObject Hoe;
    [SerializeField] private GameObject Plant;
    [SerializeField] private GameObject Water;
    [SerializeField] private GameObject PlantingTxt;
    [SerializeField] private GameObject Harvest;

    private GameplayController gameplayController;
    public void Init(GameplayController controller, CropPlan crop)
    {
        gameplayController = controller;
        BrokolyNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_01).ToString();
        CabbageNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_02).ToString();
        CarrotNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_03).ToString();
        CornNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_04).ToString();
        CucumberNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_05).ToString();
        EggplantNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_06).ToString();
        PumpkinNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_07).ToString();
        TomatoNumber.text = PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_08).ToString();
        switch (crop.mudState)
        {
            case MudState.NONE:
                Hoe.SetActive(true);
                Plant.SetActive(false);
                Water.SetActive(false);
                PlantingTxt.SetActive(false);
                Harvest.SetActive(false);

                HoeButton.onClick.RemoveAllListeners();
                HoeButton.onClick.AddListener(delegate { crop.Hoe(); });
                break;

            case MudState.READY:
                Hoe.SetActive(false);
                Plant.SetActive(true);
                Water.SetActive(false);
                PlantingTxt.SetActive(false);
                Harvest.SetActive(false);

                BrokolyButton.onClick.RemoveAllListeners();
                BrokolyButton.onClick.AddListener(delegate { crop.Crop(1); });
                CabbageButton.onClick.RemoveAllListeners();
                CabbageButton.onClick.AddListener(delegate { crop.Crop(2); });
                CarrotButton.onClick.RemoveAllListeners();
                CarrotButton.onClick.AddListener(delegate { crop.Crop(3); });
                CornButton.onClick.RemoveAllListeners();
                CornButton.onClick.AddListener(delegate { crop.Crop(4); });
                CucumberButton.onClick.RemoveAllListeners();
                CucumberButton.onClick.AddListener(delegate { crop.Crop(5); });
                EggplantButton.onClick.RemoveAllListeners();
                EggplantButton.onClick.AddListener(delegate { crop.Crop(6); });
                PumpkinButton.onClick.RemoveAllListeners();
                PumpkinButton.onClick.AddListener(delegate { crop.Crop(7); });
                TomatoButton.onClick.RemoveAllListeners();
                TomatoButton.onClick.AddListener(delegate { crop.Crop(8); });
                break;

            case MudState.WATERING:
                Hoe.SetActive(false);
                Plant.SetActive(false);
                Water.SetActive(true);
                PlantingTxt.SetActive(false);
                Harvest.SetActive(false);

                WaterButton.onClick.RemoveAllListeners();
                WaterButton.onClick.AddListener(delegate { crop.Water(); });
                break;

            case MudState.PLANTING:
                Hoe.SetActive(false);
                Plant.SetActive(false);
                Water.SetActive(false);
                PlantingTxt.SetActive(true);
                Harvest.SetActive(false);
                break;

            case MudState.DONE:
                Hoe.SetActive(false);
                Plant.SetActive(false);
                Water.SetActive(false);
                PlantingTxt.SetActive(false);
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
                    case 7:
                        HarvestImage.sprite = GameDataManager.Instance.GetItemSprite(GameItemId.ITEM_HARVESTED_07);
                        break;
                    case 8:
                        HarvestImage.sprite = GameDataManager.Instance.GetItemSprite(GameItemId.ITEM_HARVESTED_08);
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

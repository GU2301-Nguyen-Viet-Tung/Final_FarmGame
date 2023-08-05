using System.Collections.Generic;
using UnityEngine;

public class CropPlan : MonoBehaviour
{
    [SerializeField] private GameObject PFB_Brokoly;
    [SerializeField] private GameObject PFB_Cabbage;
    [SerializeField] private GameObject PFB_Carrot;
    [SerializeField] private GameObject PFB_Corn;
    [SerializeField] private GameObject PFB_Cucumber;
    [SerializeField] private GameObject PFB_Eggplant;
    [SerializeField] private GameObject PFB_Pumpkin;
    [SerializeField] private GameObject PFB_Tomato;
    [SerializeField] private List<GameObject> Dirt;
    
    public MudState mudState = MudState.NONE;
    [SerializeField] private float time;
    [SerializeField] private int PlantTime = 10;
    private GameplayController controller;
    private bool UIActive = false;
    public int plantType;

    [SerializeField] private ParticleSystem FX_Plow;
    [SerializeField] private ParticleSystem FX_Seed;
    [SerializeField] private ParticleSystem FX_Water;
    [SerializeField] private ParticleSystem FX_Harvest;

    //[SerializeField] private BoxBehavior Boxes;
    [SerializeField] private CropSpawnScript CropSpawnScript;

    public enum MudState{
        NONE,
        READY,
        WATERING,
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
            //gameObject.SetActive(false);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            foreach(GameObject dirt in Dirt)
            {
                dirt.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else if (mudState == MudState.READY)
        {
            time = 0;
            foreach (GameObject dirt in Dirt)
            {
                dirt.SetActive(false);
            }
        }
        else if (mudState == MudState.WATERING)
        {
            foreach (GameObject dirt in Dirt)
            {
                dirt.SetActive(true);
            }
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
            foreach(GameObject dirt in Dirt)
            {
                dirt.transform.GetChild(0).transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
            }
        }
        //else if (mudState == MudState.DONE)
        //{
        //
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
    public void Hoe()
    {
        //gameObject.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundEffect.SFX_03);
        FX_Plow.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        mudState = MudState.READY;
        if (UIActive == true)
        {
            controller.HideCropAction();
            controller.ShowCropAction(this);
        }
    }
    public void Water()
    {
        SoundManager.Instance.PlaySFX(SoundEffect.SFX_05);
        FX_Water.Play();
        mudState = MudState.PLANTING;
        if (UIActive == true)
        {
            controller.HideCropAction();
            controller.ShowCropAction(this);
        }
    }
    public void Crop(int plant)
    {
        if (plant != 0)
        {
            if (!PlayerProfile.Instance.DecreaseCoin(100))
            {
                return;
            }
            foreach (GameObject dirt in Dirt)
            {
                dirt.GetComponent<MeshRenderer>().enabled = true;
            }
            FX_Seed.Play();
            SoundManager.Instance.PlaySFX(SoundEffect.SFX_04);
        }
        switch (plant)
        {
            case 1:
                if(PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_01) == 0)
                {
                    plantType = -1;
                    break;
                }
                foreach (GameObject dirt in Dirt)
                {
                    Instantiate(PFB_Brokoly, dirt.transform);
                }
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_01, 1);
                mudState = MudState.WATERING;
                plantType = 1;
                break;
            case 2:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_02) == 0)
                {
                    plantType = -1;
                    break;
                }
                foreach (GameObject dirt in Dirt)
                {
                    Instantiate(PFB_Cabbage, dirt.transform);
                }
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_02, 1);
                mudState = MudState.WATERING;
                plantType = 2;
                break;
            case 3:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_03) == 0)
                {
                    plantType = -1;
                    break;
                }
                foreach (GameObject dirt in Dirt)
                {
                    Instantiate(PFB_Carrot, dirt.transform);
                }
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_03, 1);
                mudState = MudState.WATERING;
                plantType = 3;
                break;
            case 4:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_04) == 0)
                {
                    plantType = -1;
                    break;
                }
                foreach (GameObject dirt in Dirt)
                {
                    Instantiate(PFB_Corn, dirt.transform);
                }
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_04, 1);
                mudState = MudState.WATERING;
                plantType = 4;
                break;
            case 5:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_05) == 0)
                {
                    plantType = -1;
                    break;
                }
                foreach (GameObject dirt in Dirt)
                {
                    Instantiate(PFB_Cucumber, dirt.transform);
                }
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_05, 1);
                mudState = MudState.WATERING;
                plantType = 5;
                break;
            case 6:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_06) == 0)
                {
                    plantType = -1;
                    break;
                }
                foreach (GameObject dirt in Dirt)
                {
                    Instantiate(PFB_Eggplant, dirt.transform);
                }
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_06, 1);
                mudState = MudState.WATERING;
                plantType = 6;
                break;
            case 7:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_07) == 0)
                {
                    plantType = -1;
                    break;
                }
                foreach (GameObject dirt in Dirt)
                {
                    Instantiate(PFB_Pumpkin, dirt.transform);
                }
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_07, 1);
                mudState = MudState.WATERING;
                plantType = 7;
                break;
            case 8:
                if (PlayerProfile.Instance.CheckItem(GameItemId.ITEM_SEEDS_08) == 0)
                {
                    plantType = -1;
                    break;
                }
                foreach (GameObject dirt in Dirt)
                {
                    Instantiate(PFB_Tomato, dirt.transform);
                }
                PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_SEEDS_08, 1);
                mudState = MudState.WATERING;
                plantType = 8;
                break;
            default:
                foreach (GameObject dirt in Dirt)
                {
                    dirt.GetComponent<MeshRenderer>().enabled = false;
                }
                switch (plantType)
                {
                    case 1:
                        CropSpawnScript.SpawnCrop(GameItemId.ITEM_HARVESTED_01, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_01, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_01, 2);
                        break;
                    case 2:
                        CropSpawnScript.SpawnCrop(GameItemId.ITEM_HARVESTED_02, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_02, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_02, 2);
                        break;
                    case 3:
                        CropSpawnScript.SpawnCrop(GameItemId.ITEM_HARVESTED_03, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_03, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_03, 2);
                        break;
                    case 4:
                        CropSpawnScript.SpawnCrop(GameItemId.ITEM_HARVESTED_04, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_04, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_04, 2);
                        break;
                    case 5:
                        CropSpawnScript.SpawnCrop(GameItemId.ITEM_HARVESTED_05, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_05, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_05, 2);
                        break;
                    case 6:
                        CropSpawnScript.SpawnCrop(GameItemId.ITEM_HARVESTED_06, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_06, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_06, 2);
                        break;
                    case 7:
                        CropSpawnScript.SpawnCrop(GameItemId.ITEM_HARVESTED_07, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_07, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_07, 2);
                        break;
                    case 8:
                        CropSpawnScript.SpawnCrop(GameItemId.ITEM_HARVESTED_08, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_HARVESTED_08, 4);
                        PlayerProfile.Instance.AddGameItem(GameItemId.ITEM_SEEDS_08, 2);
                        break;
                }
                FX_Harvest.Play();
                SoundManager.Instance.PlaySFX(SoundEffect.SFX_06);
                foreach (GameObject dirt in Dirt)
                {                    
                    Destroy(dirt.transform.GetChild(0).gameObject);
                }
                mudState = MudState.READY;
                plantType = 0;
                break;
        }
        if (plantType == 0)
        {
            PlayerProfile.Instance.IncreaseCoin(200);
        }
        else if(plantType == -1)
        {
            Debug.LogWarning("No seed");
        }        
        controller.HideCropAction();
        controller.ShowCropAction(this);
    }
}

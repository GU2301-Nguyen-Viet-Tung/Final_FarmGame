using System.Collections;
using System.Collections.Generic;
using BrokenVector.LowPolyFencePack;
using UnityEngine;

public class CropSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject Cinemachine;
    [SerializeField] private List<DoorController> BoxesLid;
    [SerializeField] private List<GameObject> Boxes;
    [SerializeField] private List<GameObject> PFB_Crops;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(Init());
    }
    private IEnumerator Init()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < PlayerProfile.Instance.CheckItem((GameItemId)(11 + i)); j++)
            {
                Instantiate(PFB_Crops[i], Boxes[i].transform.position + new Vector3(0, 0.25f, 0), Quaternion.identity, transform);
            }
        }
        yield return null;
    }
    public void SpawnCrop(GameItemId id, int number)
    {
        switch (id)
        {
            case GameItemId.ITEM_HARVESTED_01:
                Spawn(0, number);
                break;
            case GameItemId.ITEM_HARVESTED_02:
                Spawn(1, number);
                break;
            case GameItemId.ITEM_HARVESTED_03:
                Spawn(2, number);
                break;
            case GameItemId.ITEM_HARVESTED_04:
                Spawn(3, number);
                break;
            case GameItemId.ITEM_HARVESTED_05:
                Spawn(4, number);
                break;
            case GameItemId.ITEM_HARVESTED_06:
                Spawn(5, number);
                break;
            case GameItemId.ITEM_HARVESTED_07:
                Spawn(6, number);
                break;
            case GameItemId.ITEM_HARVESTED_08:
                Spawn(7, number);
                break;
        }
    }
    private void Spawn(int i, int number)
    {
        for (int j = 0; j < number; j++)
        {
            Instantiate(PFB_Crops[i], Boxes[i].transform.position + new Vector3(0, 0.25f, 0), Quaternion.identity, transform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstant.TAG_PLAYER))
        {
            Cinemachine.transform.Rotate(new Vector3(45, 0, 0));
            foreach(DoorController lid in BoxesLid)
            {
                lid.OpenDoor();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameConstant.TAG_PLAYER))
        {
            Cinemachine.transform.Rotate(new Vector3(-45, 0, 0));
            foreach (DoorController lid in BoxesLid)
            {
                lid.CloseDoor();
            }
        }
    }
}

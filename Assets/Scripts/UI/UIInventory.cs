using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private List<UIItemList> listImage;

    private GameplayController gameplayController;
    public void Init(GameplayController controller)
    {
        gameplayController = controller;
        foreach (UIItemList item in listImage)
        {
            item.Hide();
        }
        int i = 0;
        foreach(GameItems item in PlayerProfile.Instance.SaveData.GameItems)
        {
            listImage[i].Init(item);
            i++;
        }
    }
    public void Close()
    {
        SoundManager.Instance.PlaySFX(SoundEffect.SFX_02);
        Destroy(gameObject);
    }
}

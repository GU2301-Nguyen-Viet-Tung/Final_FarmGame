using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemList : MonoBehaviour
{
    [SerializeField] private Image Img;
    [SerializeField] private TextMeshProUGUI Number;

    public void Init(GameItems item)
    {
        Img.gameObject.SetActive(true);
        Number.gameObject.SetActive(true);
        Img.sprite = GameDataManager.Instance.GetItemSprite(item.Id);
        Number.text = item.Quantity.ToString();
    }
    public void Hide()
    {
        Img.gameObject.SetActive(false);
        Number.gameObject.SetActive(false);
    }
}

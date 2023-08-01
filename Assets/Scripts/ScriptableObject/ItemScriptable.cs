using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ItemUI
{
    public GameItemId gameItemId;
    public Sprite Image;
}
[CreateAssetMenu(fileName = "ItemScriptable",
    menuName = "ScriptableObjects/ItemScriptable", order = 2)]
public class ItemScriptable : ScriptableObject
{
    public List<ItemUI> ListItemUI;
}

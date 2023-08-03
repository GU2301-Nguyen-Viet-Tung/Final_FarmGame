using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameItemId
{
    NONE,
    ITEM_SEEDS_01 = 1,
    ITEM_SEEDS_02,
    ITEM_SEEDS_03,
    ITEM_SEEDS_04,
    ITEM_SEEDS_05,
    ITEM_SEEDS_06,
    ITEM_SEEDS_07,
    ITEM_SEEDS_08,
    ITEM_HARVESTED_01 = 11,
    ITEM_HARVESTED_02,
    ITEM_HARVESTED_03,
    ITEM_HARVESTED_04,
    ITEM_HARVESTED_05,
    ITEM_HARVESTED_06,
    ITEM_HARVESTED_07,
    ITEM_HARVESTED_08
}

[Serializable]
public class GameItems
{
    public GameItemId Id { get; set; }
    public int Quantity { get; set; }
}
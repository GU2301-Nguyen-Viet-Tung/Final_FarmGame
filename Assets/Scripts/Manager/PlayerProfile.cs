using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public string PlayerName { get; set; }
    public long Coin { get; set; }
    public List<GameItems> GameItems { get; set; }
}

public class PlayerProfile : ISingleton<PlayerProfile>
{
    public bool IsInit { get; private set; }
    public SaveData SaveData { get; set; }

    public const string PLAYER_NAME = "NVT";
    public PlayerProfile()
    { 
        IsInit = false;
    }
    public void InitProfile()
    {
        Debug.Log("PlayerProfile InitProfile ");
        FirebaseManger.Instance.ReadProfileData(PLAYER_NAME,
            (rs, data) =>
            {
                if (rs == true && data != null)
                {
                    Debug.Log("PlayerProfile InitProfile success");
                    SaveData = JsonConvert.DeserializeObject<SaveData>(data);
                }
                else
                {
                    Debug.LogWarning("PlayerProfile InitProfile Create new profile");
                    SaveData = new SaveData()
                    {
                        PlayerName = "NVT",
                        Coin = 1000,
                        GameItems = new List<GameItems>()
                    };
                    SaveProfileToServer();
                }
                IsInit = true;
            });
    }
    public static Action ON_COIN_CHANGE { get; set; }
    public void SaveProfileToServer()
    {
        FirebaseManger.Instance.WriteProfileData(PLAYER_NAME, JsonConvert.SerializeObject(SaveData));
    }
    public string GetName()
    {
        return SaveData.PlayerName;
    }
    public long GetCurrentCoin()
    {
        return SaveData.Coin;
    }
    public void IncreaseCoin(long num)
    {
        SaveData.Coin += num;
        ON_COIN_CHANGE?.Invoke();
        SaveProfileToServer();
    }
    public bool DecreaseCoin(long num)
    {
        if(SaveData.Coin > num)
        {
            SaveData.Coin -= num;
            ON_COIN_CHANGE?.Invoke();
            SaveProfileToServer();
            return true;
        }
        else
        {
            return false;
        }
    }
    public int CheckItem(GameItemId itemId)
    {
        GameItems item = SaveData.GameItems.Find(x => x.Id == itemId);
        if (item != null)
        {
            return item.Quantity;
        }
        else
        {
            return 0;
        }
    }
    public void AddGameItem(GameItemId itemId, int number)
    {
        GameItems item = SaveData.GameItems.Find(x => x.Id == itemId);
        if (item != null)
        {
            item.Quantity += number;
        }
        else
        {
            SaveData.GameItems.Add(new GameItems() { Id = itemId, Quantity = number });
        }
        SaveProfileToServer();
    }
    public bool UseGameItem(GameItemId itemId, int number)
    {
        GameItems item = SaveData.GameItems.Find(x => x.Id == itemId);
        if(item.Quantity >= number)
        {
            item.Quantity -= number;
            if (item.Quantity <= 0)
            {
                SaveData.GameItems.Remove(item);
            }

            SaveProfileToServer();
            return true;
        }
        else
        {
            return false;
        }
    }
}

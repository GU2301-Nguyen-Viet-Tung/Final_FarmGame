using UnityEngine;

public class GameDataManager : ISingleton<GameDataManager>
{
    private ItemScriptable itemScriptable;
    public bool IsInit { get; private set; }
    /*
    public GameDataManager()
    {
        itemScriptable = Resources.Load<ItemScriptable>("ItemScriptable");
    }
    */
    public void InitData()
    {
        Debug.Log("GameDataManager InitData ");
        itemScriptable = Resources.Load<ItemScriptable>("ItemScriptable");
        IsInit = true;
    }
    public Sprite GetItemSprite(GameItemId id)
    {
        ItemUI rs = itemScriptable.ListItemUI.Find(x => x.gameItemId == id);
        if (rs == null)
        {
            rs = itemScriptable.ListItemUI[0];
        }
        return rs.Image;
    }
}

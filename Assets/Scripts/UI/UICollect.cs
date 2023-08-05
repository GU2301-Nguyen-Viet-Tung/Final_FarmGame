using UnityEngine;
using UnityEngine.UI;

public class UICollect : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Button collectButton;

    private GameplayController gameplayController;
    public void Init(GameplayController controller, Collectable collect)
    {
        gameplayController = controller;
        img.sprite = GameDataManager.Instance.GetItemSprite(collect.id);
        collectButton.onClick.RemoveAllListeners();
        collectButton.onClick.AddListener(delegate { collect.Collect(); });
    }
    public void Hide()
    {
        Destroy(gameObject);
    }
}

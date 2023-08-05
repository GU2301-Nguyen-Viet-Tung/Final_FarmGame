using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameItemId id;
    [SerializeField] private float time;
    [SerializeField] private int RespawnTime = 10;
    [SerializeField] private bool collected = false;
    private GameplayController controller;
    private void Start()
    {
        controller = GameObject.Find("GameplayController").GetComponent<GameplayController>();
    }
    private void Update()
    {
        gameObject.transform.Rotate(0, 1, 0, Space.Self);
        if (collected == true)
        {
            time += Time.deltaTime;
            if (time > RespawnTime)
            {
                //gameObject.SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<SphereCollider>().enabled = true;
                collected = false;
                time = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstant.TAG_PLAYER))
        {
            controller.ShowCollectAction(this);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameConstant.TAG_PLAYER))
        {
            controller.HideCollectAction();
        }
    }
    public void Collect()
    {
        if (!PlayerProfile.Instance.DecreaseCoin(50))
        {
            return;
        }
        if (PlayerProfile.Instance.GetCurrentCoin() == 100)
        {
            Debug.LogWarning("You should plant something first!");
            return;
        }
        SoundManager.Instance.PlaySFX(SoundEffect.SFX_01);
        PlayerProfile.Instance.AddGameItem(id, 1);
        controller.HideCollectAction();
        //gameObject.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        collected = true;
        //Destroy(gameObject);
    }
}

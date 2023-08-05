using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    // Start is called before the first frame update
    private void Start()
    {
        if (LoadingData.sceneToLoad == GameConstant.SCENE_MAINMENU)
        {
            StartCoroutine(LoadingStepMenu());
        }
        if (LoadingData.sceneToLoad == GameConstant.SCENE_GAMEPLAY)
        {
            StartCoroutine(LoadingStepGameplay());
        }
    }
    private IEnumerator LoadingStepMenu()
    {
        Slider.value = 0f;
        Debug.Log("LoadingController LoadingStep 0 ");
        GameDataManager.Instance.InitData();
        yield return new WaitUntil(() => (GameDataManager.Instance.IsInit == true));
        Slider.value = 0.2f;
        Debug.Log("LoadingController LoadingStep 1 ");
        //NotificationManager.Instance.RequestNotificationPermission();
        //yield return new WaitUntil(() => (NotificationManager.Instance.IsInit == true));
        Slider.value = 0.4f;
        Debug.Log("LoadingController LoadingStep 2 ");
        FirebaseManger.Instance.InitFirebase();
        yield return new WaitUntil(() => (FirebaseManger.Instance.IsInit == true));
        Slider.value = 0.6f;
        Debug.Log("LoadingController LoadingStep 3 ");
        //TransactionServer.Instance.Init();
        //yield return new WaitUntil(() => (TransactionServer.Instance.IsInit == true));
        Slider.value = 0.8f;
        Debug.Log("LoadingController LoadingStep 4 ");
        //PlayerProfile.Instance.InitProfile();
        //yield return new WaitUntil(() => (PlayerProfile.Instance.IsInit == true));
        Slider.value = 1f;
        Debug.Log("LoadingController LoadingStep 5 ");
        SceneManager.LoadScene(GameConstant.SCENE_MAINMENU);
        //Slider.value = 1f;
        yield return null;
    }
    private IEnumerator LoadingStepGameplay()
    {
        Slider.value = 0;
        PlayerProfile.Instance.InitProfile();
        yield return new WaitUntil(() => (PlayerProfile.Instance.IsInit == true));
        Slider.value = 1f;
        SceneManager.LoadScene(GameConstant.SCENE_GAMEPLAY);
        yield return null;
    }
}

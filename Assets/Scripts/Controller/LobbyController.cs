using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LobbyController : MonoBehaviour
{
    public static string LOBBY_NAME => "NongTrai01";

    [SerializeField] private UIRoomInfo RoomInfoPref;
    [SerializeField] private NetworkRunner RunnerPref;

    [SerializeField] private NetworkSceneManagerDefault NetworkSceneManagerDefault;
    [SerializeField] private GameObject ListRoom;
    [SerializeField] private GameObject WaitingPanel;

    [SerializeField] private TMP_InputField RoomNameInput;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtNumber;

    private SessionInfo CurrentRoom;


    private void OnEnable()
    {
        FusionManager.ON_SESSION_LIST_UPDATED += UpdateListRoom;
    }

    private void OnDisable()
    {
        FusionManager.ON_SESSION_LIST_UPDATED -= UpdateListRoom;
    }


    private void Start()
    {
        WaitingPanel.SetActive(true);
        StartCoroutine(LoadLobby());
        txtName.text = "";
        txtNumber.text = "";
    }
    private IEnumerator LoadLobby()
    {
        NetworkRunner runner = Instantiate(RunnerPref);
        FusionManager.Instance.Init(runner, NetworkSceneManagerDefault);
        yield return new WaitUntil(() => (FusionManager.Instance.IsInit == true));
        FusionManager.Instance.JoinLobby(LOBBY_NAME);
        yield return new WaitForSeconds(3);
        WaitingPanel.SetActive(false);
        yield return null;
    }


    public void UpdateListRoom(List<SessionInfo> sessionList)
    {
        foreach (Transform item in ListRoom.transform)
        {
            Destroy(item.gameObject);
        }


        for (int i = 0; i < sessionList.Count; i++)
        {
            UIRoomInfo rominfor = Instantiate(RoomInfoPref, ListRoom.transform);
            rominfor.Init(this, sessionList[i]);
        }
        if (sessionList.Count > 0)
        {
            SetCurrentRoom(sessionList[0]);
        }
    }

    public void SetCurrentRoom(SessionInfo roomInfo)
    {
        CurrentRoom = roomInfo;
        txtName.text = CurrentRoom.Name;
        txtNumber.text = CurrentRoom.PlayerCount.ToString();
    }

    public void CreateGame()
    {
        FusionManager.Instance.HostAGame(LOBBY_NAME, RoomNameInput.text);
    }

    public void JoinGame()
    {
        FusionManager.Instance.JoinAGame(LOBBY_NAME, CurrentRoom.Name);
    }
}

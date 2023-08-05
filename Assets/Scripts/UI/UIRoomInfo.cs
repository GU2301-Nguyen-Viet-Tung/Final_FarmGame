using Fusion;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIRoomInfo : MonoBehaviour
{

    [SerializeField] private Image m_Image;
    [SerializeField] private TextMeshProUGUI m_RoomName;
    [SerializeField] private TextMeshProUGUI m_NumberPlayer;

    private LobbyController LobbyController;
    private SessionInfo SessionInfo;
    public void Init(LobbyController lobbyController, SessionInfo sessionInfo)
    {
        LobbyController = lobbyController;
        SessionInfo = sessionInfo;
        m_RoomName.text = sessionInfo.Name;
        m_NumberPlayer.text = sessionInfo.PlayerCount.ToString();
    }

    public void OnSellect()
    {
        LobbyController.SetCurrentRoom(SessionInfo);
    }
}

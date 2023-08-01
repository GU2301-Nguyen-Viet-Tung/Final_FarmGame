using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITopBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_PlayerName;
    [SerializeField] private TextMeshProUGUI m_Coin;
    // Start is called before the first frame update
    private void Start()
    {
        m_PlayerName.text = PlayerProfile.Instance.GetName();
        m_Coin.text = PlayerProfile.Instance.GetCurrentCoin().ToString();
    }
    private void OnEnable()
    {
        PlayerProfile.ON_COIN_CHANGE += OnCoinChange;
    }
    private void OnDisable()
    {
        PlayerProfile.ON_COIN_CHANGE -= OnCoinChange;
    }
    private void OnCoinChange()
    {
        m_Coin.text = PlayerProfile.Instance.GetCurrentCoin().ToString();
    }
}

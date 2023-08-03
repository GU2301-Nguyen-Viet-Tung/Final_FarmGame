using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    [SerializeField] private Slider BGM_slider;
    [SerializeField] private Slider SFX_slider;
    
    public void Init()
    {
        BGM_slider.value = GameConfig.BGM_VOLUME;
        SFX_slider.value = GameConfig.SFX_VOLUME;
    }
    public void SetBGMVolume()
    {
        GameConfig.BGM_VOLUME = BGM_slider.value;
    }
    public void SetSFXVolume()
    {
        GameConfig.SFX_VOLUME = SFX_slider.value;
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}

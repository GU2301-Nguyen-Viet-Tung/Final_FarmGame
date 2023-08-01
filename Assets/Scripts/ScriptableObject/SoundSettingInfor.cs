using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameBGM
{
    public BackgroundMusic id;
    public AudioClip AudioClip;
}
[Serializable]
public class GameSFX
{
    public SoundEffect id;
    public AudioClip AudioClip;
}

[CreateAssetMenu(fileName = "SoundSettingInfor",
    menuName = "ScriptableObjects/SoundSettingInfor", order = 1)]

public class SoundSettingInfor : ScriptableObject
{
    public List<GameBGM> GameBGM;
    public List<GameSFX> GameSFX;
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BackgroundMusic
{
    NONE,
    BGM_01,
    BGM_02,
    BGM_03
}
public enum SoundEffect
{
    NONE,
    SFX_01,
    SFX_02,
    SFX_03
}
public class SoundManager : ISingletonMonoBehaviour<SoundManager>
{
    [SerializeField] private AudioSource m_BGMSource;
    [SerializeField] private AudioSource m_SFXSource;
    private SoundSettingInfor m_SoundSettingInfor;
    protected override void Awake()
    {
        base.Awake();
        m_SoundSettingInfor = Resources.Load<SoundSettingInfor>("SoundSettingInfor");
        //Debug.Log(m_SoundSettingInfor);
    }
    public void PlayBGM(BackgroundMusic bgm)
    {
        m_BGMSource.clip = m_SoundSettingInfor.GameBGM.Find(x => x.id == bgm).AudioClip;
        m_BGMSource.volume = 0.5f;
        m_BGMSource.loop = true;
        m_BGMSource.Play();
    }
    public void StopBGM()
    {
        m_BGMSource.Stop();
    }
    public bool IsBGM()
    {
        return m_BGMSource.isPlaying;
    }
    public void PlaySFX(SoundEffect sfx)
    {
        m_SFXSource.PlayOneShot(m_SoundSettingInfor.GameSFX.Find(x => x.id == sfx).AudioClip);
    }
    public void StopSFX()
    {
        m_SFXSource.Stop();
    }
    public bool IsSFX()
    {
        return m_SFXSource.isPlaying;
    }
}
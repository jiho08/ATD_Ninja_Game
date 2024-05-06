using System;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    
    [SerializeField] private Slider bgmVolumeSlid;
    [SerializeField] private Slider sfxVolumeSlid;

    private void Start()
    {
        bgmVolumeSlid.value = AudioManager.Instance.BgmVolume;
        sfxVolumeSlid.value = AudioManager.Instance.SfxVolume;
    }

    public void BgmVolumeControl()
    {
         AudioManager.Instance.BgmVolume = bgmVolumeSlid.value;
    }
    
    public void SfxVolumeControl()
    {
        AudioManager.Instance.SfxVolume = sfxVolumeSlid.value;
    }
}

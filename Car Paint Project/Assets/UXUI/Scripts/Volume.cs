using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] AudioMixer myMixer;
    
    public void SetMasterVolume (float f)
    {
        myMixer.SetFloat("MasterVolume", Mathf.Log10(f) * 20);
    }

    public void SetMusicVolume(float f)
    {
        myMixer.SetFloat("MusicVolume", Mathf.Log10(f) * 20);
    }

    public void SetSFXVolume(float f)
    {
        myMixer.SetFloat("SFXVolume", Mathf.Log10(f) * 20);
    }
}

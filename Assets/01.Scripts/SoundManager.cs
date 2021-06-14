using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    //BGM ����
    public enum BGM_TYPE
    {
        BGM_1
    }

    //EFT ����
    public enum EFT_TYPE
    {
        EFT_1,
        EFT_2,
        EFT_3
    }

    //BGM �÷����ϴ� AudioSource
    public AudioSource bgmAudio;

    //EFT �÷����ϴ� AudioSource
    public AudioSource eftAudio;

    //bgm ���� ����
    public AudioClip[] bgms;

    //eft ���� ����
    public AudioClip[] efts;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayBGM(BGM_TYPE type)
    {
        bgmAudio.clip = bgms[(int)type];
        bgmAudio.Play();
    }

    public void PlayEFT(EFT_TYPE type)
    {
        //eftAudio.clip = efts[(int)type];
        //eftAudio.Play();
        eftAudio.PlayOneShot(efts[(int)type]);
    }    
}

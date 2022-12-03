using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game_Assets : MonoBehaviour
{
     
    private static Game_Assets instance;
    public static Game_Assets GetInstance()
    {
        return instance;
    }
    
    private void Awake() 
    {
        instance = this;
    }

    public Transform Ground_Pf;
    // public Transform PipeBody_Pf;
    // public Transform PipeHead_Pf;

    // [SerializeField]
    // public SoundAudioClip[] soundAudioClipArray;

    // [Serializable]
    // public class SoundAudioClip
    // {
    //     public Sound_Manager.Sound sound;
    //     public AudioClip audioClip;

    // }

    // public Transform[] cloudArray;


}

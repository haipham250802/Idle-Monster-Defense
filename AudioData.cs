using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class AudioData : SerializedMonoBehaviour
{
    [SerializeField] AudioClip auClipHome;
    [SerializeField] AudioClip auClipIngame;
    [SerializeField] Dictionary<TypeAudioClip, AudioClip> dictionaryAuClip = new();
    
    public AudioClip GetAuClipOfType(TypeAudioClip type)
    {
        return dictionaryAuClip[type];
    }
    public AudioClip GetAuClipLobby()
    {
        return auClipHome;
    }
    public AudioClip GamePlay()
    {
        return auClipIngame;
    }
}


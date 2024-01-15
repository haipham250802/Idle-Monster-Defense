using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource aus;
    [SerializeField] AudioSource ausPlayClip;
    [SerializeField] AudioData auData;

    private void Start()
    {
        PlayMusicInGame(TypeScenes.LOBBY);
    }
    public void PlayMusicInGame(TypeScenes type)
    {
        switch (type)
        {
            case TypeScenes.NONE:
                break;
            case TypeScenes.LOBBY:
                aus.clip = auData.GetAuClipLobby();
                break;
            case TypeScenes.GAMEPLAY:
                aus.clip = auData.GamePlay();
                break;
            default:
                break;
        }
        aus.Play();
    }    
    public void PlaySound(TypeAudioClip type)
    {
        GameObject ausClone = SimplePool.Spawn(ausPlayClip.gameObject, Vector3.zero, Quaternion.identity);
        AudioSource ausCache = ausClone.GetComponent<AudioSource>();
        AudioClip auClip = auData.GetAuClipOfType(type);
        ausCache.PlayOneShot(auClip);
    }
}

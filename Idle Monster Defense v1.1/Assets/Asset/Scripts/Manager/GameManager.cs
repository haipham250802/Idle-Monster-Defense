using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Ins;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AnimCoinController animCoinController;

    public AnimCoinController AnimCoinController => animCoinController;
    public AudioManager AudioManager => audioManager;
    private void Awake()
    {
        if (Ins == null)
            Ins = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}

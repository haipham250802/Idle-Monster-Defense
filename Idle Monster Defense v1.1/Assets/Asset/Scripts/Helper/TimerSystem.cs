using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(IE_InitScenes());
    }
    private IEnumerator IE_InitScenes()
    {
        yield return null;
        Turrent.Ins.OnStart();
        yield return new WaitForSeconds(0.3f);
        UIGamePlay.Ins.OnStart();
    }
}

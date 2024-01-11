using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObject : MonoBehaviour
{
    [SerializeField] private float timeLive;
    private float timeCoolDown;
    private void Start()
    {
        timeCoolDown = timeLive;
    }
    private void Update()
    {
        if (timeCoolDown > 0)
        {
            timeCoolDown -= Time.deltaTime;
        }
        else
        {
            timeCoolDown = timeLive;
            SimplePool.Despawn(gameObject);
        }
    }
}

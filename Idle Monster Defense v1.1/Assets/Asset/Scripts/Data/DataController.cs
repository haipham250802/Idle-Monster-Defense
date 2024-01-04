using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    [SerializeField] DataCurrentcy dataCurrentcy;
    public DataCurrentcy DataCurrentcy => dataCurrentcy;
    public static DataController Ins;
    private void Awake()
    {
        if (Ins == null)
            Ins = this;
        else
            Destroy(gameObject);
    }
}

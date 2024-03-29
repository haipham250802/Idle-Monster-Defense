using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    [SerializeField] DataCurrentcy dataCurrentcy;
    [SerializeField] DataPlayer dataPlayer;
    [SerializeField] DataInGame dataIngame;
    [SerializeField] DataSOController dataSOController;
    public DataPlayer DataPlayer => dataPlayer;
    public DataInGame DataInGame => dataIngame;
    public DataCurrentcy DataCurrentcy => dataCurrentcy;
    public DataSOController DataSOController => dataSOController;
    public static DataController Ins;
    private void Awake()
    {
        if (Ins == null)
            Ins = this;
        else
            Destroy(gameObject);
    }
}

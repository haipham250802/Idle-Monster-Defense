using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/DataZone",fileName = "DataZone")]
public class DataZone : ScriptableObject
{
    [SerializeField] private List<ZoneInfo> listZone = new();
    public ZoneInfo GetZoneInfoOfIndex(int index)
    {
        foreach (ZoneInfo item in listZone)
        {
            if (item.IndexZone == index)
                return item;
        }
        return null;
    }
}
[System.Serializable]
public class ZoneInfo
{
    public int IndexZone;
    public string nameZone;
    public Sprite IconZone;
}

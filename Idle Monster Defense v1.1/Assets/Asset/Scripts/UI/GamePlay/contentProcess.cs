using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class contentProcess : MonoBehaviour
{
    [SerializeField] Image fill;
    [SerializeField] Text txt;
    public void UpdateProgess(float current, float max)
    {
        float result = current / max;
        fill.fillAmount = result;
    }
    public void UpdateTextNextTurn(int value)
    {
        txt.text = "Lượt  " + value.ToString();
    }
}

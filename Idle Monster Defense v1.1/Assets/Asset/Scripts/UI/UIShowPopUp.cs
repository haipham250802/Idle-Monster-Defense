using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShowPopUp : MonoBehaviour
{
    public static UIShowPopUp Ins;
    private void Awake()
    {
        if (Ins == null)
            Ins = this;
        else
            Destroy(gameObject);
    }
    public void ShowPopUpWin()
    {
        PopUpWin popup = Instantiate(Resources.Load<PopUpWin>("PopUp/PopUpWin"));
        popup.transform.SetParent(transform);
        popup.transform.localScale = Vector3.one;
        popup.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        popup.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        popup.transform.SetAsLastSibling();
    }
    public void ShowPopUpLose()
    {
        PopUpLose popup = Instantiate(Resources.Load<PopUpLose>("PopUp/PopUpLose"));
        popup.transform.SetParent(transform);
        popup.transform.localScale = Vector3.one;
        popup.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        popup.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        popup.transform.SetAsLastSibling();
    }
}

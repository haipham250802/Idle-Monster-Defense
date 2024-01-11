using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class PopUpBase : MonoBehaviour
{
    [FoldoutGroup("Anim PopUp")]
    [SerializeField] Transform content;
    [FoldoutGroup("Anim PopUp")]
    [SerializeField] AnimationCurve animationCurve;
    [FoldoutGroup("Anim PopUp")]
    [SerializeField] float timeOpen;
    [FoldoutGroup("Anim PopUp")]
    [SerializeField] float timeClose;

    protected virtual void OnEnable()
    {
        Show();
    }
    protected virtual void Hide()
    {
        content.DOScale(Vector3.one * 0.3f, timeClose)
            .SetEase(animationCurve);
    }
    protected virtual void Show()
    {
        content.localScale = Vector3.one * 0.3f;
        content.DOScale(Vector3.one, timeOpen)
            .SetEase(animationCurve);
    }
}

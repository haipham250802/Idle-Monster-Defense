using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class HeatlhBar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer fill;
    [SerializeField] private Color colorMin;
    [SerializeField] private Color colorMax;

    [SerializeField] bool isTurrent;

    float timeCoolDown = 0;
    private void Update()
    {
        if (isTurrent)
            return;
        timeCoolDown += Time.deltaTime;
        if (timeCoolDown > 2)
        {
            gameObject.SetActive(false);
        }
    }
    public void ResetFill()
    {
        Debug.Log("rs");
        UpdateFillBar(1, 1);
    }
    public void UpdateFillBar(float currentHp, float maxHp)
    {
        gameObject.SetActive(true);
        timeCoolDown = 0;
        float healthPercentage = (currentHp / maxHp);
        healthPercentage = Mathf.Clamp01(healthPercentage);
        Vector3 theScale = fill.transform.localScale;
        theScale.x = healthPercentage;
        fill.transform.localScale = theScale;
        Color lerpedColor = Color.Lerp(colorMin, colorMax, healthPercentage);
        fill.color = lerpedColor;
    }
    public void InitPos(Transform parent)
    {
        transform.parent = parent;
        Vector3 theScale = transform.localScale;
        if (theScale.x > 0)
            transform.localPosition = new Vector3(-0.18f, 0.3f, 0);
        else
            transform.localPosition = new Vector3(0.18f, 0.3f, 0);
    }
}

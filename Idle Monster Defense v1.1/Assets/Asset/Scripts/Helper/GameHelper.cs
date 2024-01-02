using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameHelper
{
    public static Vector3 NewPosition(Transform origin)
    {
        float screenSize = Camera.main.orthographicSize / Camera.main.aspect;
        Vector2 randomOffset = Random.insideUnitCircle.normalized * (screenSize / 3.5f + 0.5f);
        Vector3 randomPosition = origin.transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);
        return randomPosition;
    }
    public static void SetRotation(Transform obj,Vector3 target)
    {
        var position = obj.position;
        var a = Mathf.Abs(target.x - position.x);
        var b = Mathf.Abs(target.y - position.y);
        var angle = Mathf.Atan(a / b) * Mathf.Rad2Deg;
        if (target.x < 0)
        {
            if (target.y < position.y)
            {
                obj.rotation = Quaternion.Euler(new Vector3(0f, 0f, -angle));
            }
            else
            {
                obj.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180));
            }
        }
        else
        {
            if (target.y < position.y)
            {
                obj.rotation = Quaternion.Euler(new Vector3(0f, 180f, -angle));
            }
            else
            {
                obj.rotation = Quaternion.Euler(new Vector3(180f, 0f, angle));
            }
        }
    }
}

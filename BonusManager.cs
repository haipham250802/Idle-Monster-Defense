using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusGameManager : MonoBehaviour
{
    public int bonusGameScoreThreshold;
    public GameObject bonusGamePrefab;

    private void Start()
    {
        StartCoroutine(SpawnBonusGame());
    }

    IEnumerator SpawnBonusGame()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            if (ScoreManager.score >= bonusGameScoreThreshold)
            {
                UIManager.instance.ShowBonusGamePopup();
                break;
            }
        }
    }

    public void PlayBonusGame()
    {
        GameObject bonusGameInstance = Instantiate(bonusGamePrefab);
        UIManager.instance.HideAllPopups();
    }
}
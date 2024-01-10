using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public string nextLevel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
        LoadNextLevel();
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene("GameOver");
    }
}

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Text scoreText;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncreaseScore(int increase)
    {
        score += increase;
        UpdateScoreText();
    }
}

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

public class UIManager : MonoBehaviour
{
    public GameObject losePopup;
    public GameObject winPopup;
    public GameObject bonusGamePopup;

    private void Start()
    {
        losePopup.SetActive(false);
        winPopup.SetActive(false);
        bonusGamePopup.SetActive(false);
    }

    public void ShowLosePopup()
    {
        losePopup.SetActive(true);
    }

    public void ShowWinPopup()
    {
        winPopup.SetActive(true);
    }

    public void ShowBonusGamePopup()
    {
        bonusGamePopup.SetActive(true);
    }

    public void HideAllPopups()
    {
        losePopup.SetActive(false);
        winPopup.SetActive(false);
        bonusGamePopup.SetActive(false);
    }
}


public class UpgradeManager : MonoBehaviour
{
    public GameObject upgradePopup;
    public Button upgradeButton;
    public int upgradeCost;

    private void Start()
    {
        upgradePopup.SetActive(false);
        upgradeButton.onClick.AddListener(Upgrade);
    }

    public void ShowUpgradePopup()
    {
        upgradePopup.SetActive(true);
    }

    public void HideUpgradePopup()
    {
        upgradePopup.SetActive(false);
    }

    public void Upgrade()
    {
        if (ScoreManager.score >= upgradeCost)
        {
            ScoreManager.score -= upgradeCost;
            ScoreManager.instance.UpdateScoreText();
            HideUpgradePopup();
            // Apply upgrade effect here
        }
    }
}
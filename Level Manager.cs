using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] int levelMenuScoreThreshold = 100; // Level menüsüne atama eþiði *********

    bool levelMenuTriggered = false; // Level menüsüne atamanýn yapýldýðýný takip etmek için bir bayrak *************

    int score;

    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);

        if (!levelMenuTriggered && score >= levelMenuScoreThreshold)  // ****************
        {
            levelMenuTriggered = true;
            levelManager.LevelMenu();
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}

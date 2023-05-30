using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float sceneLoadDelay = 2f;     //sahneleri birbirlerine baðladýk
    ScoreKeeper scoreKeeper;      // burada bunu kullanmamýzýn sebebý oldukten sonra kazandýgýmýz puan tekrar oyuna basladýgýmýzda gelýyor biz bunu sýfýrlamak istiyoruz.
    public static bool game1, game2, game3;     //*************
    public Button game1_button, game2_button, game3_button;     //*****

   
    

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
       // SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()   // burda çalýþýr ama baþka uygulamalar için ek yapmak gerekli
    {
        Application.Quit();
        Debug.Log("Qutting Game...");
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

   public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene("Game 2");
    }

    public void PlayGame3()
    {
        SceneManager.LoadScene("Game 3");
    }

    public void LevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }




}

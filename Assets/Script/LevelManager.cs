using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ItemCollector playerCoin;
    PointKeeper pointKeeper;
    int health = 10;

    void Awake()
    {
        playerCoin = FindObjectOfType<ItemCollector>();
        pointKeeper = FindObjectOfType<PointKeeper>();
    }
    
    public void LoadGame()
    {
        pointKeeper.ResetHealth();
        pointKeeper.ResetCoin();
        SceneManager.LoadScene("Level 1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadBackroom()
    {
        SceneManager.LoadScene("Backroom");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void LoadSurvived()
    {
        SceneManager.LoadScene("Survived");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

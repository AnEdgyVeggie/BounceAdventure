using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Player _player;


    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (_player.GetGameOver()) { GameOver(); }

        if (Input.GetKeyDown(KeyCode.Escape)) { ExitGame(); }
    }

    void GameOver()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

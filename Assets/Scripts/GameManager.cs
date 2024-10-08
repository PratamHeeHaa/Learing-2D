using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGamePaused;

    //[SerializeField] GameObject pauseSceen;
    [SerializeField] GameObject endGameScreen;
    [SerializeField] TextMeshProUGUI livesTest;

    private PlayerMovement player;

    private bool isDead;
    // Update is called once per frame
    void Update()
    {
        if (isGamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        isDead = player.playerHealth <= 0;

        livesTest.text = "Lives : " + player.playerHealth;

        EndGame();

    }
    private void Start()
    {
        isGamePaused = false;
        Time.timeScale = 1;
    }

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void EndGame()
    {
        if (isDead)
        {
            Time.timeScale = 0;
        }
        HighscoreTable.AddHighscoreEntry(score: KillToScore.score, name: PlayerName.playerName ?? "Player");
        endGameScreen.SetActive(isDead);
    }

    void PauseGame()
    {

        //pauseSceen.SetActive(isGamePaused);

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreGameOverText;
    [SerializeField] GameObject restartButton;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip gameOverAudioClip;
    public bool isGameOver;
    public bool isGamePause;
    public int score = 0;
    
    private void Awake() 
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    private void Start() 
    {
        isGameOver = false;
        SpawnManager.Instance.SpawnApple();
    }
    public void GameOver()
    {
        isGameOver = true;
        audioSource.PlayOneShot(gameOverAudioClip);
        CameraShake.Instance.ShakeCamera(10, 1f);
        restartButton.SetActive(true);
        scoreGameOverText.text = Convert.ToString(score);
    }

    public void ResetUIScore()
    {
        scoreText.text = Convert.ToString(score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    
}

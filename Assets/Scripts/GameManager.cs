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
    private CameraColor cameraColor;
    [SerializeField] TextMeshProUGUI scoreText; //score on the screen
    [SerializeField] TextMeshProUGUI scoreGameOverText;
    [SerializeField] GameObject restartButton;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip gameOverAudioClip;
    public bool isGameOver;
    public int score = 0;
    
    private void Awake() 
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        cameraColor = Camera.main.GetComponent<CameraColor>();
    }
    private void Start() 
    {
        isGameOver = false;
        SpawnManager.Instance.SpawnApple(); //spawn(Pooling) first apple in the first frame
    }
    public void GameOver()
    {
        isGameOver = true;
        audioSource.PlayOneShot(gameOverAudioClip);
        CameraShake.Instance.ShakeCamera(10, 1f);
        cameraColor.ChangeBackCamColor(0.4f, new Color32(255, 255, 255, 0));
        restartButton.SetActive(true);
        scoreGameOverText.text = Convert.ToString(score); //show score on gameover screen
    }

    public void ResetUIScore() //To update score value on UI when snake eat an apple
    {
        scoreText.text = Convert.ToString(score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    
}

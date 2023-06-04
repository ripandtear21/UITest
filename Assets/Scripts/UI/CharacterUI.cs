using System;
using System.Collections;
using System.Collections.Generic;
using Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private int score = 0;
    [SerializeField] private GameObject deathScreen;

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        EventSystem.OnPlayerDeath += ShowDeathScreen;
        EventSystem.OnKill += AddScore;
        EventSystem.OnHealthChanged += UpdateHealthUI;
    }

    private void OnDisable()
    {
        EventSystem.OnPlayerDeath -= ShowDeathScreen;
        EventSystem.OnKill -= AddScore;
        EventSystem.OnHealthChanged -= UpdateHealthUI;
    }

    private void UpdateHealthUI(float currentHealth, float maxHealth)
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }
    private void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    

    private void ShowDeathScreen()
    {
        finalScoreText.text = "Score: " + score.ToString();
        deathScreen.SetActive(true);
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    
}

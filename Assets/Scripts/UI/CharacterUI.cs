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
    [SerializeField] private int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        EventSystem.OnKill += AddScore;
        EventSystem.OnHealthChanged += UpdateHealthUI;
    }

    private void OnDisable()
    {
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
}

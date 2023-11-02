using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthValueDisplay : MonoBehaviour
{
    public enum whoseHealth
    {
        Player,
        Opponent
    }
    public whoseHealth whoseHP;
    public TextMeshProUGUI totalHealthText;
    public TextMeshProUGUI currentHealthText;
    public int capturedMaxHealth;
    public bool updateMaxHPInRealtime; // primarily for the debug stat input scene
    // Start is called before the first frame update
    void Awake()
    {
        UpdateMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        switch (whoseHP)
        {
            case whoseHealth.Player:
                if (currentHealthText != null)
                {
                    currentHealthText.text = StatManager.Instance.playerHP.ToString();
                }
                if (updateMaxHPInRealtime) UpdateMaxHealth();

                break;
            case whoseHealth.Opponent:
                if (currentHealthText != null)
                {
                    currentHealthText.text = StatManager.Instance.enemyHP.ToString();
                }
                if (updateMaxHPInRealtime) UpdateMaxHealth();
                break;
        }
    }

    void UpdateMaxHealth()
    {
        switch (whoseHP)
        {
            case whoseHealth.Player:
                if (totalHealthText != null)
                {
                    capturedMaxHealth = Mathf.CeilToInt(StatManager.Instance.playerHP);
                    totalHealthText.text = capturedMaxHealth.ToString();
                    Debug.Log(StatManager.Instance.playerHP + " player HP float converted to int as " + capturedMaxHealth + " max HP.");
                }
                break;
            case whoseHealth.Opponent:
                if (totalHealthText != null)
                {
                    capturedMaxHealth = Mathf.CeilToInt(StatManager.Instance.enemyHP);
                    totalHealthText.text = capturedMaxHealth.ToString();
                    Debug.Log(StatManager.Instance.playerHP + " enemy HP float converted to int as " + capturedMaxHealth + " max HP.");
                }
                break;
        }
    }
}
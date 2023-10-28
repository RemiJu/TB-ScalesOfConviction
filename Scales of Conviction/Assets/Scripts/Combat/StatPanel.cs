using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatPanel : MonoBehaviour
{
    public TextMeshProUGUI Str;
    public TextMeshProUGUI Dex;
    public TextMeshProUGUI Vit;
    public TextMeshProUGUI Mnd;
    public TextMeshProUGUI Spd;

    public TextMeshProUGUI charHP;
    public TextMeshProUGUI charTotalHP;
    public TextMeshProUGUI charAP;
    public TextMeshProUGUI charTotalAP;

    public enum whoseStats
    {
        Player,
        Opponent
    }

    public whoseStats stats;

    void Awake()
    {
        // puts applicable stats on the combat UI
        switch (stats)
        {
            case whoseStats.Player:
                Str.text = StatManager.Instance.playerStr.ToString();
                Dex.text = StatManager.Instance.playerDex.ToString();
                Vit.text = StatManager.Instance.playerVit.ToString();
                Mnd.text = StatManager.Instance.playerMnd.ToString();
                Spd.text = StatManager.Instance.playerSpd.ToString();
                charHP.text = StatManager.Instance.playerHP.ToString();
                charAP.text = StatManager.Instance.playerAP.ToString();
                charTotalHP.text = StatManager.Instance.playerHP.ToString();
                charTotalAP.text = StatManager.Instance.playerAP.ToString();

                Debug.Log("PlayerStats loaded");
                break;
            case whoseStats.Opponent:
                Str.text = StatManager.Instance.enemyStr.ToString();
                Dex.text = StatManager.Instance.enemyDex.ToString();
                Vit.text = StatManager.Instance.enemyVit.ToString();
                Mnd.text = StatManager.Instance.enemyMnd.ToString();
                Spd.text = StatManager.Instance.enemySpd.ToString();
                charHP.text = StatManager.Instance.enemyHP.ToString();
                charAP.text = StatManager.Instance.enemyAP.ToString();
                charTotalHP.text = StatManager.Instance.enemyHP.ToString();
                charTotalAP.text = StatManager.Instance.enemyAP.ToString();

                Debug.Log("EnemyStats loaded");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccValueDisplay : MonoBehaviour
{
    public enum whoseAcc
    {
        Player,
        Opponent
    }

    public whoseAcc accuracyPercentage;
    public TextMeshProUGUI displayValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (accuracyPercentage)
        {
            case whoseAcc.Player:
                displayValue.text = StatManager.Instance.playerAcc.ToString();
                break;
            case whoseAcc.Opponent:
                displayValue.text = StatManager.Instance.enemyAcc.ToString();
                break;
        }
    }
}

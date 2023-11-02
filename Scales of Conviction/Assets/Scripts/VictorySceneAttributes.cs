using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictorySceneAttributes : MonoBehaviour
{
    public enum WhichAttribute
    {
        turnTotal,
        totalDamageDealt,
        totalDamageReceived,
        totalPoints,
        totalEnemyPoints
    }
    private TextMeshProUGUI targetText;
    public WhichAttribute whichAttribute;

    // Start is called before the first frame update
    void Start()
    {
        targetText = GetComponent<TextMeshProUGUI>();
        switch(whichAttribute)
        {
            case WhichAttribute.turnTotal:
                targetText.text = StatManager.Instance.totalTurns.ToString();
                break;
            case WhichAttribute.totalDamageDealt:
                targetText.text = StatManager.Instance.playerDmgDealtTotal.ToString();
                break;
            case WhichAttribute.totalDamageReceived:
                targetText.text = StatManager.Instance.playerDmgRecdTotal.ToString();
                break;
            case WhichAttribute.totalPoints:
                targetText.text = StatManager.Instance.playerPoints.ToString();
                break;
            case WhichAttribute.totalEnemyPoints:
                targetText.text = StatManager.Instance.enemyPoints.ToString();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public BattleTimer playerBattleTimer;
    public BattleTimer enemyBattleTimer;

    public bool playersTurn;
    public bool enemysTurn;
    //UI:
    public GameObject playerPanel;
    public GameObject enemyPanel;
    public GameObject canvasRoot; // main canvas Object

    public int playerTurnCount;
    public int enemyTurnCount;

    // Start is called before the first frame update
    void Awake()
    {
        playerBattleTimer = GameObject.Find("PlayerBattleTimer").GetComponent<BattleTimer>();
        enemyBattleTimer = GameObject.Find("EnemyBattleTimer").GetComponent<BattleTimer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTimerFull()
    {
        if (!enemysTurn)
        {
            playersTurn = true;
            Debug.Log("Player's Turn");
            GameObject playerPanelInstance = Instantiate(playerPanel, Vector3.zero, Quaternion.Euler(0, 0, 0));
            playerPanelInstance.transform.SetParent(canvasRoot.transform, false);
            BothTimersPause();
        }
        // etc.
    }

    public void EnemyTimerFull()
    {
        if(!playersTurn)
        {
            Debug.Log("Enemy's Turn");
            GameObject enemyPanelInstance = Instantiate(enemyPanel, Vector3.zero, Quaternion.Euler(0, 0, 0));
            enemyPanelInstance.transform.SetParent(canvasRoot.transform, false);
            enemysTurn = true;
            BothTimersPause();
        }
        // etc.
    }
    public void BothTimersPause()
    {
        enemyBattleTimer.StopTimer();
        playerBattleTimer.StopTimer();
    }

}

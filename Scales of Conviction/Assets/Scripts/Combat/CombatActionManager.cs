using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActionManager : MonoBehaviour
{
    public int specifiedTime; // timer pause to allow turn to play out (for animation)
    public TurnManager turnManager;
    public BattleTimer playerBattleTimer;
    public BattleTimer enemyBattleTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CommandAttack()
    {
        // Insert actual attack stuff

        Debug.Log("Player attacks!");
        StartCoroutine(ActionWindow());
    }

    public void EnemyAttack()
    {
        // Insert actual attack stuff

        Debug.Log("Enemy attacks!");
        StartCoroutine(ActionWindow());
    }

    void CleanseCanvasRoot()
    {
        Transform canvasRoot = GameObject.Find("CanvasRoot").transform;
        foreach (Transform child in canvasRoot)
        {
            Destroy(child.gameObject);
        }
        Debug.Log("Cleansed windows on CanvasRoot.");
    }

    private IEnumerator ActionWindow()
    {
        Debug.Log("ActionWindow coroutine initiated.");
        CleanseCanvasRoot();
        yield return new WaitForSeconds(specifiedTime);
        if(turnManager.playersTurn) // Resets the timer at the end of the action.
        {
            turnManager.playerTurnCount += 1;
            playerBattleTimer.ResetTimer();
            turnManager.playersTurn = false;
            playerBattleTimer.StartTimer();
            enemyBattleTimer.StartTimer();
            Debug.Log("Resetting Player ATB gauge.");
            Debug.Log("playersTurn is false");
        }
        if(turnManager.enemysTurn) 
        {
            turnManager.enemyTurnCount += 1;
            enemyBattleTimer.ResetTimer();
            enemyBattleTimer.StartTimer();
            playerBattleTimer.StartTimer();
            Debug.Log("Resetting Enemy ATB gauge.");
            turnManager.enemysTurn = false;
            Debug.Log("enemysTurn is false");
            CleanseCanvasRoot();
        }
    }
}

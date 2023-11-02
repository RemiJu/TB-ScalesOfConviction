using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatActionManager : MonoBehaviour
{
    public int specifiedTime; // timer pause to allow turn to play out (for animation)
    public TurnManager turnManager;
    public BattleTimer playerBattleTimer;
    public BattleTimer enemyBattleTimer;
    public TextMeshProUGUI playerDmgRecd;
    public TextMeshProUGUI enemyDmgRecd;
    public int damageOutput;
    public bool isAttacking;
    public bool isResting;
    public bool isDefending;

    // Start is called before the first frame update
    void Start()
    {
        playerDmgRecd.gameObject.SetActive(false);
        enemyDmgRecd.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CommandAttack()
    {
        // Insert actual attack stuff

        Debug.Log("Player attacks!");
        isAttacking = true;
        PlayerDmgCalc(); //directs action to Player Command List function to determine what to do
        StartCoroutine(ActionWindow());
    }

    public void CommandDefend()
    {
        Debug.Log("Player defends!");
        isDefending = true;
        PlayerCommandList();
    }
    
    public void CommandRest()
    {
        Debug.Log("Player rests!");
        isResting = true;
        PlayerCommandList();
    }

    public void EnemyAttack()
    {
        // Insert actual attack stuff

        Debug.Log("Enemy attacks!");
        EnemyDmgCalc();
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
    public void PlayerDmgCalc()
    {
        damageOutput = 0; //reset to 0 before recalculating
        damageOutput = StatManager.Instance.playerStr * 10;
        Debug.Log("Player damage output is set to " + damageOutput);
        enemyDmgRecd.gameObject.SetActive(true);
        enemyDmgRecd.text = (damageOutput.ToString());
        PlayerCommandList();
        StartCoroutine(DamageDisplay());
    }

    public void EnemyDmgCalc()
    {
        damageOutput = 0; //reset to 0 before recalculating
        damageOutput = StatManager.Instance.enemyStr * 10;
        Debug.Log("Enemy damage output is set to " + damageOutput);
        playerDmgRecd.gameObject.SetActive(true);
        playerDmgRecd.text = (damageOutput.ToString());
        EnemyCommandList();
        StartCoroutine(DamageDisplay());
    }

    public void PlayerRestCalc()
    {
        damageOutput = 0;
        StatManager.Instance.MndHPCalculator();
        damageOutput = Mathf.CeilToInt(StatManager.Instance.playerRestHP);
        Debug.Log("Player rest amount is calculated to be " + damageOutput);
        playerDmgRecd.gameObject.SetActive(true);
        playerDmgRecd.color = new Color(0.2f, 0.88f, 0.22f, 1);
        playerDmgRecd.text = (damageOutput.ToString());
        StatManager.Instance.playerHP += damageOutput;
        isResting = false;
        StartCoroutine(DamageDisplay());
    }

    public void PlayerCommandList()
    {
        if(isAttacking)
        {
            StatManager.Instance.enemyHP -= damageOutput;
            Debug.Log("removing " + damageOutput + " from enemy");
            StatManager.Instance.playerDmgDealtTotal = StatManager.Instance.playerDmgDealtTotal + damageOutput;
            isAttacking = false;
        }
        if(isDefending)
        {
            Debug.Log("not implemented");
            StartCoroutine(ActionWindow());
        }
        if (isResting)
        {
            PlayerRestCalc();
            StartCoroutine(ActionWindow());
        }
    }

    public void EnemyCommandList()
    {
        if(isDefending)
        {
            damageOutput = 1;
            playerDmgRecd.text = (damageOutput.ToString());
            isDefending = false;
        }
        StatManager.Instance.playerHP -= damageOutput;
        StatManager.Instance.playerDmgRecdTotal = StatManager.Instance.playerDmgRecdTotal + damageOutput;
        Debug.Log("removing " + damageOutput + " from player");
    }

    private IEnumerator ActionWindow()
    {
        Debug.Log("ActionWindow coroutine initiated.");
        CleanseCanvasRoot();
        yield return new WaitForSeconds(specifiedTime);
        if(turnManager.playersTurn) // Resets the timer at the end of the action.
        {
            turnManager.playerTurnCount += 1;
            StatManager.Instance.totalTurns += 1;
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

    private IEnumerator DamageDisplay()
    {
        yield return new WaitForSeconds(1);
        playerDmgRecd.text = ("");
        playerDmgRecd.color = new Color(1, 1, 1, 1);
        enemyDmgRecd.text = ("");
        enemyDmgRecd.color = new Color(1, 1, 1, 1);
        playerDmgRecd.gameObject.SetActive(false);
        enemyDmgRecd.gameObject.SetActive(false);

    }
}

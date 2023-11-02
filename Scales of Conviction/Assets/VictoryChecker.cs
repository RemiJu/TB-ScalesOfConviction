using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryChecker : MonoBehaviour
{
    private TurnManager turnManager;
    public string gameOverScene;
    public string victoryScene;
    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(StatManager.Instance.playerHP <= 0 && turnManager.enemyTurnCount >= 1)
        {
            SceneManager.LoadScene(gameOverScene);
        }
        if (StatManager.Instance.enemyHP <= 0 && turnManager.playerTurnCount >= 1)
        {
            SceneManager.LoadScene(victoryScene);
        }
    }
}

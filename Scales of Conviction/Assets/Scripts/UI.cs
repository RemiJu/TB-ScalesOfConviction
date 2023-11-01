using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject playerTurn;
    public GameObject enemyTurn;

    void Update()
    {
        if (StatManager.Instance.playerTurn == true)
        {
            playerTurn.SetActive(true);
            enemyTurn.SetActive(false);

        }
        if (StatManager.Instance.enemyTurn == true)
        {
            playerTurn.SetActive(false);
            enemyTurn.SetActive(true);
        }
    }
}

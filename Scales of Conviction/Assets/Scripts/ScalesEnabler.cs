using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalesEnabler : MonoBehaviour
{
    public Animator p_Animator;
    public Animator e_Animator;
    public Animator s_Animator;

    // Update is called once per frame
    void Update()
    {
        if(StatManager.Instance.playerPoints > StatManager.Instance.enemyPoints)
        {
            PlayerAdvantage();
        }
        else if(StatManager.Instance.playerPoints < StatManager.Instance.enemyPoints)
        {
            EnemyAdvantage();
        }
        else
        {
            NoAdvantage();
        }
    }

    void PlayerAdvantage()
    {

    }

    void EnemyAdvantage()
    {

    }

    void NoAdvantage()
    {

    }
}

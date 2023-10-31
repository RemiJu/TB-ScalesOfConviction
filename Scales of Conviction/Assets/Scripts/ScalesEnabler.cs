using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalesEnabler : MonoBehaviour
{
    public Animator p_Animator;
    public Animator e_Animator;
    public Animator s_Animator;

    //public GameObject eFlame;
    //public GameObject pFlame;
    //Vector3 scaleChange = new Vector3(2, 2, 2);

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
        p_Animator.SetTrigger("Player Adv");
        s_Animator.SetTrigger("to Player");
        e_Animator.SetTrigger("Enemy Disadv");
        //eFlame.transform.localScale -= scaleChange;
        //pFlame.transform.localScale += scaleChange;
    }

    void EnemyAdvantage()
    {
        p_Animator.SetTrigger("Player Disadv");
        s_Animator.SetTrigger("to Enemy");
        e_Animator.SetTrigger("Enemy Adv");
    }

    void NoAdvantage()
    {
        p_Animator.SetTrigger("Player Neutral");
        s_Animator.SetTrigger("to Neutral");
        e_Animator.SetTrigger("Enemy Neutral");
    }
}

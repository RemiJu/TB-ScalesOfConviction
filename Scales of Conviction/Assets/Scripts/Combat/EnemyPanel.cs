using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPanel : MonoBehaviour
{
    public CombatActionManager actionManager;
    // Start is called before the first frame update
    void Awake()
    {
        actionManager = GameObject.Find("CombatActionManager").GetComponent<CombatActionManager>();
        Debug.Log("Enemy does a lil dance");
        actionManager.EnemyAttack();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

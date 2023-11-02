using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommenceBattle : MonoBehaviour
{
    public string battleScene;

    [Header("StatSetup Player")]
    public int playerStr;
    public int playerDex;
    public int playerVit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CommenceBattleScene()
    {
        SceneManager.LoadScene(battleScene);
    }
}

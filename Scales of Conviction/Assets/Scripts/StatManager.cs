using UnityEngine;

public class StatManager : MonoBehaviour
{
    // Point system
    public float playerPoints;
    public float enemyPoints;
    public float pointsToAdd;
    public float pointsToRemove;

    // Timer
    public bool playerTurn = true;  //SET TO TRUE FOR PLAYTESTING, DONT FORGET TO SET IT TO FALSE TO START NORMALLY !!!!
    public float turnDuration = 30f;
    float timeLeft;

    // References
    public GameObject player;
    public Transform playerPosition;

    // PLAYER COMBAT ATTRIBUTES
    public int playerStr;
    public int playerDex;
    public int playerVit;
    public int playerMnd;
    public int playerSpd;

    public float playerBaseHP;
    public float playerHP;
    public float playerAP;

    // ENEMY COMBAT ATTRIBUTES
    public int enemyStr;
    public int enemyDex;
    public int enemyVit;
    public int enemyMnd;
    public int enemySpd;

    public float enemyBaseHP;
    public float enemyHP;
    public float enemyAP;

    private static StatManager instance;
    public static StatManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("StatManager").AddComponent<StatManager>();
            }
            return instance;
        }
    }


    void Start()
    {
        DontDestroyOnLoad(this);
        GameObject player = GameObject.Find("Player");
    }

    void Update()
    {
        //playerPosition = player.transform;
       // Debug.Log(playerPosition);
    }

    public void AddPlayerPoints()
    {
        playerPoints += pointsToAdd;
    }

    public void RemovePlayerPoints()
    {
        playerPoints -= pointsToRemove;
    }

    public void AddEnemyPoints()
    {
        enemyPoints += pointsToAdd;
    }

    public void RemoveEnemyPoints()
    {
        enemyPoints -= pointsToRemove;
    }

    public void StartTime()
    {
        playerTurn = true;
        timeLeft = turnDuration;
        timeLeft -= Time.deltaTime;

        if (timeLeft == 0)
        {
            StopTime();
        }
    }

    public void StopTime()
    {
        playerTurn = false;
    }


    public void StatCalculation()
    {
        playerHP = (playerVit * playerBaseHP) / 2;
        Debug.Log(playerVit + " player Vitality x " + playerBaseHP + " + player Base HP = " + playerHP);
        enemyHP = (enemyVit * enemyBaseHP) / 2;
        Debug.Log(enemyVit + " enemy Vitality x " + enemyBaseHP + " + enemy Base HP = " + enemyHP);
    }
}

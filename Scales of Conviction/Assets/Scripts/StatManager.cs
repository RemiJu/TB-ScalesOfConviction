using UnityEngine;

public class StatManager : MonoBehaviour
{
    // Point system
    public float playerPoints;
    public float enemyPoints;
    public float pointsToAdd;
    public float pointsToRemove;

    // Timer
    public bool playerTurn = true;
    public bool enemyTurn = false;
    public float turnDuration = 8f;
    public float timeLeft;

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

    // hidden attributes
    public float playerAcc; // Hit accuracy based on Dex
    public float playerRestHP; // Amount of HP healed on 'Rest' based on Mind
    public float playerSpdMult; // Speed multiplier on turn speed based on Spd


    // ENEMY COMBAT ATTRIBUTES
    public int enemyStr;
    public int enemyDex;
    public int enemyVit;
    public int enemyMnd;
    public int enemySpd;
    public float enemyBaseHP;
    public float enemyHP;
    public float enemyAP;

    // hidden attributes
    public float enemyAcc;
    public float enemyRestHP;
    public float enemySpdMult;



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

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        GameObject player = GameObject.Find("Player");
        StartPlayerTurn();
    }

    void Update()
    {
        if (playerTurn == true && timeLeft > 0f)
        {
            RunPlayerTurn();
        }

        if (enemyTurn == true && timeLeft > 0f)
        {
            RunEnemyTurn();
        }

    }

    #region PlayerTurn

    public void StartPlayerTurn()
    {
        playerTurn = true;
        timeLeft = turnDuration;
        RunPlayerTurn();            
    }

    public void RunPlayerTurn()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            timeLeft = 0f;
            StopPlayerTurn();
        }
    }

    public void StopPlayerTurn()
    {
        playerTurn = false;
        StartEnemyTurn();
    }

    #endregion

    #region EnemyTurn

    public void StartEnemyTurn()
    {
        enemyTurn = true;
        timeLeft = turnDuration;
        RunEnemyTurn();
    }

    public void RunEnemyTurn()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            timeLeft = 0f;
            StopEnemyTurn();
        }
    }

    public void StopEnemyTurn()
    {
        enemyTurn = false;
        StartPlayerTurn();
    }

    #endregion

    public void StatCalculation()
    {
        //HP Calculation
        playerHP = (playerVit * playerBaseHP) / 2;
        Debug.Log(playerVit + " player Vitality x " + playerBaseHP + " + player Base HP = " + playerHP);
        enemyHP = (enemyVit * enemyBaseHP) / 2;
        Debug.Log(enemyVit + " enemy Vitality x " + enemyBaseHP + " + enemy Base HP = " + enemyHP);

        DexCalculation();
        SpdMultCalculator();
        MndHPCalculator();
    }

    public void DexCalculation()
    {
        playerAcc = (playerDex / enemySpd) * 100;
        Debug.Log("Player hit accuracy is " + playerAcc);
        enemyAcc = (enemyDex / playerSpd) * 100;
        Debug.Log("Enemy hit accuracy is " + playerAcc);
    }

    public void SpdMultCalculator()
    {
        playerSpdMult = (playerSpd * 0.01f) + 1f;
        Debug.Log("Player turn speed multiplier is " + playerSpdMult + "x");
        enemySpdMult = (enemySpd * 0.01f) + 1f;
        Debug.Log("Opponent turn speed multiplier is " + enemySpdMult + "x");
    }
    public void MndHPCalculator()
    {
        playerRestHP = (playerMnd * 10) / 2;
        Debug.Log("Player Rest HP value is " + playerRestHP);
        enemyRestHP = (enemyMnd * 10 / 2);
        Debug.Log("Enemy Rest HP value is " + enemyRestHP);
    }
}

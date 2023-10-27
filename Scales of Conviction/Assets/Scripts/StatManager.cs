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

    // Singleton instantiation
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

}

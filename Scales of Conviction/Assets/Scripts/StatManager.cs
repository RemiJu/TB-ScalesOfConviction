using UnityEngine;

public class StatManager : MonoBehaviour
{
    public float playerPoints;
    public float enemyPoints;
    public float pointsToAdd;
    public float pointsToRemove;
    public GameObject player;
    public Transform playerPosition;
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
        playerPosition = player.transform;
        Debug.Log(playerPosition);
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
}

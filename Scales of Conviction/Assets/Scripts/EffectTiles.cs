using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTiles : MonoBehaviour
{
    public int increment;
    public int halfIncrement;
    public int ApUp;
    void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "Effect A")
        {
            if (other.gameObject.tag == "Player")
            {
                StatManager.Instance.playerStr += increment;
                StatManager.Instance.playerSpd += halfIncrement;
                StatManager.Instance.playerPoints += ApUp;
            }
            else if (other.gameObject.tag == "Enemy")
            {
                StatManager.Instance.enemyStr += increment;
                StatManager.Instance.enemySpd += halfIncrement;
                StatManager.Instance.enemyPoints += ApUp;
            }
            else
            {
                return;
            }
        }
        if (gameObject.tag == "Effect B")
        {
            if (other.gameObject.tag == "Player")
            {
                StatManager.Instance.playerBaseHP += increment;
                StatManager.Instance.playerMnd += halfIncrement;
                StatManager.Instance.playerPoints += ApUp;
            }
            else if (other.gameObject.tag == "Enemy")
            {
                StatManager.Instance.enemyBaseHP += increment;
                StatManager.Instance.enemyMnd+= halfIncrement;
                StatManager.Instance.enemyPoints += ApUp;
            }
            else
            {
                return;
            }
        }
        if (gameObject.tag == "Effect C")
        {
            if (other.gameObject.tag == "Player")
            {
                StatManager.Instance.playerVit += increment;
                StatManager.Instance.playerSpd += halfIncrement;
                StatManager.Instance.playerPoints += ApUp;
            }
            else if (other.gameObject.tag == "Enemy")
            {
                StatManager.Instance.enemyVit += increment;
                StatManager.Instance.enemySpd += halfIncrement;
                StatManager.Instance.enemyPoints += ApUp;
            }
            else
            {
                return;
            }
        }
        if (gameObject.tag == "Effect D")
        {
            if (other.gameObject.tag == "Player")
            {
                StatManager.Instance.playerVit += increment;
                StatManager.Instance.playerStr += halfIncrement;
                StatManager.Instance.playerPoints += ApUp;
            }
            else if (other.gameObject.tag == "Enemy")
            {
                StatManager.Instance.enemyVit += increment;
                StatManager.Instance.enemyStr += halfIncrement;
                StatManager.Instance.enemyPoints += ApUp;
            }
            else
            {
                return;
            }
        }
    }
}

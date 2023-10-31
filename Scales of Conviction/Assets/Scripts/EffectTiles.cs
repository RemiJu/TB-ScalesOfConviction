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
                StatManager.Instance.playerAcc += increment;
                StatManager.Instance.playerAP += halfIncrement;
                StatManager.Instance.playerPoints += ApUp;
            }
            else if (other.gameObject.tag == "Enemy")
            {
                StatManager.Instance.enemyAcc += increment;
                StatManager.Instance.enemyAP += halfIncrement;
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
                StatManager.Instance.playerAP += increment;
                StatManager.Instance.playerDex += halfIncrement;
                StatManager.Instance.playerPoints += ApUp;
            }
            else if (other.gameObject.tag == "Enemy")
            {
                StatManager.Instance.enemyAP += increment;
                StatManager.Instance.enemyDex += halfIncrement;
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
                StatManager.Instance.playerMnd += increment;
                StatManager.Instance.playerSpd += halfIncrement;
                StatManager.Instance.playerPoints += ApUp;
            }
            else if (other.gameObject.tag == "Enemy")
            {
                StatManager.Instance.enemyMnd += increment;
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

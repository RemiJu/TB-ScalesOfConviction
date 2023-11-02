using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldStats : MonoBehaviour
{

    public enum statGoesTo
    {
        Strength,
        Dexterity,
        Vitality,
        Mind,
        Speed
    }
    public bool isOpponent;
    public statGoesTo whichStatGoesTo;
    private TMP_InputField inputField;
    public int inputInt;


    // Start is called before the first frame update
    void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateIntegerValue()
    {
        if (int.TryParse(inputField.text, out int newValue))
        {
            inputInt = newValue;
            switch (whichStatGoesTo)
            {
                case statGoesTo.Strength:
                    if(isOpponent)
                    {
                        StatManager.Instance.enemyStr = newValue;
                        break;
                    }
                    else
                    {
                        StatManager.Instance.playerStr = newValue;
                        break;
                    }
                case statGoesTo.Dexterity:
                    if (isOpponent)
                    {
                        StatManager.Instance.enemyDex = newValue;
                        break;
                    }
                    else
                    {
                        StatManager.Instance.playerDex = newValue;
                        break;
                    }
                case statGoesTo.Vitality:
                    if (isOpponent)
                    {
                        StatManager.Instance.enemyVit = newValue;
                        break;
                    }
                    else
                    {
                        StatManager.Instance.playerVit = newValue;
                        break;
                    }
                case statGoesTo.Mind:
                    if (isOpponent)
                    {
                        StatManager.Instance.enemyMnd = newValue;
                        break;
                    }
                    else
                    {
                        StatManager.Instance.playerMnd = newValue;
                        break;
                    }
                case statGoesTo.Speed:
                    if (isOpponent)
                    {
                        StatManager.Instance.enemySpd = newValue;
                        break;
                    }
                    else
                    {
                        StatManager.Instance.playerSpd = newValue;
                        break;
                    }
            }
            StatManager.Instance.StatCalculation();
            StatManager.Instance.SpdMultCalculator();
        }
    }

}

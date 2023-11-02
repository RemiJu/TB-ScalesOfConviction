using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPanelScript : MonoBehaviour
{
    public CombatActionManager actionManager;
    public Button command1; // Reference to the first UI Button
    public Button command2; // Reference to the second UI Button
    public Button command3; // Reference to the third UI Button

    public TextMeshProUGUI command1text;
    public TextMeshProUGUI command2text;  
    public TextMeshProUGUI command3text;

    public string command1Name;
    public string command2Name;
    public string command3Name;

    private void Awake()
    {
        actionManager = GameObject.Find("CombatActionManager").GetComponent<CombatActionManager>();
        // Add click listeners to the buttons
        command1text.text = command1Name;
        command2text.text = command2Name;
        command3text.text = command3Name;
        command1.onClick.AddListener(OnClickButton1);
        command2.onClick.AddListener(OnClickButton2);
        command3.onClick.AddListener(OnClickButton3);
    }

    private void OnClickButton1()
    {
        // This function is triggered when Button 1 is clicked
        Debug.Log("Button 1 was clicked!");
        actionManager.CommandAttack();
        // Add your custom logic for Button 1 here
    }

    private void OnClickButton2()
    {
        // This function is triggered when Button 2 is clicked
        Debug.Log("Button 2 was clicked!");
        actionManager.CommandDefend();
        // Add your custom logic for Button 2 here
    }

    private void OnClickButton3()
    {
        // This function is triggered when Button 3 is clicked
        Debug.Log("Button 3 was clicked!");
        actionManager.CommandRest();
        // Add your custom logic for Button 3 here
    }
}

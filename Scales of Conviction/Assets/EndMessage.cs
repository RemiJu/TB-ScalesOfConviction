using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMessage : MonoBehaviour
{
    private TextMeshProUGUI endMessage;
    // Start is called before the first frame update
    void Start()
    {
        endMessage = GetComponent<TextMeshProUGUI>();
        if(StatManager.Instance.playerHP <= 0)
        {
            endMessage.text = "RIP";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

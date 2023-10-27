using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void Update()
    {
        if (StatManager.Instance.playerTurn == true)
        {
            GetInput();
        }
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(1,0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(0, 0, 1) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(0, 0, -1) * speed * Time.deltaTime;
        }
    }
}

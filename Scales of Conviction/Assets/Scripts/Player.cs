using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetKey(KeyCode.D) && StatManager.Instance.playerTurn == true)
        {
            rb.velocity = new Vector3(1,0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && StatManager.Instance.playerTurn == true)
        {
            rb.velocity = new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && StatManager.Instance.playerTurn == true)
        {
            rb.velocity = new Vector3(0, 0, 1) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && StatManager.Instance.playerTurn == true)
        {
            rb.velocity = new Vector3(0, 0, -1) * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Combat");
        }
        if (collision.gameObject.tag == "Merchant")
        {
            //Include Shop System Here
        }
    }

}

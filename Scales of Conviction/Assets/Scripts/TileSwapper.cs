using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSwapper : MonoBehaviour
{    
    public GameObject[] tiles;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            CreateNewTile();
        }
    }

    void CreateNewTile()
    {
        Instantiate(tiles[Random.Range(0, tiles.Length)], transform.position, transform.rotation);
    }
}

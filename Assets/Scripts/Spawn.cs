using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform player;
    public string itemName;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // instantiate a new itemPrefab at the playerposition with the default rotation but a little far away from Player
    public void SpawnDroppedItem()
    {
        Vector3 playerposition = new Vector3(player.position.x, player.position.y, player.position.z + 4);
        Instantiate(itemPrefab, playerposition, Quaternion.identity);   
    }
}

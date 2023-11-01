using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameNamespace;

public class GameManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        // inventory = FindObjectOfType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameManager instance;
    public InventoryController inventory;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void RegisterInventory(InventoryController controller)
    {
        inventory = controller;
    }
}


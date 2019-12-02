using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActive : MonoBehaviour
{
    public GameObject Inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InventorySetActive() {

        if (!Inventory.active)
        {
            Inventory.SetActive(true);
        }
        else {
            Inventory.SetActive(false);
        }
    }
}

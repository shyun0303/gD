using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretRandom : MonoBehaviour
{
    public RectTransform[] item;
    public RectTransform slot;
    public GameObject go_SlotsParent;
 
    private Slot[] slots;
    private Shop shop;
    public int i = 0;
    private void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }

    public void RandomCreateTurret() {
        if (PlayerStats.Money >= 100)
        {
            //slot.AddItem();
            Debug.Log("생성 완료");
        }
        else {
            Debug.Log("생성 불가");
        }
    }
    public void Inventory_add() {
        if (PlayerStats.Money >= 100 && i <= slots.Length-1)
        {
            int k = 0;
            int r = Random.Range(0, item.Length);
            PlayerStats.Money -= 100;
            
            if (slots[i].transform.childCount == 0)
            {
                RectTransform child = Instantiate(item[r]);
                child.transform.position = slots[i].transform.position;
                child.transform.SetParent(slots[i].transform);
             
                
            }
            else {
                i++;
                RectTransform child = Instantiate(item[r]);
                child.transform.position = slots[i].transform.position;
                child.transform.SetParent(slots[i].transform);

     
            }
            


        }
        }
  


    }


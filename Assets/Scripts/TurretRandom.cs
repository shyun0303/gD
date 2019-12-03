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
        if (PlayerStats.Money >= 100)
        {
            int k = 0;
            int r = Random.Range(0, item.Length);
            PlayerStats.Money -= 100;
            
            RectTransform child = Instantiate(item[r]);
            while (k<slots.Length) {

                if (slots[k].transform.childCount == 0 || slots[k].transform.GetChild(0).tag == child.tag)
                {
                    child.transform.position = slots[k].transform.position;
                    child.transform.SetParent(slots[k].transform);
                    Debug.Log(slots[k].transform.GetChild(0).tag);
                   
                    break;

                }
                else
                {
                    k++;
                    
                    //i++;
                    //RectTransform child = Instantiate(item[r]);
                    //child.transform.position = slots[i].transform.position;
                    //child.transform.SetParent(slots[i].transform);
                }
     
            }
            


        }
        }
  


    }


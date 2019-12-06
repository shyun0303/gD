using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretRandom : MonoBehaviour
{
    public RectTransform[] item;
    public RectTransform slot;
    public GameObject go_SlotsParent;
    public Text amountsOfitems;
    public int amounts = 0;
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
    //public void Inventory_add() {
     //   if (PlayerStats.Money >= 100)
       // {
      
         //   PlayerStats.Money -= 100;
            
          /*  RectTransform child = Instantiate(item[r]);
            amountsOfitems = child.GetChild(0).GetChild(0).GetComponent<Text>();
            while (k<slots.Length) {

                if (slots[k].transform.childCount == 0)
                {
                    child.transform.position = slots[k].transform.position;
                    child.transform.SetParent(slots[k].transform);
                    amounts = 1;
                    amountsOfitems.text = Mathf.Floor(amounts).ToString();
                    Debug.Log(slots[k].transform.GetChild(0).tag);
                  
                    break;

                }
                else
                {
                    if (slots[k].transform.GetChild(0).tag == child.tag)
                    {
                        Debug.Log("포탑 갯수 증가");
                        amountsOfitems = slots[k].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
                        string s = amountsOfitems.text;
                        int incAmounts = int.Parse(s);
                        incAmounts++;
                        amountsOfitems.text = Mathf.Floor(incAmounts).ToString();

                        Destroy(child.gameObject);
                        break;
                    }
                    else { 
                    
                    k++;
                    }
                    
                    //i++;
                    //RectTransform child = Instantiate(item[r]);
                    //child.transform.position = slots[i].transform.position;
                    //child.transform.SetParent(slots[i].transform);
                }
     
            }*/
            


      //  }
        //}



    }


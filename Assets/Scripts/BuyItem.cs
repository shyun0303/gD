using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public itemBuffer itemBuffer;
    public Transform slotRoot;
    private List<Slot> slots;
    public itemProperty item;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();
        int slotCnt = slotRoot.childCount;

        for (int i = 0; i < slotCnt; i++) {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();
            slots.Add(slot);
        }

    }

    // Update is called once per frame

    public void Buyitems() {
        int k = 0;
        int r = Random.Range(0, itemBuffer.items.Count);
        PlayerStats.Money -= 100;

        while (k < slots.Count) {
            if (!slots[k].img.enabled)
            {
                slots[k].setItem(itemBuffer.items[r]);
                slots[k].amoutText.text = "1";
                break;
            }
            else {
                if (slots[k].item.name == itemBuffer.items[r].name) {
                    Debug.Log("수량증가");
                    string s = slots[k].amoutText.text;
                    int amount = int.Parse(s);
                    amount++;
                    slots[k].amoutText.text = Mathf.Floor(amount).ToString();
                    break;
                }
                else { 
                k++;
                }
            }
        }
    }
}

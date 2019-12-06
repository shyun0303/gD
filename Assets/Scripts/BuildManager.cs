using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public int amount;
    public Slot slot;
    private List<Slot> slots;
    public Transform slotRoot;
    public itemBuffer itemBuffer;
    void Awake()
    {
        if (instance != null) {
            Debug.LogError("More than one Build");
            return;
        }
        instance = this;    
        
    }
    private void Start()
    {
        slots = new List<Slot>();
        int slotCnt = slotRoot.childCount;

        for (int i = 0; i < slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();
            slots.Add(slot);
        }
    }
    public GameObject standardTurretPrefab;

    public GameObject anotherTurretPrefab;

    private TurretBluePrint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node,GameObject turret) {

        if (PlayerStats.Money < turretToBuild.cost) {
            Debug.Log("Not enough money to build that!");
            return;
        }
        if (turretToBuild.prefab != null)
        {
            

            string s = slot.amoutText.text;
            int amount = int.Parse(s);
            if (amount > 0) { 
            turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            node.turret = turret;
            }
            amount--;
            slot.amoutText.text = Mathf.Floor(amount).ToString();
            int k = 0;

            while (k < slots.Count)
            {
                if (!slots[k].img.enabled)
                {
                    slots[k].setItem(slot.item);
                    slots[k].amoutText.text = "1";
                    break;
                }
                else
                {
                    if (slots[k].item.name == slot.name)
                    {
                        Debug.Log("수량증가");
                        string ss = slots[k].amoutText.text;
                        int amounts = int.Parse(ss);
                        amounts++;
                        slots[k].amoutText.text = Mathf.Floor(amounts).ToString();
                        break;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            
            if (amount == 0) { 
                slot.setItem(null);

            }

        }

       
    }
    public void SelectTurretToBuild(TurretBluePrint turret) {
        turretToBuild = turret;
    }

 
}

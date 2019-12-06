using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBluePrint standardTurret;
    public TurretBluePrint anotherTurret;

    public Slot slot;
    void Start() {
        buildManager = BuildManager.instance;
    }
    public void SelectedTurret() {
        if (slot.item.name == "turret01") {
            SelectStandardTurret();
        }else if(slot.item.name == "turret02")
        {
            SelectAnotherTurret();
        }
    }
    public void SelectStandardTurret() {
        buildManager.slot = this.slot;
        Debug.Log("터렛 구매");
        buildManager.SelectTurretToBuild(standardTurret);
       
    }
    public void SelectAnotherTurret()
    {
        buildManager.slot = this.slot;

        Debug.Log("터렛 구매2");
        buildManager.SelectTurretToBuild(anotherTurret);
       

    }
}

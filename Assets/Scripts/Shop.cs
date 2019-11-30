using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBluePrint standardTurret;
    public TurretBluePrint anotherTurret;

    void Start() {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret() {
        Debug.Log("터렛 구매");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectAnotherTurret()
    {
        Debug.Log("터렛 구매2");
        buildManager.SelectTurretToBuild(anotherTurret);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null) {
            Debug.LogError("More than one Build");
            return;
        }
        instance = this;    
        
    }
    public GameObject standardTurretPrefab;

    public GameObject anotherTurretPrefab;

    private TurretBluePrint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node) {
        if (PlayerStats.Money < turretToBuild.cost) {
            Debug.Log("Not enough money to build that!");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
    public void SelectTurretToBuild(TurretBluePrint turret) {
        turretToBuild = turret;
    }

 
}

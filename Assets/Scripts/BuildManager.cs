using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public TurretRandom tr;
    public int amount;
    public Shop shop;
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

    public void BuildTurretOn(Node node,GameObject turret) {

        if (PlayerStats.Money < turretToBuild.cost) {
            Debug.Log("Not enough money to build that!");
            return;
        }
        if (turretToBuild.prefab != null)
        {
            turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            node.turret = turret;
            Debug.Log(Shop.amounts.text);
            string s = Shop.amounts.text;
            int amount = int.Parse(s);
            amount--;
            Shop.amounts.text = Mathf.Floor(amount).ToString();

            if (amount <= 0)
            {
                turretToBuild.prefab = null;
                Destroy(Shop.shop);
            }
            }

       
    }
    public void SelectTurretToBuild(TurretBluePrint turret) {
        turretToBuild = turret;
    }

 
}

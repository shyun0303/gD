using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBluePrint standardTurret;
    public TurretBluePrint anotherTurret;
    public static Text amounts;
    public static GameObject shop;
    void Start() {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret() {
        shop = this.gameObject;
        Debug.Log("터렛 구매");
        buildManager.SelectTurretToBuild(standardTurret);
        amounts = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        /* amounts = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();
         string s = amounts.text;
        amount = int.Parse(s);
       
        amounts.text = Mathf.Floor(amount).ToString();
        if (amount == 0) {
            Destroy(gameObject);
        }*/
    }
    public void SelectAnotherTurret()
    {
        shop = this.gameObject;
        Debug.Log("터렛 구매2");
        buildManager.SelectTurretToBuild(anotherTurret);
        amounts = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();

    }
}

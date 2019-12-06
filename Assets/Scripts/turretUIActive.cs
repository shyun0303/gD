using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretUIActive : MonoBehaviour
{
    public GameObject turretUI;
    public Slot slot;
    public void setTurretUI() {
        if (turretUI.active == false && slot.item != null)
        {
            turretUI.SetActive(true);
        }
        else {
            turretUI.SetActive(false);
        }
    }
}

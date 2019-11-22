using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;
    private Renderer rend;
    private Color StartColor;
    private Vector3 positionOffset = new Vector3(-2.5f, 3, 2.5f);


    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
    }

    void OnMouseDown() {
        if (turret != null) {
            Debug.Log("Can't build there");
            return;
        }
        //Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation );
    }
    void OnMouseEnter()
    {
        if (turret == null)
        {
            GetComponent<Renderer>().material.color = hoverColor;
        }
    }
    void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
}

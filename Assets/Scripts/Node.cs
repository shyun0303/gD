using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset = new Vector3(-2.5f, 3, 2.5f);

    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;
    private Color StartColor;

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }
    void OnMouseDown() {

        if (!buildManager.CanBuild) {
            return;
        }
        
        if (turret != null) {
            Debug.Log("Can't build there");
            return;
        }
        //Build a turret
        buildManager.BuildTurretOn(this);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        if (buildManager.CanBuild)
        {
            return;
        }
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
}

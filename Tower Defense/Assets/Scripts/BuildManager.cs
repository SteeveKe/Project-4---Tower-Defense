using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBluePrint turretToBuild;
    private Node SelectedNode;
    public GameObject buildEffect;
    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public void SelectNode(Node node)
    {
        if (node == SelectedNode)
        {
            DeselectNode();
            return;
        }
        SelectedNode = node;
        turretToBuild = null;
        
        nodeUI.SetTarget(SelectedNode);
    }

    public void DeselectNode()
    {
        SelectedNode = null;
        nodeUI.Hide();
    }
    
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}

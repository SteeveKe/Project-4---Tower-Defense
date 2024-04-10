using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBluePrint turretToBuild;
    private Node SelectedNode;
    public GameObject buildEffect;
    public GameObject sellEffect;
    public NodeUI nodeUI;
    public CinemachineVirtualCamera selectCamera;
    public CameraController mainCamera;

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

        mainCamera.canMove = false;
        Transform nodeTransform = node.transform;
        selectCamera.LookAt = nodeTransform;
        selectCamera.Follow = nodeTransform;
        selectCamera.gameObject.SetActive(true);
        
        SelectedNode = node;
        turretToBuild = null;
        
        nodeUI.SetTarget(SelectedNode);
    }

    public void DeselectNode()
    {
        mainCamera.canMove = true;
        selectCamera.LookAt = null;
        selectCamera.Follow = null;
        selectCamera.gameObject.SetActive(false);
        
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

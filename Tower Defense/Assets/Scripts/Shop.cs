using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint stantardTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint LaserBeamer;
    
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(stantardTurret);
    }
    
    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    
    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(LaserBeamer);
    }
}

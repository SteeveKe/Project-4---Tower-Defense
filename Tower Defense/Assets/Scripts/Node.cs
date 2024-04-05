using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;

    [HideInInspector] 
    public TurretBluePrint turretBluePrint;

    [HideInInspector] 
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        
        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStats.Money < bluePrint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= bluePrint.cost;
        
        GameObject _turret = Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = bluePrint;

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret build!");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBluePrint.upgradeCost)
        {
            Debug.Log("Not enough money to update that!");
            return;
        }

        PlayerStats.Money -= turretBluePrint.upgradeCost;
        
        Destroy(turret);
        
        GameObject _turret = Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        
        Debug.Log("Turret upgraded!");
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBluePrint.GetSellAmount();
        
        GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        Destroy(turret);
        turretBluePrint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

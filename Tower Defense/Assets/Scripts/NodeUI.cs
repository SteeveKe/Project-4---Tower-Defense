using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public TMP_Text upgradeCost;
    public Button upgradeButton;

    public TMP_Text sellAmount;
    private Node _target;

    public void SetTarget(Node target)
    {
        _target = target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "UPGRADE\n$" + target.turretBluePrint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "ALREADY\nUPGRADED";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "SELL\n$" + _target.turretBluePrint.GetSellAmount();
        
        ui.SetActive(true);
    }
    
    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        _target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}

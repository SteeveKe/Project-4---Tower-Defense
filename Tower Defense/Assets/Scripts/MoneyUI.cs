using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
   public TMP_Text moneyText;

   private void Update()
   {
      moneyText.text = "$" + PlayerStats.Money;
   }
}

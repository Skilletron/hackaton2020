using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text BalanceMenu;
    public SaveAllGame Money;

    private void Update()
    {
        BalanceMenu.GetComponent<Text>().text = Money.Money.ToString("0");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeClickButton : MonoBehaviour

{

    public Text MoneyText;

    public Text buyText;
    public float buyMoney;
    public float buyMulti;

    public mainDuck duckScript;

    private Button upgradeb;

    // Start is called before the first frame update
    void Start()
    {
        upgradeb = this.GetComponent<Button>();

        upgradeb.onClick.AddListener(clickedUpgrade);
    }

    // Update is called once per frame
    void clickedUpgrade()
    {
        if (duckScript.money >= buyMoney)
        {
            duckScript.money = duckScript.money - buyMoney;
            MoneyText.text = "$" + duckScript.money.ToString("F2");
            duckScript.onClickMoney = duckScript.onClickMoney + 0.01f;
            duckScript.onClickMoney = (Mathf.Round(duckScript.onClickMoney * 100)) / 100.0f;

            buyMoney = buyMoney * buyMulti;

            buyMoney = (Mathf.Round(buyMoney * 100)) / 100.0f;

            buyText.text = "$" + buyMoney + "\r\nCLICK MONEY\r\n$" + duckScript.onClickMoney + " > $" + (duckScript.onClickMoney + 0.01f);
        }
        else return;
        
    }
}

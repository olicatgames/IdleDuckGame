using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntervalTimeButton : MonoBehaviour
{
    public Text MoneyText;

    public GameObject buyText;
    public float buyMoney;
    public float buyMulti;

    public float startingInterval;

    public GameObject duck;

    private Button upgradeb;



    void Start()
    {
        upgradeb = this.GetComponent<Button>();

        upgradeb.onClick.AddListener(clickedUpgrade);
    }

    // Update is called once per frame
    void clickedUpgrade()
    {
        
        if(duck.GetComponent<mainDuck>().money >= buyMoney)
        {

            if (!duck.GetComponent<mainDuck>().firstBuy && duck.GetComponent<mainDuck>().moneyInterval > 1.1f)
            {

                duck.GetComponent<mainDuck>().money = duck.GetComponent<mainDuck>().money - buyMoney;

                MoneyText.text = "$" + duck.GetComponent<mainDuck>().money.ToString("F2");

                duck.GetComponent<mainDuck>().moneyInterval = duck.GetComponent<mainDuck>().moneyInterval - 1;

                buyMoney = buyMoney * buyMulti;

                buyText.GetComponent<Text>().text = "$" + buyMoney + "\r\nTICK TIME\r\n" + duck.GetComponent<mainDuck>().moneyInterval + "S > " + (duck.GetComponent<mainDuck>().moneyInterval - 1) + "S";

            }
            else
            {
                duck.GetComponent<mainDuck>().money = duck.GetComponent<mainDuck>().money - buyMoney;

                MoneyText.text = "$" + duck.GetComponent<mainDuck>().money.ToString("F2");

                duck.GetComponent<mainDuck>().moneyInterval = startingInterval;

                buyMoney = buyMoney * buyMulti;

                buyText.GetComponent<Text>().text = "$" + buyMoney + "\r\nTICK TIME\r\n" + duck.GetComponent<mainDuck>().moneyInterval + "S > " + (duck.GetComponent<mainDuck>().moneyInterval - 1) + "S";

                duck.GetComponent<mainDuck>().startAuto();

            }
            }
        else
        {
            return;
        }

    }
}

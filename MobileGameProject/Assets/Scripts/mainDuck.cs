using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainDuck : MonoBehaviour
{

    private Button duck;
    public Text moneyCount;

    public Image intervalRep;

    public float money;
    public float onClickMoney;
    public float moneyInterval;


    private AudioSource quack;

    // Start is called before the first frame update
    void Start()
    {
        quack = this.GetComponent<AudioSource>();
        duck = this.GetComponent<Button>();

        duck.onClick.AddListener(DuckClick);

        StartCoroutine(AutomationMoney(moneyInterval));
        StartCoroutine(InterRepFillProg(moneyInterval));
    }

    // Update is called once per frame
    void DuckClick()
    {
        Debug.Log("Click");
        money = money + onClickMoney;
        quack.Play();

        moneyCount.text = "$" + money.ToString("F2");

    }

    IEnumerator AutomationMoney(float moneyInt)
    {
        while (true)
        {

            yield return new WaitForSeconds(moneyInt);
            intervalRep.fillAmount = 0;
        //    StartCoroutine(InterRepFillProg(moneyInterval));
            Debug.Log("AutoQuack");
            moneyCount.text = "$" + money.ToString("F2");
            this.GetComponent<Button>().onClick.Invoke();        }
    }


    IEnumerator InterRepFillProg(float fillProg)
    {
        while(intervalRep.fillAmount < 1){
            intervalRep.fillAmount = intervalRep.fillAmount + 0.005f;
            yield return new WaitForSeconds(moneyInterval / 200f);

        }
    }
}


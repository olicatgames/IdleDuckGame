using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainDuck : MonoBehaviour
{

    private Button duck;
    public Text moneyCount;

    public float money;
    public float onClickMoney;

    private AudioSource quack;

    // Start is called before the first frame update
    void Start()
    {
        quack = this.GetComponent<AudioSource>();
        duck = this.GetComponent<Button>();
        duck.onClick.AddListener(DuckClick);
    }

    // Update is called once per frame
    void DuckClick()
    {
        Debug.Log("Click");
        money = money + onClickMoney;
        quack.Play();


        moneyCount.text = "$" + money.ToString("F2");
    }
}

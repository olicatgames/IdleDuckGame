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
    public float onAutoMoney;
    public float moneyInterval;

    public Sprite duckAnim;
    public Sprite baseAnim;

    private AudioSource quack;

    public GameObject upgradeButton;

    public bool firstBuy = true;

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

    public IEnumerator AutomationMoney()
    {
        while (true && !firstBuy)
        {
                yield return new WaitForSeconds(moneyInterval);
                intervalRep.fillAmount = 0;
                Debug.Log("AutoQuack");
                money = money + onAutoMoney;
                moneyCount.text = "$" + money.ToString("F2");
                quack.Play();
                StartCoroutine(AnimateDuck());

        }
    }

    public void startAuto()
    {
        firstBuy = false;
        StartCoroutine(AutomationMoney());
        StartCoroutine(InterRepFillProg());
    }


    public IEnumerator InterRepFillProg()
    {
        while(true && !firstBuy){
                intervalRep.fillAmount = intervalRep.fillAmount + 0.0053f;
                yield return new WaitForSeconds(moneyInterval / 200f);

        }
    }

    IEnumerator AnimateDuck()
    {
        this.GetComponent<Image>().sprite = duckAnim;
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Image>().sprite = baseAnim;
    }
}


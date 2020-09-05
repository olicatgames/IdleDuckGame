using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openUpgradeMenu : MonoBehaviour
{

    private Button upgradeButton;
    public GameObject upgradeMenu;
    private bool isOpen;

    private AudioSource beep;
    // Start is called before the first frame update
    void Start()
    {
        upgradeButton = this.GetComponent<Button>();
        upgradeButton.onClick.AddListener(OpenUpgrades);

        beep = this.GetComponent<AudioSource>();
    }

    void OpenUpgrades()
    {
        if (!isOpen)
        {
            upgradeMenu.SetActive(true);
            beep.pitch = 1;
            beep.Play();
            isOpen = true;
        }
        else
        {
            upgradeMenu.SetActive(false);
            beep.pitch = 0.9f;
            beep.Play();
            isOpen = false;
        }
    }

}

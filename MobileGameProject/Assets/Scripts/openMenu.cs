using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openMenu : MonoBehaviour
{

    private Button setButton;
    public GameObject assocMenu;
    private bool isOpen;

    public bool isContextMenu;

    private AudioSource beep;
    // Start is called before the first frame update
    void Start()
    {
        setButton = this.GetComponent<Button>();
        setButton.onClick.AddListener(OpenMenu);

        beep = this.GetComponent<AudioSource>();
    }

    void OpenMenu()
    {
        if (!isOpen)
        {

            assocMenu.SetActive(true);
            beep.pitch = 1;
            beep.Play();
            isOpen = true;

        }
        else
        {

            assocMenu.SetActive(false);
            beep.pitch = 0.9f;
            beep.Play();
            isOpen = false;

        }
    }

}

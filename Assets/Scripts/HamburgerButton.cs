using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HamburgerButton : MonoBehaviour
{


    public Button testButton;
    public GameObject panelMenu;
    //animator reference
    private Animator anim;
    //variable for checking if the game is paused 
    private bool isPop;
    // Use this for initialization

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        isPop = false;
        //get the animator component
        anim = panelMenu.GetComponent<Animator>();
        //disable it on start to stop it from playing the default animation
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickHambergerButton()
    {
        PopUpPanelSlide();
        HideTestButton();
    }

    public void PopUpPanelSlide()
    {
        if (!isPop)
        {
            SlideInEvent();
            isPop = true;
            Debug.Log("eiei ispop = false");
        }
        else if (isPop)
        {
            SlideOutEvent();
            isPop = false;
            Debug.Log("eiei ispop = ture");
        }
    }

    public void SlideInEvent()
    {
        //enable the animator component
        anim.enabled = true;
        //play the Slidein animation
        anim.Play("SlideIn");
        //freeze the timescale
        Time.timeScale = 0;
    }

    public void SlideOutEvent()
    {
        //enable the animator component
        anim.enabled = true;
        //play the Slidein animation
        anim.Play("SlideOut");
        //freeze the timescale
        Time.timeScale = 0;
    }

    public void HideTestButton()
    {
        testButton.gameObject.SetActive(!isPop);
    }
}

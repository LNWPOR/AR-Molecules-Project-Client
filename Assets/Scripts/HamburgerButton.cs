using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HamburgerButton : MonoBehaviour
{
    public GameObject mainEditMolecule;
    public Button leftArrowButton;
    public Button rightArrowButton;
    public Button searchButton;
    public Button testButton;
    public GameObject panelMenu;
    //animator reference
    private Animator anim;
    public bool isPop;


    // Use this for initialization
    void Start()
    {
        //Time.timeScale = 1;
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
        PopUpPanelSlide(isPop);
    }

    public void PopUpPanelSlide(bool isSlide)
    {
        if (!isSlide)
        {
            SlideInEvent();
            isPop = true;
            //Debug.Log("eiei ispop = false");
        }
       else if (isSlide)
        {
            SlideOutEvent();
            isPop = false;
            //Debug.Log("eiei ispop = ture");
        }
    }

    public void SlideInEvent()
    {
        //enable the animator component
        anim.enabled = true;
        //play the Slidein animation
        anim.Play("SlideIn");
        //freeze the timescale
        //Time.timeScale = 0;
        SetShowObject(false);
        SetInteractableButton(false);
    }

    public void SlideOutEvent()
    {
        //enable the animator component
        anim.enabled = true;
        //play the Slidein animation
        anim.Play("SlideOut");
        //freeze the timescale
        //Time.timeScale = 0;
        SetShowObject(true);
        SetInteractableButton(true);


    }

    public void SetShowObject(bool isShow)
    {
        SetButtonHideOrShow(isShow);
        SetMoleculeHideOrShow(isShow);
    }
    
    private void SetButtonHideOrShow(bool setButton)
    {
        leftArrowButton.gameObject.SetActive(setButton);
        rightArrowButton.gameObject.SetActive(setButton);
        testButton.gameObject.SetActive(setButton);
    }

    private void SetMoleculeHideOrShow(bool setMolecule)
    {
        mainEditMolecule.SetActive(setMolecule);
    }

    private void SetInteractableButton(bool setButton)
    {
        searchButton.GetComponent<Button>().interactable = setButton;
    }

}

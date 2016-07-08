using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ConfirmBoxMessage : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    public Button searchButton;
    public GameObject confirmPanel;
    private bool isAnswer; // yes = true , no = false;

    // Use this for initialization
    void Start()
    {
        isAnswer = false;
        confirmPanel.SetActive(false);
    }

    // Update is called once per frame
    public void OnClicSearchButton()
    {
        confirmPanel.SetActive(true);
    }

    public void OnClickYesButton()
    {
        isAnswer = true;
        confirmPanel.SetActive(true);
    }

    public void OnClickNoButton()
    {
        isAnswer = false;
        confirmPanel.SetActive(false);
    }
}

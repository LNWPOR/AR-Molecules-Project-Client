using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ConfirmBoxMessage : MonoBehaviour
{
    public Button yesButton;
    public GameObject mainEditMolecule;
    public Button noButton;
    public Button searchOrEditButton;
    public GameObject confirmPanel;
    private bool isAnswer; // yes = true , no = false;

    // Use this for initialization
    void Start()
    {
        isAnswer = false;
        confirmPanel.SetActive(false);
    }

    // Update is called once per frame
    public void OnClicSearchOrEditButton()
    {
        isAnswer = true;
        confirmPanel.SetActive(true);
        SetShowModel(false);
    }

    public void OnClickYesButton()
    {
        isAnswer = true;
        SceneManager.LoadScene("menu");
    }

    public void OnClickNoButton()
    {
        isAnswer = false;
        Debug.Log("test");
        confirmPanel.SetActive(false);
        SetShowModel(true);
    }

    public void SetShowModel(bool isSet)
    {
        mainEditMolecule.SetActive(isSet);
    }
}

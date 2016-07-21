using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ConfirmBoxMessage : MonoBehaviour
{
    public Text username;
    public Button yesButton;
    public GameObject mainEditMolecule;
    public Button noButton;
    public Button searchOrEditButton;
    public GameObject confirmPanel;
    private bool isAnswer; // yes = true , no = false;

    private GameObject mainCamera;
    private CameraEditorController cameraEditorControllerScript;

    // Use this for initialization
    void Start()
    {
        isAnswer = false;
        confirmPanel.SetActive(false);
        GetCameraEditorController();
    }

    private void GetCameraEditorController()
    {
        mainCamera = GameObject.Find("Main Camera"); // Fine (Object in hierarchy)
        if (mainCamera != null)
        {
            cameraEditorControllerScript = mainCamera.GetComponent<CameraEditorController>();
        }
    }

    // Update is called once per frame
    public void OnClicSearchOrEditButton()
    {
        isAnswer = true;
        confirmPanel.SetActive(true);
        SetShowModel(false);
        SetClickSignOut(false);
        ControlCameraPosition(false);
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
        SetClickSignOut(true);
        ControlCameraPosition(true);
    }

    public void SetShowModel(bool isSet)
    {
        mainEditMolecule.SetActive(isSet);
    }
    
    public void SetClickSignOut(bool isSet)
    {
        username.GetComponent<CapsuleCollider>().enabled = isSet;
    }

    public void ControlCameraPosition(bool isSet)
    {
        cameraEditorControllerScript.canMove = isSet;
        cameraEditorControllerScript.canZoom = isSet;
    }
}

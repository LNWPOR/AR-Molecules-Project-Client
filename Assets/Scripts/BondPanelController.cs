using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BondPanelController : MonoBehaviour {

    public Text username;
    public Button leftArrowButton;
    public Button rightArrowButton;
    public Button menuButton;
    public Button searchButton;

    public Button closeButton;
    public Button singleBondButton;
    public Button doubleBondButton;
    public Button trippleBondButton;
    public Button lonePairButton;
    public Button deleteButton; // delete button
    public Button cancelBnt;
    public Button delBnt; // delete stick
    public GameObject currentEditStickGroup;

    private GameObject mainCamera;
    private CameraEditorController cameraEditorControllerScript;

    void Awake()
    {
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(() => OnClickCloseButton());
        singleBondButton.onClick.AddListener(() => SetStickGroup("Stick1"));
        doubleBondButton.onClick.AddListener(() => SetStickGroup("Stick2"));
        trippleBondButton.onClick.AddListener(() => SetStickGroup("Stick3"));
        lonePairButton.onClick.AddListener(() => SetStickGroup("Electron2"));
        delBnt.onClick.AddListener(() => SetStickGroup("del"));
    }

    void Start()
    {
        ShowOrHideConfirmButton(false);
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

    public void OnClickCloseButton()
    {
        CloseBondPanel();
    }
    
    public void SetStickGroup(string stickActiveName)
    {
        Transform[] stickGroupChilds = currentEditStickGroup.GetComponentsInChildren<Transform>(true);
        if (stickActiveName.Equals("del"))
        {
            Destroy(currentEditStickGroup);
        }
        else
        {
            foreach (Transform stickGroupChild in stickGroupChilds)
            {
                if (stickGroupChild.gameObject.tag.Equals("Bond") || stickGroupChild.gameObject.tag.Equals("Lone"))
                {
                    if (stickGroupChild.gameObject.name.Equals(stickActiveName))
                    {
                        stickGroupChild.gameObject.SetActive(true);
                    }
                    else
                    {
                        stickGroupChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        CloseBondPanel();
        SetButtonHideOrShow(true);
        ControlCameraPosition(true);
    }

    private void CloseBondPanel()
    {
        gameObject.SetActive(false);
        currentEditStickGroup.transform.parent.gameObject.SetActive(true);
        SetButtonHideOrShow(true);
        ControlCameraPosition(true);
    }

    public void OnClickDeleteButton()
    {
        ShowOrHideConfirmButton(true);
    }

    public void OnClickbCancelButton()
    {
        ShowOrHideConfirmButton(false);
    }

    public void ShowOrHideConfirmButton(bool isShow)
    {
        cancelBnt.gameObject.SetActive(isShow);
        delBnt.gameObject.SetActive(isShow);
    }


    private void SetButtonHideOrShow(bool setButton)
    {
        leftArrowButton.GetComponent<Button>().interactable = setButton;
        rightArrowButton.GetComponent<Button>().interactable = setButton;
        menuButton.GetComponent<Button>().interactable = setButton;
        searchButton.GetComponent<Button>().interactable = setButton;
        username.GetComponent<CapsuleCollider>().enabled = setButton;
    }

    public void ControlCameraPosition(bool isSet)
    {
        cameraEditorControllerScript.canMove = isSet;
        cameraEditorControllerScript.canZoom = isSet;
    }

}

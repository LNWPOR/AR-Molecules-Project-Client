using UnityEngine;
using System.Collections;

public class UserNameScript : MonoBehaviour {

    public GameObject signoutPanel;
    public GameObject mainEditMolecule;

    private GameObject mainCamera;
    private CameraEditorController cameraEditorControllerScript;


    // Use this for initialization
    void Start () {
        signoutPanel.SetActive(false);
        GetCameraEditorController();

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void GetCameraEditorController()
    {
        mainCamera = GameObject.Find("Main Camera"); // Fine (Object in hierarchy)
        if (mainCamera != null)
        {
            cameraEditorControllerScript = mainCamera.GetComponent<CameraEditorController>();
        }
    }

    void OnMouseDown()
    {
        //Debug.Log("eiei");
        CallSignOutPopup();
        SetShowModel(false);
        ControlCameraPosition(false);

    }


    public void CallSignOutPopup()
    {
        signoutPanel.SetActive(true);
        
    }


    public void SetShowModel(bool isSet)
    {
        mainEditMolecule.SetActive(isSet);
    }

    public void ControlCameraPosition(bool isSet)
    {
        cameraEditorControllerScript.canMove = isSet;
        cameraEditorControllerScript.canZoom = isSet;
    }
}

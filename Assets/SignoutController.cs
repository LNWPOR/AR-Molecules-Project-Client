using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SignoutController : MonoBehaviour {

    public GameObject mainEditMolecule;
    public Button CancelButton;

    private GameObject mainCamera;
    private CameraEditorController cameraEditorControllerScript;

    // Use this for initialization
    void Start () {
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
    public void OnClickCancelButton()
    {
        gameObject.SetActive(false);
        SetShowModel(true);
        ControlCameraPosition(true);
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

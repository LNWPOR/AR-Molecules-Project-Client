using UnityEngine;
using System.Collections;
public class StickGroupController : MonoBehaviour {

    private GameObject bondPanel;

    // Use this for initialization
    void Start () {
        bondPanel = GameObject.Find("BondPanel");

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Debug.Log("eiei");
        CallBondPopup();
    }

    public void CallBondPopup()
    {
        bondPanel.GetComponent<CanvasGroup>().alpha = 1f;
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PeriodicTableController : MonoBehaviour
{
    public Transform periodicTablePanel;
    public Canvas editorCanvas;
    public GameObject[] elementPrefabs;
    public GameObject elementPrefabInitiated;
    public Transform elementDetailPanel;

    private bool canMove = false;
    private Vector3 moveTarget;
    private float moveTime;
    private float fracJourney;
    public float moveDistance;

    void Start()
    {
        fracJourney = 0.05f;
        moveDistance = editorCanvas.GetComponent<RectTransform>().rect.height/2;
        moveTime = moveDistance/fracJourney;
        elementPrefabInitiated = null;
    }

    public GameObject[] getElementPrefabs()
    {
        return elementPrefabs;
    }

    public GameObject getElementPrefabInitiated()
    {
        return elementPrefabInitiated;
    }

    public void setElementPrefabInitiated(GameObject newElementPrefabInitiated)
    {
        elementPrefabInitiated = newElementPrefabInitiated;
    }

    void Update()
    {
        if (canMove)
        {
            MovePeriodicTablePanel();
        }
    }

    public void SetElementDetailPanelText(ElementData elementForButton)
    {
        Text[] elementDetailPanelText = elementDetailPanel.GetComponentsInChildren<Text>();
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomNameText")).text     = " Name : " + elementForButton.name;
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomNumberText")).text   = " Number : " + elementForButton.atomNumber.ToString();
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomMassText")).text     = " Mass : " + elementForButton.mass.ToString();
        if (elementForButton.en.Equals(-1))
        {
            Array.Find(elementDetailPanelText, s => s.name.Equals("AtomEnText")).text = " En : NaN";
        }
        else
        {
            Array.Find(elementDetailPanelText, s => s.name.Equals("AtomEnText")).text = " En : " + elementForButton.en.ToString();
        }

    }

    public void ClosePeriodicTable()
    {
        if (elementPrefabInitiated != null)
        {
            Destroy(elementPrefabInitiated);
        }
        
        Vector3 newMoveTarget = new Vector3(periodicTablePanel.transform.position.x,
                                            periodicTablePanel.transform.position.y - moveDistance,
                                            periodicTablePanel.transform.position.z);
        StartMovePeriodicTablePanel(newMoveTarget);
        ResetElementDetailPanelText();
    }

    private void ResetElementDetailPanelText()
    {
        Text[] elementDetailPanelText = elementDetailPanel.GetComponentsInChildren<Text>();
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomNameText")).text = "";
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomNumberText")).text = "";
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomMassText")).text = "";
        Array.Find(elementDetailPanelText, s => s.name.Equals("AtomEnText")).text = "";
    }

    private void StartMovePeriodicTablePanel(Vector3 newMoveTarget)
    {
        canMove = true;
        moveTarget = newMoveTarget;
        StartCoroutine(WaitMoving(moveTime));
    }

    private void MovePeriodicTablePanel()
    {
        periodicTablePanel.transform.position = Vector3.Lerp(periodicTablePanel.transform.position, moveTarget, fracJourney);
    }

    private IEnumerator WaitMoving(float time)
    {
        float count = 0;
        while (count < time)
        {
            count += Time.deltaTime;
            // Debug.Log(Mathf.Floor(count));
            yield return new WaitForEndOfFrame();
        }
        canMove = false;
    }


    


    
}

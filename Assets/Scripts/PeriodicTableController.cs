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

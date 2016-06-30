using UnityEngine;
using System.Collections;

public class HambergerButton : MonoBehaviour {

    public Transform popUpPanel;

    private float fracJourney;
    private float moveTime;
    private float moveDistance;

    private bool canMove;
    private Vector3 moveTarget;

    void Start()
    {
        canMove = false;
        fracJourney = 0.5f;
        moveDistance = 10f;
        moveTime = moveDistance / fracJourney;
    }

    void Update()
    {
        if (canMove)
        {
            MovePopUpPanel();
        }
    }

    public void OnClickHambergerButton()
    {
        StartMovePopUpPanel();
    }

    private void StartMovePopUpPanel()
    {
        moveTarget = new Vector3(popUpPanel.transform.position.x + moveDistance,
                                  popUpPanel.transform.position.y,
                                  popUpPanel.transform.position.z
                                );
        canMove = true;
        StartCoroutine(WaitMoving(moveTime));
    }

    private void MovePopUpPanel()
    {
        popUpPanel.transform.position = Vector3.Lerp(popUpPanel.transform.position, moveTarget, fracJourney);
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

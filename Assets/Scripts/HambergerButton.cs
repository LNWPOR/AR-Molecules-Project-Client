using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HambergerButton : MonoBehaviour {

    public Transform popUpPanel;
    public Button testButton;

    private float fracJourney;
    private float moveTime;
    private float moveDistance;

	private bool isClick;
    private bool canMove;
    private Vector3 moveTarget;

    void Start()
    {
        canMove = false;
		isClick = false;
		fracJourney = 0.5f; //acceleration
        moveDistance = 266f; 
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
        HideTestButton();
    }

    private void StartMovePopUpPanel()
    {
		PopUpMove ();
        canMove = true;
        StartCoroutine(WaitMoving(moveTime));
    }

    private void MovePopUpPanel()
    {
        popUpPanel.transform.position = Vector3.Lerp(popUpPanel.transform.position, moveTarget, fracJourney);   
    }

    private IEnumerator WaitMoving(float time)  // counting time 
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

	private void PopUpMove()
	{
		if(!isClick)
		{
			Debug.Log ("Click");
			moveTarget = new Vector3(popUpPanel.transform.position.x + moveDistance,
			popUpPanel.transform.position.y,
			popUpPanel.transform.position.z
			);
            isClick = true;
		}
		else if(isClick)
		{
			Debug.Log ("Un Click");
			moveTarget = new Vector3(popUpPanel.transform.position.x - moveDistance,
			popUpPanel.transform.position.y,
			popUpPanel.transform.position.z
			);
            isClick = false;
		}
	}

    private void HideTestButton()
    {
        testButton.gameObject.SetActive(!isClick);
    }

}

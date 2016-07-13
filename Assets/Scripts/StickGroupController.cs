using UnityEngine;
using System.Collections;

public class StickGroupController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        OnMouseDown();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("Click Stick");
    }

}

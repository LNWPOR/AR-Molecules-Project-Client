using UnityEngine;
using System.Collections;

public class AtomController : MonoBehaviour {

    private Vector3 rotateCenter;
	// Use this for initialization
	void Start () {
        rotateCenter = new Vector3(transform.position.x -2f,
                                   transform.position.y,
                                   transform.position.z);


	}
	
	// Update is called once per frame
	void Update () {

        transform.RotateAround(rotateCenter, Vector3.up, 200 * Time.deltaTime);
    }
}

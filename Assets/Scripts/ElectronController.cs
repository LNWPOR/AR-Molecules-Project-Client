using UnityEngine;
using System.Collections;

public class ElectronController : MonoBehaviour {

    private Vector3 parentAtomPosion;
	// Use this for initialization
	void Start () {
        //parentAtomPosion = new Vector3(transform.parent.transform.position.x,
        //                               transform.parent.transform.position.y,
        //                               transform.parent.transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {
       // transform.RotateAround(parentAtomPosion, Vector3.up, 500 * Time.deltaTime);
    }
}

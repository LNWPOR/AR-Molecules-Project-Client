using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewButtonController : MonoBehaviour {


    public string moleculeName;
	// Use this for initialization
	void Start () {
        GetComponentsInChildren<Text>()[0].text = " " + moleculeName;
    }
	
    public void onClickThisMoleculeName()
    {
        //Debug.Log(moleculeName);
        MainManager.Instance.moleculeSelected = MainManager.Instance.moleculeList.Find(x => x.name.Contains(moleculeName));
        SceneManager.LoadScene("main");
    }


}

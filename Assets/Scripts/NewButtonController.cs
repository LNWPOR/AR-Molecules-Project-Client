using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewButtonController : MonoBehaviour {


    public string moleculeName;

    private GameObject mainManager;
    private MainManager mainManagerScript;
    // Use this for initialization

    void Awake()
    {
        GetMainManager();
    }

    void Start () {
        GetComponentsInChildren<Text>()[0].text = " " + moleculeName;
    }

    private void GetMainManager()
    {
        mainManager = GameObject.Find("MainManager");
        mainManagerScript = mainManager.GetComponent<MainManager>();
    }

    public void OnClickThisMoleculeName()
    {
        //Debug.Log(moleculeName);
        mainManagerScript.moleculeJSONSelected = mainManagerScript.moleculesJSONList.Find(x => Converter.JsonToString(x.GetField("name").ToString()).Equals(moleculeName));
        SceneManager.LoadScene("main");
    }


}

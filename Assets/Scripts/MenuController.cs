using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {


    public Button[] axeBtn;

    void Awake()
    {
        SetButton();
        initManager();
    }

    private void initManager()
    {
        //DontDestroyOnLoad(MainManager.Instance.gameObject);
    }

    private void SetButton()
    {
        axeBtn[0].onClick.AddListener(() => OnClickAXE(0));
        axeBtn[1].onClick.AddListener(() => OnClickAXE(1));
        axeBtn[2].onClick.AddListener(() => OnClickAXE(2));
        axeBtn[3].onClick.AddListener(() => OnClickAXE(3));
        axeBtn[4].onClick.AddListener(() => OnClickAXE(4));
    }

    private void OnClickAXE(int axeNumber)
    {
        //Debug.Log(axeNumber);
        //MainManager.Instance.axeNumber = axeNumber;
        SceneManager.LoadScene("main");
    }
}

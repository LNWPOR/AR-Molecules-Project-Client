using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TestBackButton : MonoBehaviour
{

    public Button backButton;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void OnClickBackButton()
    {
        SceneManager.LoadScene("Edit");
    }
}

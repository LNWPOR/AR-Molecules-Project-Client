using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlSceneButton : MonoBehaviour
{

    public Button nextButton;
    public Button testEditButton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void OnClickNextButton()
    {
        SceneManager.LoadScene("save");
    }

    public void OnClickTestEditButton()
    {
        SceneManager.LoadScene("test");
    }
}

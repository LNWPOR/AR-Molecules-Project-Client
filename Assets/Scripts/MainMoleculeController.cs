using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMoleculeController : MonoBehaviour {

    public Button playButton;
    public Button pauseButton;
    private Vector3 rotateCenter;
    private bool isPause;


    // Use this for initialization
    void Start () {
        isPause = false;
        playButton.gameObject.SetActive(false);
        rotateCenter = new Vector3(transform.position.x,
                                   transform.position.y,
                                   transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPause)
        {
            transform.RotateAround(rotateCenter, Vector3.up, 100 * Time.deltaTime);
        }
    }

    public void OnClickPauseButton()
    {
        isPause = true;
        ShowPlayOrPauseButton(isPause);
    }

    public void OnClickPlayButton()
    {
        isPause = false;
        ShowPlayOrPauseButton(isPause);
    }

    public void ShowPlayOrPauseButton(bool isShow)
    {
        playButton.gameObject.SetActive(isShow);
        pauseButton.gameObject.SetActive(!isShow);
    }

}

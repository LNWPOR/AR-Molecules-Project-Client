using UnityEngine;
using System.Collections;
using SocketIO;
using UnityEngine.SceneManagement;

public class SignOutButton : MonoBehaviour {

    public GameObject messageBoxPanel;
    private MessageBoxController messageBoxControllerScript;

    void Awake()
    {
        messageBoxControllerScript = messageBoxPanel.GetComponent<MessageBoxController>();
    }

    void Start () {
        SocketOn();
    }
	
	public void OnClickSignOutButton()
    {
        NetworkManager.Instance.Socket.Emit("SIGNOUT");
    }

    private void SocketOn()
    {
        NetworkManager.Instance.Socket.On("USER_DISCONNECTED", OnUserSignOut);
    }

    private void OnUserSignOut(SocketIOEvent evt)
    {
        //Debug.Log(evt.data);
        Debug.Log(Converter.JsonToString(evt.data.GetField("log").ToString()));
        messageBoxPanel.SetActive(true);
        messageBoxControllerScript.messageText.text = Converter.JsonToString(evt.data.GetField("log").ToString());
        StartCoroutine(WaitMessageSuccessSignOut(1f));
    }

    private IEnumerator WaitMessageSuccessSignOut(float time)
    {
        float count = 0;
        while (count < time)
        {
            count += Time.deltaTime;
            // Debug.Log(Mathf.Floor(count));
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene("signin");
    }
}

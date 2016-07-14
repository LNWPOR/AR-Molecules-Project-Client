using UnityEngine;
using System.Collections;
using SocketIO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LNWPOR : MonoBehaviour {

    public GameObject socketIOPrefab;

	void Start () {
        if (GameObject.Find("SocketIO") == null)
        {
            GameObject socketIOGenerated = Instantiate(socketIOPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
            socketIOGenerated.name = "SocketIO";
        }
        //if (NetworkManager.Instance.count == 0)
        //{
        //    SocketOn();
        //    NetworkManager.Instance.count += 1;
        //}
        
        StartCoroutine(WaitToEmitGetMainEditMoleculeJSON(1f));
    }


    private void SocketOn()
    {
        NetworkManager.Instance.Socket.On("GET_All_mainEditMoleculeJSON", AddMoleculeList);
    }

    private void AddMoleculeList(SocketIOEvent evt)
    {
        Debug.Log("gg");
    }

    private IEnumerator WaitToEmitGetMainEditMoleculeJSON(float time)
    {
        float count = 0;
        while (count < time)
        {
            count += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        NetworkManager.Instance.Socket.Emit("GET_All_mainEditMoleculeJSON");
    }

    public void OnClickRefreshButton()
    {
       SceneManager.LoadScene("LNWPOR");
       //NetworkManager.Instance.Socket.Emit("GET_All_mainEditMoleculeJSON");
    }
}

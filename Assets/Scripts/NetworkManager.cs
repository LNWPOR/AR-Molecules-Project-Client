using UnityEngine;
using System.Collections;
using SocketIO;

public class NetworkManager : MonoBehaviour
{

    private static NetworkManager _instance;
    private SocketIOComponent _socket;

    public static NetworkManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("NetworkManager").AddComponent<NetworkManager>();
            }

            return _instance;
        }
    }

    public SocketIOComponent Socket
    {
        get
        {
            GameObject goSocket = GameObject.Find("SocketIO");
            _socket = goSocket.GetComponent<SocketIOComponent>();
            return _socket;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Socket);
    }

}
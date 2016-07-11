using UnityEngine;
using System.Collections;
using SocketIO;

public class NetworkManager : MonoBehaviour {

	private SocketIOComponent _socket;

	public SocketIOComponent Socket{
		get{
			GameObject goSocket = GameObject.Find("SocketIO");
			_socket = goSocket.GetComponent<SocketIOComponent>();
			return _socket;
		}
	}

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(_socket);
    }

}

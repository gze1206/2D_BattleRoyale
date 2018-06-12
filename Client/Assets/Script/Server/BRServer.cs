using UnityEngine;

public class BRServer : SocketIO.SocketIOComponent
{
    public static BRServer it
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                _instance = go.AddComponent<BRServer>();
                go.name = "[SINGLETON] BRServer";
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }
    private static BRServer _instance;
    public delegate void Callback(bool isSuccess);
}

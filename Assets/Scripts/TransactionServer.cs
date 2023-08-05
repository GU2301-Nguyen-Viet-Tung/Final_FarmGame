using Newtonsoft.Json;
using UnityEngine;
using WebSocketSharp;

public class Message
{
    public string type;
    public string data;
    public string content;
    public int number;
}

public class TransactionServer : ISingleton<TransactionServer>
{
    public bool IsInit { get; private set; } = false;

    private const string SERVER_URL = "ws://localhost";
    private const string SERVER_PORT = "8888";

    private WebSocket m_Websocket;

    public void Init()
    {
        m_Websocket = new WebSocket($"{SERVER_URL}:{SERVER_PORT}");
        m_Websocket.OnMessage += (sender, e) =>
        {
            Debug.Log($"Message from {((WebSocket)sender).Url} , Data = {e.Data}");
            OnMessage(e.Data);
        };
        m_Websocket.OnOpen += (sender, e) =>
        {
            Debug.Log("Websocket open");
            OnOpen();
        };

        m_Websocket.OnClose += (sender, e) =>
        {
            Debug.Log($"Websocket close. Code: {e.Code} - Reason: {e.Reason} - WasClean: {e.WasClean}");
            OnClose();
        };
        m_Websocket.Connect();
    }

    public void SendMessage(Message message)
    {
        string m1 = JsonConvert.SerializeObject(message);
        m_Websocket.Send(m1);
    }

    private void OnMessage(string data)
    {
        Message m = JsonConvert.DeserializeObject<Message>(data);

        Debug.Log("OnMessage type = " + m.type);
        Debug.Log("OnMessage data = " + m.data);
        if (m.type == "connect")
        {
            Message mess = new() { type = "play", data = "Start play on client!" };
            SendMessage(mess);
        }
        else if (m.type == "login")
        {
            if (m.data == "success")
            {
                //login
            }
            else
            {
                // error
            }
        }
    }

    private void OnOpen()
    {
        IsInit = true;
    }

    private void OnClose()
    {

    }

}

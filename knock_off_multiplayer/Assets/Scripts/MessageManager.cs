
// This script maintains a list of listeners
// and the messages that they are interested
// in receiving, it then forwards on any
// messages it receives to the listener
// methods that are interested in that
// particular message


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Message
{

    public GameObject MessageSource { get; set; }
    public string MessageName { get; set; }
    public string MessageValue { get; set; }

    public Message(GameObject s, string n, string v)
    {
        MessageSource = s;
        MessageName = n;
        MessageValue = v;
    }

}

// DEFINE ANY NUMBER OF MESSAGE CLASSES HERE
// as long as they inherit from Message, then
// you can subscribe to them and publish/send them

// we need a listener class that defines who
// is interested in which types of messages

public class Listener
{

    public string nameOfMessageTolistenFor;
    public GameObject receiverObject;
    public string receiverMethodToExecute;

    public Listener(string lf, GameObject fo, string fm)
    {
        nameOfMessageTolistenFor = lf;
        receiverObject = fo;
        receiverMethodToExecute = fm;
    }

}

public class MessageManager
{

    //singleton implementation
    private static MessageManager instance;

    public static MessageManager getInstance()
    {
        if (instance == null)
            instance = new MessageManager();
        return instance;
    }

    private MessageManager()
    {

    }

    private List<Listener> listeners = new List<Listener>();

    public void RegisterListener(Listener l)
    {
        listeners.Add(l);
    }

    // we only ever need access to the base Message
    // class attributes for our forwarding work
    // even if we are sending messages that are objects of
    // subclasses of Message class
    // (we are using polymorphism here)

    public void SendToAllListeners(Message m)
    {
        foreach (var f in listeners.FindAll(l => l.nameOfMessageTolistenFor == m.MessageName))
        {
            if (f.receiverObject != null) f.receiverObject.BroadcastMessage(f.receiverMethodToExecute, m, SendMessageOptions.DontRequireReceiver);
        }
    }

}

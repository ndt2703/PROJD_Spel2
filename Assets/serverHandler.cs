using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using UnityEditor.PackageManager.Requests;

public class serverHandler : MonoBehaviour
{

    Semaphore requestCount = new Semaphore(0,100);

    bool notStopping = true;

    public Queue<Tuple<ClientRequest, Action<ServerResponse>>> queuedRequests = new Queue<Tuple<ClientRequest, Action<ServerResponse>>>();
    public Queue<Tuple<ServerResponse, Action<ServerResponse>>> recievedRespones = new Queue<Tuple<ServerResponse, Action<ServerResponse>>>();

    public ServerResponse SendClientRequest(ClientRequest request)
    {
        return null; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void messageLoop()
    {   
        
        while(notStopping)
        {
            requestCount.WaitOne();
            Tuple<ClientRequest, Action<ServerResponse>> tuple = null;
            lock (queuedRequests)
            {
                tuple = queuedRequests.Dequeue();
            }
            ServerResponse response = SendClientRequest(tuple.Item1);
            lock (recievedRespones)
            {
                recievedRespones.Enqueue(new Tuple<ServerResponse, Action<ServerResponse>>(response, tuple.Item2));
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        lock(recievedRespones)
        {
            if(queuedRequests.Count > 0)
            {
                Tuple<ServerResponse, Action<ServerResponse>> response = recievedRespones.Dequeue();
                response.Item2(response.Item1);
            }
        }
    }

    public void AddRequest(ClientRequest request, Action<ServerResponse> action)
    {
        lock(queuedRequests)
        {
            queuedRequests.Enqueue(new Tuple<ClientRequest, Action<ServerResponse>>(request,action));

            requestCount.Release(); 
        }
    }
}

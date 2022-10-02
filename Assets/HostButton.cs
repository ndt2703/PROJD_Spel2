using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostButton : MonoBehaviour
{
   // public Server server = new Server(); 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HostServer()
    {
        FindObjectOfType<ServerHolder>().StartServer();

        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.TerrainTools;
using UnityEngine.SearchService;

public class Server
{
    System.Net.Sockets.TcpListener m_Listener;
    bool m_Stopping = false;
    public static Int32 ParseBigEndianInteger(byte[] BytesToParse, int ByteOffset)
    {
        Int32 ReturnValue = 0;
        if (BytesToParse.Length < ByteOffset + 4)
        {
            throw new Exception("Unsufficient bytes to parse big endian integer");
        }
        for (int i = 0; i < 4; i++)
        {
            ReturnValue <<= 8;
            ReturnValue += BytesToParse[ByteOffset + i];
        }

        return (ReturnValue);
    }
    public static void WriteBigEndianInteger(byte[] OutArray, uint IntegerToWrite, int BufferOffset)
    {
        for (int i = 0; i < 4; i++)
        {
            OutArray[i + BufferOffset] = (byte)(IntegerToWrite >> (4 * 8 - ((i + 1) * 8)));
        }
    }
    public static MBJson.JSONObject ParseJsonObject(System.IO.Stream Stream)
    {
        MBJson.JSONObject ReturnValue = new MBJson.JSONObject();
        byte[] LengthBuffer = new byte[4];
        int ReadBytes = Stream.Read(LengthBuffer, 0, 4);
        if (ReadBytes < 4)
        {
            throw new Exception("Insufficient bytes to parse JSON object length");
        }
        int DataLength = ParseBigEndianInteger(LengthBuffer, 0);
        byte[] JSONData = new byte[DataLength];
        ReadBytes = Stream.Read(JSONData, 0, DataLength);
        if (ReadBytes < DataLength)
        {
            throw new Exception("Insufficient bytes sent for json object");
        }
        int temp;
        ReturnValue = MBJson.JSONObject.ParseJSONObject(JSONData, 0, out temp);
        return (ReturnValue);
    }

    void p_HandleConnection(object ConnectionToHandle)
    {
        System.Net.Sockets.TcpClient Connection = (System.Net.Sockets.TcpClient)ConnectionToHandle;
        while (Connection.Connected)
        {
            ClientRequest NewRequest = MBJson.JSONObject.DeserializeObject<ClientRequest>(ParseJsonObject(Connection.GetStream()));
            ServerResponse Response = HandleClientRequest(NewRequest);
            byte[] BytesToSend = SerializeJsonObject(MBJson.JSONObject.SerializeObject(Response));
            Connection.GetStream().Write(BytesToSend);
        }
        Connection.Close();
    }
    void p_Listen()
    {
        m_Listener.Start();
        while (!m_Stopping)
        {
            System.Net.Sockets.TcpClient NewConnection = m_Listener.AcceptTcpClient();
            Thread ConnectionThread = new Thread(this.p_HandleConnection);
            ConnectionThread.Start(NewConnection);
        }
    }
    public void StartServer(int Port)
    {
        m_Listener = new System.Net.Sockets.TcpListener(Port);
        Thread ListenerThread = new Thread(this.p_Listen);
        ListenerThread.Start();


    }


    public static byte[] SerializeJsonObject(MBJson.JSONObject ObjectToSerialize)
    {
        string ObjectString = ObjectToSerialize.ToString();
        byte[] ObjectBytes = System.Text.UTF8Encoding.UTF8.GetBytes(ObjectString);
        byte[] ReturnValue = new byte[ObjectBytes.Length + 4];
        WriteBigEndianInteger(ReturnValue, (uint)ObjectBytes.Length, 0);
        ObjectBytes.CopyTo(ReturnValue, 4);
        return (ReturnValue);
    }
    
    public ServerResponse HandleClientRequest(ClientRequest requestToHandle)
    {
        ServerResponse response = new ServerResponse();

        response.whichPlayer = requestToHandle.whichPlayer;

 

        return response;
    }
    ~Server()
    {
        m_Stopping = true;
    }



}
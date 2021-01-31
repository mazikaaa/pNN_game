using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//シリアルで受け取ったデータを処理するプログラム
public class ReceiveManager : MonoBehaviour
{ 
    public SerialHandler serialHandler;

    public GameObject pNNChecker;


  void Start()
    {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void Update()
    {
       
    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        //Debug.Log(message);
        var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
        //if (data.Length < 2) return;


        try
        {
            //「B」から始まっていた場合、BPMとしてデータを溜める
            if (data[0].Substring(0, 1) == "B")
            {
                pNNChecker.GetComponent<pNNManager>().BPMStacker(data[0]);
            }
            //「Q」から始まっていた場合，RRIとしてデータを溜める
            if (data[0].Substring(0, 1) == "Q")
            {
                pNNChecker.GetComponent<pNNManager>().IBIStacker(data[0]);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}

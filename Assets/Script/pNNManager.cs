using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//pNN50の値を計測するプログラム
public class pNNManager : MonoBehaviour
{
    GameObject gamemanager;
    GameManager game;

    int BPM = 0;
    int BPM_prev = 0;

    int IBI = 0;
    int IBI_prev = 0;

    int pNN_n,pNN_C=0,pNN_aver;
    float pNN_result;

    int datalist=0;
    int checker = 0;

    public int[] BPM_data= new int[31];
    public int[] IBI_data=new int[31];
    public int[] pNN_data = new int[30];


    int BPMstack = 0;
    int IBIstack = 0;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        game = gamemanager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //BPM != 0 
        if ( IBI != 0)
        {
            //BPM == BPM_prev 
            if (IBI == IBI_prev) checker = 1;
            if (checker != 1)
            {
                //&& BPM_prev != 0
                if (IBI_prev != 0 )
                {
                    pNN_n = IBI - IBI_prev;
                    if (pNN_n * pNN_n >= 2500)
                    {
                        pNN_data[pNN_C] = 1;
                        //pNN_checker++;
                    }
                    else
                    {
                        pNN_data[pNN_C] = 0;
                    }
                    pNN_C++;

                    if (pNN_C == 30)
                    {
                        datalist = 1;
                        pNN_C = 0;
                    }
                    if (datalist == 1)
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            pNN_aver = pNN_aver+ pNN_data[i];
                        }
                        pNN_result = (float)pNN_aver / 30.0f;

                        game.ShowpNN(pNN_result);
                        pNN_aver = 0;

                    }
                }
                IBI_prev = IBI;
                //BPM_prev = BPM;
            }
            checker = 0;
        }
    }

    //BPMの値を溜める関数(今回は使用していない)
    public void BPMStacker(string data)
    {
        string text = data.Remove(0, 1);
        int num = int.Parse(text);

        BPM = num;

        BPM_data[BPMstack] = num;
        BPMstack++;
        if (BPMstack > 30)
            BPMstack = 0;
    }
    
    
    //RRIの値を溜める関数
    public void IBIStacker(string data)
    {
        string text = data.Remove(0, 1);
        int num = int.Parse(text);

        IBI = num;

        IBI_data[IBIstack] = num;
        IBIstack++;

        if (IBIstack > 30)
            IBIstack = 0;
    }
}

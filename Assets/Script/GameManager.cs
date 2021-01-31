using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//制限時間の管理や取ったコインの管理などゲーム全体の処理を管理
public class GameManager : MonoBehaviour
{
    public Text time_text, coin_text,pNN_text,status_text;

    int sum=0,num=0;

    float time;

    Animator emergency;
    AudioSource audiosource;

    public List<Transform> coinpos = new List<Transform>();
    List<Transform> sub_coinpos;

    public GameObject redRamp,coin,player;
    public AudioClip coin_SE;

    public float gameover;

    UnityChan.UnityChanControlScriptWithRgidBody unitychan;

    // Start is called before the first frame update
    void Start()
    {
        emergency = redRamp.GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        sub_coinpos = new List<Transform>(coinpos);
        unitychan = player.GetComponent<UnityChan.UnityChanControlScriptWithRgidBody>();
        GenerateCoin();
    }
    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        time_text.text = "Time:" + (gameover - time).ToString("f5");

        if (time>gameover)
        {
            GameOver();
        }
    }

    //pNNの値によって画面の表示，プレイヤーの移動速度を変える
    public void ShowpNN(float pNN)
    {
        pNN_text.text = pNN.ToString("f7");

        if (pNN < 0.2)
        {
            status_text.color = new Vector4(1.0f,0.0f,0.0f,1.0f);
            status_text.text="とてもピンチ";
            unitychan.forwardSpeed = 12.0f;
            unitychan.backwardSpeed = 6.0f;
            unitychan.rotateSpeed =3.5f;
            
        }
        else if (pNN < 0.4)
        {
            status_text.color = new Vector4(1.0f, 0.3f, 0.0f, 1.0f);
            status_text.text = "ピンチ";
            unitychan.forwardSpeed = 9.0f;
            unitychan.backwardSpeed = 5.0f;
            unitychan.rotateSpeed = 3.0f;
        }
        else if (pNN < 0.7)
        {
            status_text.color = new Vector4(1.0f, 0.8f, 0.0f, 1.0f);
            status_text.text = "平常";
            unitychan.forwardSpeed = 7.0f;
            unitychan.backwardSpeed = 4.0f;
            unitychan.rotateSpeed = 2.5f;
        }
        else
        {
            status_text.color = new Vector4(0.2f, 1.0f, 0.0f, 1.0f);
            status_text.text = "リラックス";
            unitychan.forwardSpeed = 6.0f;
            unitychan.backwardSpeed = 3.5f;
            unitychan.rotateSpeed = 2.5f;
        }
    }

    //プレイヤーをロボットが追いかけている時，赤い点灯と警告音を鳴らして危機感を煽る
    public void SetEmergency(bool flag)
    {
        emergency.SetBool("Rush", flag);

        if (flag)
        {
            audiosource.Play();
        }
        else
        {
            audiosource.Stop();
        }
    }

    //コインを取った時にスコアに加算する
    public void GetCoin()
    {
        sum +=1;
        coin_text.text ="coin:" + sum.ToString();
        audiosource.PlayOneShot(coin_SE);

        num -= 1;
        if (num<=2)
        {
            GenerateCoin();
        }
    }

    //コインが少なくなったときに新たにコインを生成する
    private void GenerateCoin()
    {
        if(sub_coinpos.Count<=4)
        sub_coinpos = new List<Transform>(coinpos);

        for (; num < 5; num++)
        {
            int rand = Random.Range(0, sub_coinpos.Count);
            GameObject co= Instantiate(coin, new Vector3(sub_coinpos[rand].transform.position.x, sub_coinpos[rand].transform.position.y, sub_coinpos[rand].transform.position.z), Quaternion.identity);
            co.GetComponent<CoinColider>().gamemanager = GetComponent<GameManager>();
            sub_coinpos.RemoveAt(rand);
        }
    }

    //ゲームオーバー処理
    public void GameOver()
    {
        PlayerPrefs.SetInt("Coin", sum);
        SceneManager.LoadScene("ResultScene");
    }
}

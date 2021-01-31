using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//ロボットを動かすプログラム
//ロボットの巡回する道はNav Mesh Agentという機能で自動で決めています
public class RobotController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public GameObject player,gamemanager;
    [SerializeField] Transform destination;

    public Transform[] despos = new Transform[9];
    int randompos;
    [SerializeField]bool chaseflag = false,repairfalg=false;
    public float speed;

    float distance,dashtime,repairtime;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        SetDestination();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //オーバーヒートして止まっている時に，時間経過で再び動くようにする
        if (repairfalg)
        {
            repairtime += Time.deltaTime;
            if (repairtime > 5.0f)
            {
                SetDestination();
                repairfalg = false;
            }
        }
        else
        {
            //プレイヤーを追いかけている時
            if (chaseflag)
            {
                agent.SetDestination(player.transform.position);
                dashtime += Time.deltaTime;
            }
            //それ以外の時
            else
                agent.SetDestination(destination.position);

            //プレイヤーとロボットの距離を計測
            distance = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
            if (distance < 20.0f && !chaseflag)
            {
                gamemanager.GetComponent<GameManager>().SetEmergency(true);
                ChaseMode();
            }
            //追いかける状態の解除
            else if (distance >= 20.0f && chaseflag)
            {
                agent.speed -= 2.0f;
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
                SetDestination();
                dashtime = 0.0f;
                chaseflag = false;
                gamemanager.GetComponent<GameManager>().SetEmergency(false);
            }

            //現在の目的に近づいたら次の目的地点を決める
            if (agent.remainingDistance < 2.0f && !chaseflag)
                SetDestination();

            //一定時間、プレイヤーを追いかけ続けたら止まる
            if (dashtime > 20.0f)
            {
                OverHeat();
                gamemanager.GetComponent<GameManager>().SetEmergency(false);
            }
        }

    }

    //ロボットの次の目的地を決める
    private void SetDestination()
    {
        randompos = Random.Range(0, 9);
        agent.speed = speed;

        destination = despos[randompos];
        anim.SetBool("Walk", true);
    }

    //プレイヤーを追いかける状態に移行する関数
    private void ChaseMode()
    {
        agent.speed += 2.0f;
        anim.SetBool("Run", true);
        anim.SetBool("Walk", false);
        chaseflag = true;
    }

    //プレイヤーを追いかけ続けたら，オーバーヒートして一定時間止まるようにする関数
    private void OverHeat()
    {
        agent.speed -= 2.0f;
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        dashtime = 0.0f;
        chaseflag = false;
        repairfalg = true;
        agent.speed = 0;
    }

    //当たり判定に入ったら発動する関数
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gamemanager.GetComponent<GameManager>().GameOver();
        }
    }
}

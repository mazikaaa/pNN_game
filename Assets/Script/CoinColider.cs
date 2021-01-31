using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//コインの当たり判定に関する関数
public class CoinColider : MonoBehaviour
{
    public GameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たり判定にプレイヤーが入ったら，コインを回収する
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gamemanager.GetCoin();
            Destroy(this.gameObject);
        }
    }
}

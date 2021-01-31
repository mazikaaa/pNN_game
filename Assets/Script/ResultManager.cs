using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    int coin;
    public Text result_text;

    // Start is called before the first frame update
    void Start()
    {
        coin = PlayerPrefs.GetInt("Coin",0);
        result_text.text = coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

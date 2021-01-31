using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1600, 900, false, 60);
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

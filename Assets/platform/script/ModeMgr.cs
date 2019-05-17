using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeMgr : MonoBehaviour
{

    // public GameObject _Mode;

    void Awake()
    {
    }

    public void InEasyGame()
    {
        AllManager.Instance.MODE = 0;
        SceneManager.LoadScene("HowMany");
    }


    public void InHardGame()
    {
        AllManager.Instance.MODE = 1; //싱글턴 찾아보기
        SceneManager.LoadScene("HowMany");
    }

    

 

}

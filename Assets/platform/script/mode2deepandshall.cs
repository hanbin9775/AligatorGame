using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mode2deepandshall : MonoBehaviour
{

    // public GameObject _Mode;

       public void Scene2Hard()
    {
        AllManager.Instance.MODE = 1; // hard모드 누른 것 기억
        SceneManager.LoadScene("HowMany"); // 설정창으로 이동
       
    }

    public void Scene2Easydemo()
    {
        AllManager.Instance.MODE = 0;
        SceneManager.LoadScene("HowMany");
        
    }

    

}

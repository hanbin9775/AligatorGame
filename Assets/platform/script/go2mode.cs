using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go2mode : MonoBehaviour
{

    void Awake()
    {
    }

    public void SceneMode()
    {
        Invoke("scenemode", .5f);
    }

    void scenemode()
    {
        SceneManager.LoadScene("SceneMode");

    }


}

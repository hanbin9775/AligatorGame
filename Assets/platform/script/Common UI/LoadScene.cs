using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    string mSceneName;

    public void OnLoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mSceneName);

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyGameMgr : MonoBehaviour
{
    public void InAligatorGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void InAlphabetGame()
    {
        SceneManager.LoadScene("Alphabet");

    }

    public void Back()
    {
        SceneManager.LoadScene("HowMany");

    }
}

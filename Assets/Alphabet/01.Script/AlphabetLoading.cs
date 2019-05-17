using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetLoading : MonoBehaviour
{

    // 로딩 시간
    private float _fTime = 0f;
    private float _fLoadingTime = 0.2f;
    private float _fLoadingStartTime = 1.5f;

    public GameObject Voca = null;
    public GameObject Intro = null;

    private bool _IsRotate = true;
    private bool bEnd = false;
    private Color myColor;

    public GameObject[] gameobj = new GameObject[7];
    public GameObject InGame = null;
    public GameObject OutGame = null;

    private void Start()
    {
            StartCoroutine("Load");
    }

    private void FixedUpdate()
    {
        if (bEnd)
        {
            foreach (GameObject go in gameobj)
            {
                myColor = go.GetComponent<Image>().color;
                myColor.a -= Time.deltaTime * 0.5f;
                go.GetComponent<Image>().color = myColor;
                if (myColor.a <= 0f)
                {
                    go.SetActive(false);

                }

            }

            if (myColor.a <= 0f)
            {
                InGame.SetActive(true);
                OutGame.SetActive(false);
            }
        }
    }

    IEnumerator Load()
    {
            yield return new WaitForSeconds(1.5f);
        Voca.SetActive(true);
        Intro.SetActive(true);
        bEnd = true;
            yield return new WaitForSeconds(2f);
    }






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager aligatorinstance;
    
    //Component 
    Animator anim;

    //Teeth
    public Transform [] toothtrans;
    public GameObject[] tooth;
    public GameObject toothprefab;
    private int rottentoothindex;

    //Ending
    public GameObject Ending;
    private bool mbIsGameEnd = false;
    void InstantiateTooth()
    {
        for(int i=0; i<tooth.Length; i++)
        {
            tooth[i] = Instantiate(toothprefab, toothtrans[i].position,toothtrans[i].rotation);
        }
    }


    void MakeRottenTooth()
    {
        rottentoothindex = Random.Range(0, toothtrans.Length);
    }

    private void Awake()
    {
        aligatorinstance = this;
        anim = GetComponent<Animator>();
    }

    public void MakeTeethFalse()
    {
        for (int i = 0; i < toothtrans.Length; i++)
        {
            tooth[rottentoothindex].GetComponent<ToothClick>().isclicked = false;
            Destroy(tooth[i],0.3f);
        }
    }

    public void MakeTeethTrue()
    {
        mbIsGameEnd = false;
        InstantiateTooth();
        MakeRottenTooth();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < toothtrans.Length; i++)
        {
           // Debug.Log(rottentoothindex);
            if (tooth[i])
            {
                if (tooth[rottentoothindex].GetComponent<ToothClick>().isclicked == true
                    && !mbIsGameEnd)
                {
                    mbIsGameEnd = true;
                    StartCoroutine(ShowEnding());
                    Debug.Log("rotten clicked");
                    anim.SetTrigger("IsRotten");
                    MakeTeethFalse();
                    break;
                }
            }
        }
      
    }

    IEnumerator ShowEnding()
    {
        yield return new WaitForSeconds(1f);
        GameObject endinginstance = Instantiate(Ending);
        Destroy(endinginstance, 5.0f);
    }

}

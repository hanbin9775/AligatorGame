using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AligatorInstantiator : MonoBehaviour
{
    public GameObject[] Aligator;

    private GameObject instance;

    private int _iPlayerNum;
    
    private void Awake()
    {
        StartCoroutine(InstantiateAligator());
    }

    IEnumerator InstantiateAligator()
    {
        yield return new WaitForSeconds(1.0f);
        _iPlayerNum = BasicDataManager.LoadPlayerCount();
        Debug.Log("현재 인원 : " + _iPlayerNum);
        switch (_iPlayerNum)
        {
            case 2:
            case 3:
                instance = Instantiate(Aligator[0]);
                break;
            case 4:
                instance = Instantiate(Aligator[1]);
                break;
            case 5:
                instance = Instantiate(Aligator[2]);
                break;
            case 6:
                instance = Instantiate(Aligator[3]);
                break;
            case 7:
            case 8:
                instance = Instantiate(Aligator[4]);
                break;
        }
    }
    
    public void DestroyandInstantiateAligator()
    {
        //destroy
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            if (GameObjects[i].tag == "Aligator")
                Destroy(GameObjects[i]);
        }

        //instantiate
        _iPlayerNum = BasicDataManager.LoadPlayerCount();
        Debug.Log("현재 인원 : " + _iPlayerNum);
        switch (_iPlayerNum)
        {
            case 2:
            case 3:
                instance = Instantiate(Aligator[0]);
                break;
            case 4:
                instance = Instantiate(Aligator[1]);
                break;
            case 5:
                instance = Instantiate(Aligator[2]);
                break;
            case 6:
                instance = Instantiate(Aligator[3]);
                break;
            case 7:
            case 8:
                instance = Instantiate(Aligator[4]);
                break;
        }
    }

}

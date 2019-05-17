using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsefulMgr : MonoBehaviour
{
    // 이 프리팹은 모든씬에서 공통으로 사용될 것들을 모아 프리팹화 시켜둔 오브젝트 이다.
    // 다만.. 이것이 과연 실효성이 있을지는 의문.... 일단은 만들어만 뒀다...
    // 오직 악어게임에서만 실제로 사용됨
    // 추후 회의를 거쳐 결정하기로...

    public void Back(string str)
    {
        SceneManager.LoadScene(str);
    }
}

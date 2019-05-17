using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AllManager : MonoBehaviour
{
   /* public enum GAME_MODE
    {
        MODE_NOMRAL,
        MODE_HARD
    } */

    // 모두 종류
    [SerializeField] // 인스펙터창이 최우선
    private int _MODE = 0; 
    public int MODE { get { return _MODE; } set { _MODE = value; } }  // int 말고 enum타입
    //외부에서 접근 할수 있도록

    // 플레이어 수. 최초는 2
    [SerializeField] // 프라이빗변수가 인스펙터 창에 나옴
    private int _iPlayerNum = 2;
    public int PlayerNum { get { return _iPlayerNum; }  set { _iPlayerNum = value; } }

    //싱글터어어어언(오직 이거 하나만)~~ 이게 하나밖에 없다
    private static AllManager _instance = null;
    public static AllManager Instance { get { return _instance; } }

    public void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        } 

        _instance = this; //이 클래스의 주소값을 넘겨줌
        _iPlayerNum = 2;
            DontDestroyOnLoad(this.gameObject); // 씬이 달라져도 없어지지 않도록 한다!
    }
}

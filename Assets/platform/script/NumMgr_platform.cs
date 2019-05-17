using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumMgr_platform : MonoBehaviour
{

    //  플레이어 최대 최소수
    [SerializeField]
    private int MAX_PLAYER = 8;
    [SerializeField]
    private int MIN_PLAYER = 2;

    // 플레이어수 증가감소 버튼
    public Image UP;
    public Image DOWN;
    public Image MODE;

    // 증가감소 이미지
    [SerializeField]
    private Sprite[] _UpDownImg = new Sprite[2];

    // 플레이어 숫자 표시
    [SerializeField]
    private Image _HowManyPlayer = null; //사람수
    [SerializeField]
    private Sprite[] HowManyPlayerImg = new Sprite[7]; //이미지

    // 플레이어 수.. 사실 이것 안쓰고 AllManager.Instance.PlayerNum 를 쓰는게 더 간단하지만... 일단은...
    [SerializeField]
    private int _iPlayerNum = 2;


    // 모드 이미지
    [SerializeField]
    private Sprite[] _modeImg = new Sprite[2];

    /// <summary>
    /// 현재 PlayerNum과 저장되었던 PlayerNum이 바뀌었는지 체크.
    /// </summary>
    [SerializeField]
    private bool mbPlayerNumChange = false;

    [SerializeField]
    GameReStart mGameReStart;

    private void Start()
    {
        // 인원수 넣어준다.
        //_iPlayerNum = AllManager.Instance.PlayerNum;
        _iPlayerNum = BasicDataManager.LoadPlayerCount();

        Debug.Log(_iPlayerNum);

        /* if (AllManager.Instance.MODE == 0) // 얕은밤모드표시
        {
            MODE.sprite = _modeImg[0];
        }

        else if (AllManager.Instance.MODE == 1)  // 깊은밤모드표시
        {
            MODE.sprite = _modeImg[1];

        }
        */

        // 처음시작할때 인원수를 가리키는 숫자로 바꿔준다.
        _HowManyPlayer.sprite = HowManyPlayerImg[_iPlayerNum - 2];
        //인원 수에 따라(MIN,MAX) 비활성화 버튼 이미지 교체
        if (_iPlayerNum == MIN_PLAYER)
        {
            DOWN.sprite = _UpDownImg[1];
        }
        else if (_iPlayerNum == MAX_PLAYER)
        {
            UP.sprite = _UpDownImg[0];
        }

    }


    public void PlayerUp()  // 플레이어 증가버튼 눌렀을때
    {
        if (_iPlayerNum < MAX_PLAYER)
        {
            if (_iPlayerNum == MAX_PLAYER - 1)
            {
                UP.sprite = _UpDownImg[1];
            }
            else if (_iPlayerNum == MIN_PLAYER)
            {
                DOWN.sprite = _UpDownImg[0];
            }
            _iPlayerNum++;
            //AllManager.Instance.PlayerNum++;
            _HowManyPlayer.sprite = HowManyPlayerImg[_iPlayerNum - 2];
        }

    }

    public void PlayerDown()   // 플레이어 감소버튼 눌렀을때
    {

        if (_iPlayerNum > MIN_PLAYER)
        {
            if (_iPlayerNum == MIN_PLAYER + 1)
            {
                DOWN.sprite = _UpDownImg[1];
            }
            else if (_iPlayerNum == MAX_PLAYER)
            {
                // DOWN.sprite = _UpDownImg[1]; // 이부분 이상(up down)  다시 해보기 
                UP.sprite = _UpDownImg[0];
            }
            _iPlayerNum--;
            //AllManager.Instance.PlayerNum--;
            _HowManyPlayer.sprite = HowManyPlayerImg[_iPlayerNum - 2];
        }

    }

    public void SelectPlayerNum()   //확인버튼  눌렀을때
    {
        //AllManager.Instance.PlayerNum = _iPlayerNum;
        if (AllManager.Instance.MODE == 0) // 얕은밤
        {
            SceneManager.LoadScene("EasyGameDemo");
        }
        else if (AllManager.Instance.MODE == 1)  // 깊은밤
        {
            SceneManager.LoadScene("HardGame");

        }
    }

    public void Back()  // 뒤로가기
    {
        SceneManager.LoadScene("newSceneMode");
    }

    /// <summary>
    /// 변경한 PlayerNum과 저장되어있던 PlayerNum을 비교후 저장한다.
    /// </summary>
    public void SavePlayerNum()
    {
        mbPlayerNumChange = BasicDataManager.LoadPlayerCount() != _iPlayerNum;
        BasicDataManager.SavePlayerCount(_iPlayerNum);
    }
    /// <summary>
    /// Startings the game.
    /// </summary>
    public void StartingGame()
    {
        if (mbPlayerNumChange) mGameReStart.ReStart();

    }

}


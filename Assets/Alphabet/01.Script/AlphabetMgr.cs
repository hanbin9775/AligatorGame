using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlphabetMgr : MonoBehaviour
{

    //게임 모드
    public enum MODE
    {
        MODE_NORMAL,
        MODE_HARD
    }
    private MODE _gameMode = 0;

    public enum GAME_STATE
    {
        GAME_READY,
        GAME_PLAY,
        GAME_IDLE
    }

    //게임 진행중인가?
    private GAME_STATE _GameState = GAME_STATE.GAME_READY;

    // 플레이어 수
    private int _iPlayer = 0;
    // 버튼을 누른 플레이어 수
    private int _iPlyaerCnt = 0;

    // 나가기 버튼
    [SerializeField]
    private GameObject _Back = null;

    //모드선택버튼
    [SerializeField]
    private GameObject _ModeBtn = null;
    [SerializeField]
    private Sprite[] _ModeImg = new Sprite[2];

    // 시작버튼 
    [SerializeField]
    private GameObject _StartButton = null;
    //시작버튼 이미지
    [SerializeField]
    private Sprite[] _StartImg = new Sprite[2];

    // 플레이어 버튼
    [SerializeField]
    private GameObject _Players = null;
    //터치버튼 이미지
    [SerializeField]
    private Sprite[] _TouchImg = new Sprite[2];

    // 배경화면 -> 벌칙자가 걸렸을때 색을 변경하기 위해
    [SerializeField]
    private GameObject _BackGround = null;
    // 배경화면 리소스
    [SerializeField]
    private Sprite[] _BackGroundImg = null;

    //랜덤 단어
    private string[] _Problem = new string[19] { "ㄱ", "ㄲ", "ㄴ", "ㄷ", "ㄸ", "ㄹ",
        "ㅁ", "ㅂ", "ㅃ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅉ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ",  };


    //졌을때 흔들리는 효과
    private int inum = 1;

    private void Awake()
    {
        _BackGround.GetComponent<Image>().sprite = _BackGroundImg[0];
        _GameState = GAME_STATE.GAME_READY;

       
        
    }

    private void Start()
    {
        //여기서 인원수를 받아오기!!
        _iPlayer = AllManager.Instance.PlayerNum;
        //한명은 벌칙이 되어야 하니깐 뺴준다.
        _iPlayer--;

        // 초기설정으로 8명으로 해준다. 추후 플랫폼 개발이 완료되면 수정한다.
        for (_iPlyaerCnt = 0; _iPlyaerCnt < _iPlayer; _iPlyaerCnt++)
        {
            _Players.transform.GetChild(_iPlyaerCnt).gameObject.SetActive(true);
        }
    }

    public void OnClickBack() // 뒤로가기 눌렀을 경우
    {
        //// 이전 씬으로 이동하기! 이름 넣어주기!
        SceneManager.LoadScene("EasyGame");
    }

    public void OnClickStart() // 초성 시작 눌렀을 경우
    {
        if (_GameState == GAME_STATE.GAME_READY)
        {
            //버튼 바꿔주기
            _StartButton.GetComponent<Image>().sprite = _StartImg[1];

            // 뒤로가기 모드 없애주기
            _Back.SetActive(false);
            _ModeBtn.SetActive(false);

            _GameState = GAME_STATE.GAME_PLAY;
            RandomProblem();
        }
    }

    public void OnClickPlayer() // 플레이어 터치버튼 눌렀을 경우
    {
        if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>() != _TouchImg[1] && _GameState == GAME_STATE.GAME_PLAY ) // 플레이어 온 일때만 하여라.
        {
            //누르면 플레이어 버튼 off 됨
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = _TouchImg[1];
            _iPlyaerCnt--;

            if (_iPlyaerCnt == 0) // 벌칙 걸렸을때.
            {
                _GameState = GAME_STATE.GAME_IDLE; //게임 종료                
                _StartButton.transform.GetChild(0).GetComponent<Text>().text = "벌칙 당첨!";
                StartCoroutine("ReStart");
                StartCoroutine("Lose");
                _BackGround.GetComponent<Image>().sprite = _BackGroundImg[1];

            }
            else // 일반적으로 눌렀을 경우
            {
                if(_gameMode == MODE.MODE_HARD)
                {
                    RandomProblem();
                }
            }
        }
    }


    public void ModeChange()
    {
        if (_gameMode == MODE.MODE_NORMAL)
        {
            _gameMode = MODE.MODE_HARD;
            _ModeBtn.GetComponent<Image>().sprite = _ModeImg[1];
        }
        else if (_gameMode == MODE.MODE_HARD)
        {
            _gameMode = MODE.MODE_NORMAL;
            _ModeBtn.GetComponent<Image>().sprite = _ModeImg[0];
        }
    }

    IEnumerator ReStart()
    {
        yield return new WaitForSeconds(2f);
        // 뒤로가기 랑 모드 보여 주기
        _GameState = GAME_STATE.GAME_READY;

        //배경화면 다시 정상처리
        _BackGround.GetComponent<Image>().sprite = _BackGroundImg[0];
        //버튼 바꿔주기
        _StartButton.GetComponent<Image>().sprite = _StartImg[0];

        //글자 없애주기
        _StartButton.transform.GetChild(0).GetComponent<Text>().text = "";

        // 플레이어 버튼 다시 켜주기

        for (_iPlyaerCnt = 0; _iPlyaerCnt < _iPlayer; _iPlyaerCnt++)
        {
            _Players.transform.GetChild(_iPlyaerCnt).gameObject.GetComponent<Image>().sprite = _TouchImg[0];
        }

        _Back.SetActive(true);
        _ModeBtn.SetActive(true);
    }

    private void RandomProblem()
    {
        // 랜덤으로 나올 문제들을 정해주는 과정
        _StartButton.transform.GetChild(0).GetComponent<Text>().text = _Problem[Random.Range(0, _Problem.Length)];
        _StartButton.transform.GetChild(0).GetComponent<Text>().text += _Problem[Random.Range(0, _Problem.Length)];
    }

    IEnumerator Lose()
    {
        while(_GameState == GAME_STATE.GAME_IDLE)
        {
            Vector3 vPos;
            yield return new WaitForSeconds(0.2f);
            for (_iPlyaerCnt = 0; _iPlyaerCnt < _iPlayer; _iPlyaerCnt++)
            {
                vPos = _Players.transform.GetChild(_iPlyaerCnt).gameObject.transform.position;
                vPos.x += 10 * inum;
                 _Players.transform.GetChild(_iPlyaerCnt).gameObject.transform.position = vPos;
            }
            vPos = _StartButton.transform.position;
            vPos.x -= 10 * inum;
            _StartButton.transform.position = vPos;
            inum *= -1;

        }
    }

}

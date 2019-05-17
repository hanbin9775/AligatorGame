using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowContorol : MonoBehaviour
{
    public void OnPause()
    {
        Time.timeScale = 0f; // timesclae 이 게임 시간 그래서 뒤의 바탕 화면이 일시 정지

    }
    public void OnPlay()
    {
        Time.timeScale = 1f;
    }
}

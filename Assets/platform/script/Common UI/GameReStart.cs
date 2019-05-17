using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameReStart : MonoBehaviour
{
    /// <summary>
    /// ReStart시 호출 될 함수를 listener에 추가해 주세여.
    /// </summary>
    public Button.ButtonClickedEvent OnReStart;
    /// <summary>
    /// listener에 담긴 함수들을 호출 한다.
    /// </summary>
    public void ReStart()
    {
            OnReStart.Invoke();
    }
}

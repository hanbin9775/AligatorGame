using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 간단한 로컬 저장 데이터를 Save/Load하는 static class
/// </summary>
public static class BasicDataManager
{
    /// <summary>
    /// 사운드 플레이 On/Off에 대한 데이터를 불러온다.
    /// T== On, F==Off
    /// </summary>
    /// <returns><c>true</c>, if is sound on was loaded, <c>false</c> otherwise.</returns>
    public static bool LoadIsSoundOn()
    {
        return PlayerPrefs.GetInt("SoundKey", 1) == 1 ? true : false; 
    }
    /// <summary>
    /// 사운드 플레이 On/Off에 대한 데이터를 저장한다.
    /// </summary>
    /// <param name="bSoundOn">If set to <c>true</c> b sound on.</param>
    public static void SaveIsSoundOn(bool bSoundOn)
    {
        PlayerPrefs.SetInt("SoundKey", bSoundOn?1:0);
    }
    /// <summary>
    /// 플레이어수를 불러온다.
    /// </summary>
    /// <returns>The player count.</returns>
    public static int LoadPlayerCount()
    {
        return PlayerPrefs.GetInt("PlayerKey", 5);
    }
    /// <summary>
    /// 플레이어수를 저장한다.
    /// </summary>
    /// <param name="playerCount">Player count.</param>
    public static void SavePlayerCount(int playerCount)
    {
         PlayerPrefs.SetInt("PlayerKey", playerCount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] mAudioSources;
    [SerializeField]
    private Button mSoundOF;
    [SerializeField]
    private Image mSoundIcon;

    [SerializeField]
    private Sprite mOnSprite, mOffSprite;

    private void Awake()
    {
        //버튼에 액션 추가
        mSoundOF.onClick.AddListener(() => {
            //저장된 soundOnOFF 데이터 가져와 Reverse 하고, 그 결과에 따라 sound을 On/Off하고 값을 다시 저장한다.
            bool bSoundOF = !BasicDataManager.LoadIsSoundOn();
            if (bSoundOF)
            {
                foreach(var audio in mAudioSources) // 리스트 안에 있는 것들 (SOUND 0-N개 각각)을  순차적으로 불러옴. 
                {
                    if (!audio.isPlaying)
                    {
                        //해당 오디오 클립을 처음 부터 재생 하기 위함.
                        AudioClip clip = audio.clip;
                        audio.clip = null; // 끊긴 지점부터 나와서 처음부터 들리게 
                        audio.clip = clip;
                        audio.Play();  
                    }
                }
                mSoundIcon.sprite = mOnSprite;
            }
            else
            {
                foreach (var audio in mAudioSources)
                {
                    if (audio.isPlaying) audio.Stop();
                }
                mSoundIcon.sprite = mOffSprite;
            }

            BasicDataManager.SaveIsSoundOn(bSoundOF); // BDM, 안의 함수 다 static이여서 가능

        });


        /// 씬 시작시 저장된 상태를 불러와 적용한다.
        if (BasicDataManager.LoadIsSoundOn())
        {
            Debug.Log("On"); 
            foreach (var audio in mAudioSources)
            {
                if (!audio.isPlaying) audio.Play();
            }
            mSoundIcon.sprite = mOnSprite;

        }
        else
        {

            foreach (var audio in mAudioSources)
            {
                if (audio.isPlaying)
                {
                    audio.Stop();
                }
            }
            mSoundIcon.sprite = mOffSprite;

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeinout : MonoBehaviour
{
    [SerializeField]
    private AudioSource mAudioSources;

    public GameObject todisappear = null; // 다 끝나고 사라질것
   // public GameObject toappear = null; // 다 끝나고 나타날것

    public UnityEngine.UI.Image fade_image1;
    public UnityEngine.UI.Image fade_image2;
    public UnityEngine.UI.Image fade_image3;
    public UnityEngine.UI.Text fade_Text1;
    public UnityEngine.UI.Text fade_Text2;
    float fades = 0.0f;//알파값 255 의미 =1
    float time = 0;
    private bool End = false;


    private void Start()
    {
        StartCoroutine("Load");
    }


    private void Update()
    {
        if (End)
        {

            time += Time.deltaTime;
            if ((fades < 1) && (time >= 0.1f))
            {
                fades += 0.025f;
                fade_image1.color = new Color(1, 1, 1, fades);
                fade_image2.color = new Color(1, 1, 1, fades);
                fade_image3.color = new Color(1, 1, 1, fades);
                fade_Text1.color = new Color(1, 1, 1, fades);
                fade_Text2.color = new Color(1, 1, 1, fades);


            }
            else if (fades >= 1)
            {
                todisappear.SetActive(false);
                //toappear.SetActive(true);
                //다음씬으로 넘어가거나 다음 행동할 것
                time = 0;
            }
        }

    }


    IEnumerator Load()
    {
        yield return new WaitForSeconds(5f); // 처음 씬 보이는 시간
        todisappear.SetActive(true);
        //toappear.SetActive(false);
        AudioSource audio = mAudioSources;
        audio.Play();
        End = true;
        yield return new WaitForSeconds(1f);
    }


}




/* fade out
 *  time += Time.deltaTime;
        if ((fades < 1.0f) && (time >= 0.1f)) // IN 은 fades > 0.0f
        {
            fades += 0.1f; // IN은 fades -= 0.1f
            fade.color = new Color(0, 0, 0, fades);
            time = 0;

        } 
        else if (fades >= 1.0f) // IN 은 fades <= 0.0f
        {
            //다음씬으로 넘어가거나 다음 행동할 것
            time = 0;
        }
        */



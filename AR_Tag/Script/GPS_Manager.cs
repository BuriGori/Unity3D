using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class gps : MonoBehaviour
{
    public Text[] data = new Text[4];
    public float delay;
    public float maxtime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Gps_manger());
    }
    IEnumerator Gps_manger()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))//위치정보에 대한 개인정보수집을 허용했는지 확인
        {
            Permission.RequestUserPermission(Permission.FineLocation);//위치정보를 받는 팝업을 띄우는 함수.
            while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                yield return null;
            }
        }
        if (Input.location.isEnabledByUser)//gps가 꺼져있는 경우
        {
            data[3].text = "GPS off";
        }

        Input.location.Start();//데이터를 가져오겠다 라는 함수.

        while(Input.location.status == LocationServiceStatus.Initializing && delay < maxtime)//딜레이 타임을 계산하여 maxtime까지 기다린다.
        {
            yield return new WaitForSeconds(1.0f);
            delay++;
        }

        if(Input.location.status == LocationServiceStatus.Failed || Input.location.status == LocationServiceStatus.Stopped)//실제 위치값을 가져오지 못했거나 실패한 경우
        {
            data[3].text = "GPS failed";
        }

        if (delay >= maxtime) //위치정보를 가져오는데 딜레이가 길어진 경우
        {
            data[3].text = "pass delay time";
        }
        //모든 설정이 완료된 경우
        if (Input.location.isEnabledByUser == true){
            data[0].text = "위도 :" + Input.location.lastData.latitude.ToString();
            data[1].text = "경도 :" + Input.location.lastData.longitude.ToString();
            data[2].text = "고도 :" + Input.location.lastData.altitude.ToString();
            data[3].text = "위치 정보를 수신 완료하였습니다.";
        }
        yield return new WaitForSeconds(3);
    }

    void Update()
    {
        StartCoroutine(Gps_manger());
    }
}

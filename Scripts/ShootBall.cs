using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ShootBall : MonoBehaviour
{
    public GameObject _theBall;
    public Renderer _BallColor;
    public Transform _camObj;
    public Transform _shootPoint;
    public int cnt = 1;

    void Start(){
        //해당 스크립트가 시작될때 콘솔에 start를 남겨줌
        Debug.Log("start");
        
    }

    void Update(){
        //프레임별로 콘솔에 update를 표시해줌
        Debug.Log("update");
        
        //Input의 터시 값이 0보다 큰 경우 == 터치를 한 경우
        if(Input.touchCount > 0){
            //Instantiate함수가 새로운 객체를 만들어줌
            GameObject tObj = Instantiate(_theBall);
            
            //입력받은 터치를 객체로 받음
            Touch touch = Input.GetTouch(0);
            
            //터치한 부분의 위치를 vector3로 받음
            Vector3 xyPosition=touch.position;
            
            //새로 생성된 객체의 Renderer값을 매칭
            _BallColor = tObj.GetComponent<Renderer>();
            
            //순서에 따라서 색을 변경해주는 조건문
            if(cnt==1){
                _BallColor.material.color = Color.blue;
                cnt++;
            }
            else if(cnt==2){
                _BallColor.material.color = Color.red;
                cnt++;
            }
            else if(cnt==3){
                _BallColor.material.color = Color.magenta;
                cnt++;
            }
            else if(cnt==4){
                _BallColor.material.color = Color.white;
                cnt++;
            }
            else{
                _BallColor.material.color = Color.yellow;
                cnt=1;
            }
            tObj.transform.position = _shootPoint.transform.position;
            Vector3 tVec = (_shootPoint.transform.position- _camObj.transform.position).normalized;
            Rigidbody tR = tObj.GetComponent<Rigidbody>();
            tR.AddForce(tVec * 100f);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


public class ObjectOnPlane : MonoBehaviour
{
    public Button Button;
    public ARRaycastManager arRaycaster;
    public GameObject spawnPrefab;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Vector3 ScreenCenter;
    public Text text;
    public Transform camTrans;
    public Transform forwardTrans;
    public Dropdown droplist;
    int object_num = 0;

    public void ButtonClick(){
        //add the object on front of the camera
        GameObject temp = Instantiate(spawnPrefab);
        temp.transform.position = (forwardTrans.position - camTrans.position).normalized;
        temp.transform.position = temp.transform.position * 5.0f;
        if(temp){
            text.text = "객체생성 \nx:"+camTrans.position.x+"\ny:"+camTrans.position.y+"\nz:"+forwardTrans.position.z;
            object_num++;
        }
        else{
            text.text = "생성실패";
        }
        temp.name = "Cube"+object_num;

        //add the one of dropdown list
        Dropdown.OptionData option = new Dropdown.OptionData();
        option.text ="Cube"+object_num;
        droplist.options.Add(option);
        
        //DB 저장하기
        GameObject DBSave = GameObject.Find("Manger");
        DBSave.GetComponent<DB_Manger>().ObjectSave(temp);
    }
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth/2, Camera.main.pixelHeight/2);
    }

    void Update()
    {   
        
    }
}

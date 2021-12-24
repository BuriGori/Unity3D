using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectToLabel : MonoBehaviour
{   
    public Dropdown dropdown;
    public GameObject camera;
    // Start is called before the first frame update
    public Text text;
    public LineRenderer line;
    Vector3 destination;
    Vector3 start;
    void Start()
    {
    }

    public void OnValueChange(){
        destination = GameObject.Find(dropdown.options[dropdown.value].text).transform.position;
        start = camera.transform.position;
        line.SetWidth(0.5f,0.1f);
        text.text="현재 :"+dropdown.options[dropdown.value].text +"\n 출발지:"+start+"\n도착지:"+destination;
        line.SetPosition(0,start);
        line.SetPosition(1,destination);
    }
}

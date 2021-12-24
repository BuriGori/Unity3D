using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity;
using System;

public class DB_Manger : MonoBehaviour
{
    public string DBurl = "파이어 베이스 REALTIME_DB URL";
    DatabaseReference reference;
    DatabaseReference Readreference;
    System.Random rand = new System.Random();
    int PlaceNum = 0;
    void Start()
    {
        // FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(DBurl);
        // WriteDB();
        ReadDB();
        Invoke("WriteStandardDB", 5);
    }

    public void WriteStandardDB(){
        // if(Input.location.isEnabledByUser != true){
        //     Debug.Log("아직 GPS가 연결되지 않았음");
        //     return;
        // }
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        Debug.Log("실행 "+PlaceNum);
        GPSdata DATE1 = new GPSdata("Place"+PlaceNum,Input.location.lastData.latitude,Input.location.lastData.longitude,Input.location.lastData.altitude);
        string jsondate1 = JsonUtility.ToJson(DATE1);
        reference.Child("StandardGPS").Child("Place"+PlaceNum).SetRawJsonValueAsync(jsondate1);
        //after Loading
        GameObject BeforeCanvas = GameObject.Find("Loading");
        BeforeCanvas.SetActive(false);
    }

    IEnumerable WaitForSearch(){
        yield return new WaitForSeconds(4.0f);
    }
    public void WriteDB()
    {
        //DB예시 저장
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        GPSdata DATE1 = new GPSdata("Seoul",37.0f, 23.4f, 123f);
        GPSdata DATE2 = new GPSdata("Busan", 137.0f, 1223.4f, 13.5f);
        GPSdata DATE3 = new GPSdata("Daegu", 237.0f, 223.4f, 0.3f);
        string jsondate1 = JsonUtility.ToJson(DATE1);
        string jsondate2 = JsonUtility.ToJson(DATE2); 
        string jsondate3 = JsonUtility.ToJson(DATE3);

        reference.Child("Korea").Child("area"+1).SetRawJsonValueAsync(jsondate1);
        reference.Child("Korea").Child("area"+2).SetRawJsonValueAsync(jsondate2);
        reference.Child("Korea").Child("area"+3).SetRawJsonValueAsync(jsondate3);
    }

    public void ReadDB()
    {
        Readreference = FirebaseDatabase.DefaultInstance.GetReference("StandardGPS");
        Readreference.GetValueAsync().ContinueWith(task =>
        {
            if(task.IsFaulted){
                //Hendle the error.

            }
            if(task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach(DataSnapshot data in snapshot.Children){
                    PlaceNum += 1;
                }
            }
        }
        );

        // reference = FirebaseDatabase.DefaultInstance.GetReference("Korea");
        // reference.GetValueAsync().ContinueWith(task =>
        // {
        //     if (task.IsCompleted)
        //     {
        //         DataSnapshot snapshot = task.Result;

        //         foreach (DataSnapshot data in snapshot.Children)
        //         {
        //             IDictionary GPSdata = (IDictionary)data.Value;
        //             Debug.Log("이름 : " + GPSdata["name"] + "위도" + GPSdata["latitude_data"] + "경도" + GPSdata["longtitude_data"] + "고도" + GPSdata["altitude_data"]);
        //         }
        //     }
        // }
        // );
    }
    public void ObjectSave(GameObject Temp){
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        Objectdata DATE1 = new Objectdata(PlaceNum,Temp.transform.position.x,Temp.transform.position.y,Temp.transform.position.z);
        string jsondate1 = JsonUtility.ToJson(DATE1);
        Debug.Log("실행"+Temp.name);
        reference.Child("ObjectData").Child(Temp.name).SetRawJsonValueAsync(jsondate1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

//데이터에 넣을 클래스 선언
public class GPSdata
{
    public string name = "";
    public float latitude_data = 0;
    public float longitude_data = 0;
    public float altitude_data = 0;

    public GPSdata(string Name, float Lat, float Lon, float ALT)
    {
        name = Name;
        latitude_data = Lat;
        longitude_data = Lon;
        altitude_data = ALT;
    }
}
public class Objectdata
{
    public int GPS = 0;
    public float X_data = 0;
    public float Y_data = 0;
    public float Z_data = 0;

    public Objectdata(int Num, float Lat, float Lon, float ALT)
    {
        GPS = Num;
        X_data = Lat;
        Y_data = Lon;
        Z_data = ALT;
    }
}

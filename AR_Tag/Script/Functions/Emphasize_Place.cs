using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EachPlace : MonoBehaviour
{
    public GameObject Place;

    Vector3 pos;
    float delta = 0.02f;
    float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = Place.transform.position;
        v.y +=delta * Mathf.Sin(Time.time * speed);
        Place.transform.position = v;
        Place.transform.Rotate(new Vector3(0, 10 *speed * Time.deltaTime , 0));
    }
}

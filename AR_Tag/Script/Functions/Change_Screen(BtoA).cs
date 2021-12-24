using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainToMenu : MonoBehaviour
{
    public GameObject Before;
    public GameObject After;

    public void OnButtonClick(){
        Before.SetActive(false);
        After.SetActive(true);
    }
}

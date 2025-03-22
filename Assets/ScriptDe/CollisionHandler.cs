using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public float delayBeforeLoad = 2f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Va chạm với: " + other.gameObject.name);
        //Loadtime();
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Va chạm với: " + other.gameObject.name);
    //    //Loadtime();
    //}



    //void Loadtime()
    //{
    //    GetComponent<PlayerController>().enabled = false;                                                     // cách tắt script PlayerController dùng di chuyển và tắt di chuyển 
    //    Invoke("LoadScene", delayBeforeLoad);                                                               //  Invoke()lệnh gọi phương thức sau một khoảng thời gian trễ, delayBeforeLoad thời gian trể.      
    //}
    //void LoadScene()
    //{
    //    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;                                      // SceneManager.GetActiveScene().buildIndex; lấy chỉ số index của Scene hiện tại
    //    SceneManager.LoadScene(currentSceneIndex);                                                             // load lại Scene hiện tại
    //}
}

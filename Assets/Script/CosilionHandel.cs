using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CosilionHandel : MonoBehaviour
{
    [SerializeField] GameObject Playerbom;

     GameSceneManager gameSceneManager;
     void Start()
    {
        gameSceneManager = FindAnyObjectByType<GameSceneManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
      
        gameSceneManager.LoadScene();
        Debug.Log(other);
        Destroy(this.gameObject);
        Instantiate(Playerbom, transform.position, Quaternion.identity);
        
    }


  
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {

    //        Destroy(this.gameObject);
    //        Instantiate(Playerbom, transform.position, Quaternion.identity);

    //    }
    //}




    //void OnTriggerEnter (Collision collision)
    //{


    //    //Debug.Log("ll" + other.gameObject.name);
    //}

    //void OnCollisionEnter (Collider other)
    //{
    //    Instantiate(Playerbom, transform.position, Quaternion.identity);
    //    Destroy(this.gameObject);
    //    Debug.Log("ll" + other.gameObject.name);
    //}
}

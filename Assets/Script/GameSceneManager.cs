using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void LoadScene()
    {
        StartCoroutine(MyCoroutine());
    }
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1f);
        int Curensecne = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(Curensecne);
    }
}

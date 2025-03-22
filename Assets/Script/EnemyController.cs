using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject DestroyedVFX;
    [SerializeField] int Hitpoints = 4;
    [SerializeField] int scrodbald = 10;
    ScoreBoard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }
    private void ProcessHit()
    {
        Hitpoints--;
        if (Hitpoints <= 0)
        {
            scoreboard.InScorePlayer(scrodbald);
            Instantiate(DestroyedVFX, transform.position, Quaternion.identity);          // tạo ra  một bản sao  DestroyedVFX tại vị trí trsnsform.position, Quaternion.identity đối tượng hướng mặt định không có xoay    
            Destroy(gameObject);
        }
    }
}

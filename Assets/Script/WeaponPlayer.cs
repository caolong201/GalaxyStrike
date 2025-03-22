using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponPlayer : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] GameObject[] Laser;
    [SerializeField] RectTransform Crosshair;
    [SerializeField] Transform targetPoint;
    float tagetDistance = 100f ;



    private void Start()
    {
        Cursor.visible = false;                                  // tắt con trỏ chuột
    }
    void Update()
    {
        ProcessFirtings();
        MoveCrooshair();
        MoveTargetPoint();
        AimLaser();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFirtings()
    {
        foreach (var Lasers in Laser)
        {
            var ParticleModule = Lasers.GetComponent<ParticleSystem>().emission;
            ParticleModule.enabled = isFiring;
        }
    }

    void MoveCrooshair()
    {
        Crosshair.position = Input.mousePosition;                            // Nút ngắm bắn di bắn thay chuột
    }
    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, tagetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void AimLaser()
    {
        foreach(GameObject Lasers in Laser)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            Lasers.transform.rotation = rotationToTarget;
        }
    }





    //[SerializeField] GameObject [] lasers;

    //void ProcessFirting()
    //{
    //    if (Input.GetButton("Fire1"))
    //    {

    //        iDamge(true);

    //    }
    //    else
    //    {
    //        iDamge(false);
    //    }
    //}

    //void iDamge( bool isActive)
    //{

    //    foreach (GameObject Laser in lasers)
    //    {
    //        var ParticleModule = Laser.GetComponent<ParticleSystem>().emission;
    //        ParticleModule.enabled = isActive;
    //    }
    //}
}

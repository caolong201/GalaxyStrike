using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("Tốc độ di chuyển đối tượng")]  
    [SerializeField] float MoveSpeed = 3f;
    [Tooltip("Giới hạn của trục X")]
    [SerializeField] float xRangt = 5f;
    [Tooltip("Giới hạn của trục Y")]
    [SerializeField] float yRangt = 10f;

    [Header("Xoay rotation")]
    [Tooltip("Giới hạn của trục x pitch")]
    [SerializeField] float PositionFacter = -5f;                                                                   // Giá trị âm Rotation (-5f) sẽ đảo chiều ảnh hưởng (khi lên, góc giảm; khi xuống, góc tăng).
    [Tooltip("Giới hạn của trục Y yaw")]
    [SerializeField] float PositionYawFacter = 5f;

    [Header("Palyer input based tuning")]
    [SerializeField] float ControlPitchFactor = -10f;
    [Tooltip("Giới hạn của trục z    yaw")]
    [SerializeField] float PositionFacterll = -20f;
  
    [Header(" Lasers gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField]  GameObject[] lasers;
    float xThrow, yThrow;

    void Update()
    {
        Moving();
        ProcessRotation();
        //ProcessFirting();
    }
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * PositionFacter;                                                               // nếu giá trị hướng lên giá trị Y tăng
        float pitchDueToControlthow = yThrow * ControlPitchFactor;
         
        float pitch = pitchDueToPosition + pitchDueToControlthow;                                                                         // pitch trục x của Rotation , transform.localPosition.y đối tượng di chuyển dọc theo trục y, nó sẽ tự động thay đổi góc quay của mình theo một tỷ lệ được xác định bởi giá trị của PositionFacter.
        float yaw = transform.localPosition.x * PositionYawFacter;
        float roll = xThrow * PositionFacterll;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);                                                                     // nếu đối tượng đang di chuyển lên hoặc xuống, giá trị này sẽ thay đổi pitch
    }
    void Moving()
    {

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float oxffset = xThrow * Time.deltaTime * MoveSpeed;
        float newXPos = transform.localPosition.x + oxffset;                                                                        //Cập nhật vị trí mới theo trục X , tính toán vị trị mới  theo trục X
        float clampeXPos = Mathf.Clamp(newXPos, -xRangt, xRangt);                                                                    //Mathf.Clamp giới hạn vật trục x di chuyển xRangt thừ -5 đến 5 

        float oyffset = yThrow * Time.deltaTime * MoveSpeed;
        float newYPos = transform.localPosition.y + oyffset;
        float clampeYPos = Mathf.Clamp(newYPos, -yRangt, yRangt);                                                                 //  giới hạn vật trục x di chuyển xRangt thừ -10 đến 10   =>   float=yRangt = 10f
         
        transform.localPosition = new Vector3(clampeXPos, clampeYPos, transform.localPosition.z);                                // clampeXPos bao gồm xThrow( phương hương ngang) + oxffset tốc độ và Time.deltaTime + newXPos
                                                                                                                                // X clampeXPos và Y clampeYPos được giới hạn di chuyển trục z k hạn chế transform.localPosition.z 
    }
    void ProcessFirting()
    {
        if (Input.GetButton("Fire1"))

        {
            ActiveLasers(true);
        }
        else
        {
            ActiveLasers(false);
        }
        //nếu nhấn nút bắn
        // thì in "bắn"
        // nếu không thì không in "Bắn"
    }

    void ActiveLasers(bool isActive)
    {
        foreach (GameObject Laser in lasers)  //Laser nằm trong mảng lasers
        {
            //Laser.SetActive(true);

            var ParticleModule = Laser.GetComponent<ParticleSystem>().emission;
            ParticleModule.enabled = isActive;
            // bật tắt một đối tượng
        }
    }






    //void DeactivateLasers()
    //{
    //    foreach (GameObject Laser in lasers)  //Laser nằm trong mảng lasers
    //    {

    //        var ParticleModule = Laser.GetComponent<ParticleSystem>().emission;
    //        ParticleModule.enabled = false;
    //        /*    Laser.SetActive(false); */                    // bật tắt một đối tượng
    //    }
    //}

}




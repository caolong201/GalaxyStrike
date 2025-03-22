using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 30f;
    [SerializeField] float xRangt = 20f;
    [SerializeField] float yRangt = 20f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlRotalX = 20f;
    [SerializeField] float controlRotalY = 5f;
    [SerializeField] float rotationSpeed = 10f;
    Vector2 movement;                                                //lưu trữ giá trị nhập từ người chơi (dạng Vector2).
    void Update()
    {
        Moving();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();                               //giá trị từ hệ thống nhập và chuyển thành Vector2

    }
    void Moving()
    {
        float offset = movement.x * MoveSpeed * Time.deltaTime;
        float offsety = movement.y * MoveSpeed * Time.deltaTime;

        float newPostX = transform.localPosition.x + offset;
        float campePostX = Mathf.Clamp(newPostX, -xRangt, xRangt);

        float newPostY = transform.localPosition.y + offsety;
        float campePostY = Mathf.Clamp(newPostY, -yRangt, yRangt);

        transform.localPosition = new Vector3(campePostX, campePostY, 0);
    }

    void ProcessRotation()
    {

        float Pitch = -controlRotalX * movement.y;
        float Yaw = controlRotalY * movement.x;
        float Roll = -controlRollFactor * movement.x;
        Quaternion targetRotation = Quaternion.Euler(Pitch,Yaw, Roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


}

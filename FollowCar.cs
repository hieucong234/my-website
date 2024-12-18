using UnityEngine;

public class FollowCar : MonoBehaviour
{
    [SerializeField]
    private Transform car; // Tham chiếu đến đối tượng xe

    [SerializeField]
    private Vector3 offset = new Vector3(0, 5, -10); // Vị trí tương đối của camera so với xe

    [SerializeField]
    private float followSpeed = 5f; // Tốc độ camera di chuyển theo xe

    private void LateUpdate()
    {
        // Tính toán vị trí mục tiêu của camera
        Vector3 targetPosition = car.position + car.TransformDirection(offset);

        // Di chuyển camera mượt mà đến vị trí mục tiêu
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Giữ hướng nhìn của camera theo xe
        transform.LookAt(car.position);
    }
}
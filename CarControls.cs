using UnityEngine;

public class CarControls : MonoBehaviour
{
    public Car car; // Tham chiếu đến script Car điều khiển xe

    private bool isTurningLeft = false; // Trạng thái rẽ trái
    private bool isTurningRight = false; // Trạng thái rẽ phải

    // Gọi khi nhấn nút rẽ trái
    public void OnPressLeft()
    {
        isTurningLeft = true;
    }

    // Gọi khi thả nút rẽ trái
    public void OnReleaseLeft()
    {
        isTurningLeft = false;
    }

    // Gọi khi nhấn nút rẽ phải
    public void OnPressRight()
    {
        isTurningRight = true;
    }

    // Gọi khi thả nút rẽ phải
    public void OnReleaseRight()
    {
        isTurningRight = false;
    }

    private void Update()
    {
        // Gửi tín hiệu rẽ sang script Car
        if (isTurningLeft)
        {
            car.SetReXe(-1); // Rẽ trái
        }
        else if (isTurningRight)
        {
            car.SetReXe(1); // Rẽ phải
        }
        else
        {
            car.SetReXe(0); // Không rẽ
        }
    }
}

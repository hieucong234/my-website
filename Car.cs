using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float tocDoXe = 100f; // Tốc độ di chuyển
    [SerializeField]
    private float lucReXe = 100f; // Lực để rẽ xe
    [SerializeField]
    private GameObject hieuUngPhanh; // Hiệu ứng phanh
    [SerializeField]
    private float lucPhanh = 50f; // Lực phanh

    private float dauVaoRe; // Input rẽ từ người chơi
    private float dauVaoDiChuyen; // Input di chuyển từ người chơi
    private Rigidbody rb;

    private AudioSource carAudio; // Âm thanh động cơ
    private bool isMoving = false; // Trạng thái xe có đang di chuyển

    public Joystick joystick;
    

    private void Start()
    {
        // Lấy Rigidbody và AudioSource của xe
        rb = GetComponent<Rigidbody>();
        carAudio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        // Lấy giá trị input từ bàn phím (Cái này vẫn giữ nguyên nếu bạn cần test trên máy tính)
        dauVaoDiChuyen = Input.GetAxis("Vertical"); // W/S hoặc mũi tên lên/xuống
        dauVaoRe = Input.GetAxis("Horizontal"); // A/D hoặc mũi tên trái/phải

        dauVaoDiChuyen = joystick != null ? joystick.Vertical : Input.GetAxis("Vertical");
        dauVaoRe = joystick != null ? joystick.Horizontal : Input.GetAxis("Horizontal");


        // Di chuyển xe
        DiChuyenXe();

        // Rẽ xe
        ReXe();

        // Kiểm tra phanh
        if (dauVaoDiChuyen > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            PhanhXe();
        }

        // Kiểm tra trạng thái âm thanh
        KiemTraAmThanh();
    }

    public void DiChuyenXe()
    {
        // Thêm lực để xe di chuyển về phía trước hoặc lùi
        rb.AddRelativeForce(Vector3.forward * dauVaoDiChuyen * tocDoXe);
        hieuUngPhanh.SetActive(false); // Tắt hiệu ứng phanh
    }

    public void ReXe()
    {
        // Tính toán góc quay cho xe
        float gocQuay = dauVaoRe * lucReXe * Time.deltaTime;

        // Tạo quaternion đại diện cho góc quay
        Quaternion quayMoi = Quaternion.Euler(0f, gocQuay, 0f);

        // Xoay Rigidbody
        rb.MoveRotation(rb.rotation * quayMoi);
    }

    public void PhanhXe()
    {
        // Kiểm tra nếu xe đang di chuyển
#pragma warning disable CS0618 // Type or member is obsolete
        if (rb.velocity.magnitude > 0.1f) // Sử dụng magnitude để kiểm tra tốc độ tổng hợp
        {
            // Thêm lực phanh vào Rigidbody
            rb.AddRelativeForce(-Vector3.forward * lucPhanh);
            hieuUngPhanh.SetActive(true); // Bật hiệu ứng phanh
        }
#pragma warning restore CS0618 // Type or member is obsolete
    }

    private void KiemTraAmThanh()
    {
        // Kiểm tra trạng thái di chuyển
#pragma warning disable CS0618 // Type or member is obsolete
        if (rb.velocity.magnitude > 0.1f) // Xe đang di chuyển
        {
            if (!isMoving) // Chỉ phát âm thanh nếu trạng thái thay đổi
            {
                carAudio.Play();
                isMoving = true;
            }
        }
        else // Xe đã dừng
        {
            if (isMoving) // Chỉ dừng âm thanh nếu trạng thái thay đổi
            {
                carAudio.Stop();
                isMoving = false;
            }
        }
#pragma warning restore CS0618 // Type or member is obsolete
    }

    // Hàm điều khiển di chuyển từ UI Button (Tiến, Lùi)
    public void SetDiChuyen(float dauVao)
    {
        dauVaoDiChuyen = dauVao; // Gán giá trị di chuyển từ nút cảm ứng (Tiến hoặc Lùi)
    }

    // Hàm điều khiển rẽ từ UI Button (Rẽ trái, Rẽ phải)
    public void SetReXe(float dauVao)
    {
        dauVaoRe = dauVao; // Gán giá trị rẽ từ nút cảm ứng (Rẽ trái hoặc Rẽ phải)
    }

    // Hàm reset di chuyển (khi thả nút)
    public void ResetDiChuyen()
    {
        dauVaoDiChuyen = 0f; // Dừng xe khi thả nút
    }

    // Hàm reset rẽ (khi thả nút)
    public void ResetReXe()
    {
        dauVaoRe = 0f; // Dừng rẽ khi thả nút
    }
}

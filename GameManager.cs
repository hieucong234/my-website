using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float ThoiGianChoPhepVeDich = 30f;
    public bool KetThucGame = false;
    public bool winGame = false;
    private static GameManager instance;

    public GameObject gameOverOject;
    public GameObject timeGameOject;
    [SerializeField]
    public GameObject winGameOject;

    [SerializeField]
    private float ThoiGianHoiKhiQuaCheckPoint = 15f;

    [SerializeField]
    private GameObject carControlButtons; // Tham chiếu đến GameObject chứa các nút điều khiển xe.

    public static GameManager Instance {
        get {
            if(instance == null) {
                instance = FindAnyObjectByType<GameManager>();
                if(instance == null) {
                    GameObject gameManagerGameObject = new GameObject("GameMan");
                    instance = gameManagerGameObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Update() {
        if (!KetThucGame) {
            ThoiGianChoPhepVeDich -= Time.deltaTime;
            Debug.Log(ThoiGianChoPhepVeDich);
            if (ThoiGianChoPhepVeDich <= 0) {
                timeGameOject.SetActive(false);
                gameOverOject.SetActive(true);
                EndGame();
            }
        }

        if (winGame) {
            timeGameOject.SetActive(false);
            winGameOject.SetActive(true);
            HideCarControls();
        }
    }

    public void EndGame() {
        KetThucGame = true;
        HideCarControls(); // Ẩn nút điều khiển xe khi kết thúc game.
    }

    public void QuaCheckPoint() {
        if (!KetThucGame) {
            ThoiGianChoPhepVeDich = ThoiGianHoiKhiQuaCheckPoint;
        }
    }

    public void QuaWinPoint() {
        if (!KetThucGame) {
            winGame = true;
        }
    }

    private void HideCarControls() {
        if (carControlButtons != null) {
            carControlButtons.SetActive(false); // Ẩn các nút điều khiển xe.
        } else {
            Debug.LogWarning("Car control buttons not assigned in the inspector!");
        }
    }
}

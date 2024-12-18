using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameUi : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void Update() {
        HienThiThoiGianGame();
    }

    public void HienThiThoiGianGame() {
        timeText.SetText(Mathf.FloorToInt(GameManager.Instance.ThoiGianChoPhepVeDich).ToString());
    }

    public void ChoiLai() {
        SceneManager.LoadScene("game");
    }

    public void VeMenu() {
        SceneManager.LoadScene("menu");
    }
}

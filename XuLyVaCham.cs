using UnityEngine;

public class XuLyVaCham : MonoBehaviour
{
   private void OnTriggerEnter(Collider orther) {
    if(orther.gameObject.tag == "CheckPoint1" || orther.gameObject.tag == "CheckPoint2" || orther.gameObject.tag == "CheckPoint3" || orther.gameObject.tag == "CheckPoint4") {
        GameManager.Instance.QuaCheckPoint();
    }
    if(orther.gameObject.tag == "WinPoint") {
        GameManager.Instance.QuaWinPoint();
    }
   }
}

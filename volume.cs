using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Bắt đầu phát nhạc
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // Điều chỉnh âm lượng (giá trị từ 0.0 đến 1.0)
    }

    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
            audioSource.Pause(); // Tạm dừng nhạc
        else
            audioSource.Play(); // Tiếp tục phát nhạc
    }
}

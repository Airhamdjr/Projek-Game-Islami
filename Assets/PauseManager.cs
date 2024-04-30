using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pausePanel;
    
    void Update()
    {
        // Cek jika tombol "Esc" ditekan
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Panggil fungsi TogglePause untuk mengganti status pause
            TogglePause();
        }
    }

    void TogglePause()
    {
        // Ubah status pause
        isPaused = !isPaused;

        // Jika di-pause, tampilkan panel pause atau atur waktu menjadi 0
        if (isPaused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            // Tambahkan logika tampilan panel pause atau menu pause di sini
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            // Tambahkan logika untuk menyembunyikan panel pause atau kembali ke permainan
            Debug.Log("Game Resumed");
        }
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}

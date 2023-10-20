using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Thoatselctlv : MonoBehaviour
{

    void Start()
    {
        // Lấy đối tượng Button để bắt sự kiện
        Button backBtn = GetComponent<Button>();
        backBtn.onClick.AddListener(BackButtonClick);
    }

    void BackButtonClick()
    {
        // Điều hướng trở lại màn hình Play
        SceneManager.LoadScene("PlayGame");
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ketthuclevel : MonoBehaviour
{
    private AudioSource ketthuclevel; // Âm thanh khi hoàn thành cấp độ
    private bool quaman = false; // Biến kiểm tra xem đã qua màn hay chưa

    private void Start()
    {
        ketthuclevel = GetComponent<AudioSource>(); // Lấy thành phần AudioSource từ GameObject

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !quaman) // Nếu va chạm với đối tượng có tên là "Player" và chưa qua màn
        {
            ketthuclevel.Play(); // Phát âm thanh khi hoàn thành cấp độ
            quaman = true; // Đánh dấu đã qua màn
            Invoke("capdolevel", 2f); // Gọi phương thức capdolevel() sau 2 giây (để chuyển sang cấp độ tiếp theo)

        }
    }

    private void capdolevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Tải cảnh tiếp theo trong danh sách cảnh theo thứ tự xây dựng
    }
}

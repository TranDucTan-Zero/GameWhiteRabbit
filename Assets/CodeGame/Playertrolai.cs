using UnityEngine;
using UnityEngine.SceneManagement;

public class Playertrolai : MonoBehaviour
{
    private Rigidbody2D rb; // Cơ thể (Rigidbody2D) của nhân vật
    private Animator hh; // Hoạt hình (Animator) của nhân vật
    [SerializeField] private AudioSource amthanhdie; // Âm thanh khi nhân vật chết

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hh = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cambay")) // Nếu va chạm với đối tượng có tag là "Cambay"
        {
            Die(); // Gọi phương thức Die()
        }
    }

    private void Die()
    {
        amthanhdie.Play(); // Phát âm thanh khi nhân vật chết
        rb.bodyType = RigidbodyType2D.Static; // Đặt bodyType thành Static để ngừng vận động
        hh.SetTrigger("Die"); // Kích hoạt trạng thái "Die" trong hoạt hình
        Invoke("Hoisinh", 1f); // Gọi phương thức Hoisinh() sau 1 giây (để hồi sinh nhân vật)
    }

    private void Hoisinh()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // Đặt bodyType thành Dynamic để cho phép vận động lại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại cảnh hiện tại để bắt đầu lại trò chơi
    }
}



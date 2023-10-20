using UnityEngine;
using UnityEngine.UI;

public class Nhanvatpham : MonoBehaviour
{
    private int slvatpham = 0; // Số lượng vật phẩm
    [SerializeField] private Text DoanText; // Đối tượng Text để hiển thị số lượng vật phẩm
    [SerializeField] private AudioSource amthanhan; // Âm thanh

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("VatPham")) // Kiểm tra nếu vật phẩm va chạm có tag là "VatPham"
        {
            amthanhan.Play(); // Phát âm thanh
            Destroy(collision.gameObject); // Hủy vật phẩm
            slvatpham++; // Tăng số lượng vật phẩm lên 1
        }

        UpdateDoanText(); // Cập nhật Text hiển thị số lượng vật phẩm
    }

    private void UpdateDoanText()
    {
        DoanText.text = "" + slvatpham; // Cập nhật giá trị của Text thành số lượng vật phẩm
    }
}

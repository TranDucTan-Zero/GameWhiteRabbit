using UnityEngine;

public class ResizeButton : MonoBehaviour
{
    private Vector2 originalSize;

    private void Awake()
    {
        // Lưu trữ kích thước ban đầu của nút button
        originalSize = GetComponent<RectTransform>().sizeDelta;
    }

    private void Update()
    {
        // Kiểm tra sự thay đổi kích thước màn hình
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        // Tính toán tỷ lệ giữa kích thước ban đầu và kích thước màn hình
        Vector2 scaleRatio = new Vector2(screenSize.x / originalSize.x, screenSize.y / originalSize.y);

        // Thiết lập lại kích thước của nút button
        GetComponent<RectTransform>().sizeDelta = originalSize * scaleRatio;
    }
}

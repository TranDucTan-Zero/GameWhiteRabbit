
using UnityEngine;

public class ThoPink : MonoBehaviour
{
    public float tocdo = 5f; // Tốc độ di chuyển
    public float phai = 3f; // Vị trí cần đạt tới phía bên phải
    public float trai; // Vị trí cần đạt tới phía bên trái
    private Vector3 traiphai; // Góc xoay ban đầu

    void Start()
    {
        phai = transform.position.x + phai; // Tính toán vị trí bên phải dựa trên vị trí hiện tại và khoảng cách cần đi
        trai = transform.position.x - trai; // Tính toán vị trí bên trái dựa trên vị trí hiện tại và khoảng cách cần đi
        traiphai = transform.eulerAngles; // Ghi nhớ góc xoay ban đầu
    }

    void Update()
    {
        transform.Translate(Vector3.left * tocdo * Time.deltaTime); // Di chuyển đối tượng sang trái dựa trên tốc độ và thời gian

        if (transform.position.x < trai)
        {
            transform.eulerAngles = traiphai - new Vector3(0, 180, 0); // Nếu vượt quá vị trí bên trái, quay đối tượng theo hướng ngược lại (xoay góc 180 độ)
        }

        if (transform.position.x > phai)
        {
            transform.eulerAngles = traiphai; // Nếu vượt quá vị trí bên phải, quay đối tượng về góc ban đầu
        }
    }
}

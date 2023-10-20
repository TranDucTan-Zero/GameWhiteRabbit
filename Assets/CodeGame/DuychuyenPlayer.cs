using UnityEngine;

public class DuychuyenPlayer : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody2D để xử lý chuyển động của nhân vật
    private BoxCollider2D doichieu; // BoxCollider2D để xác định vùng va chạm
    private Animator amin; // Animator để điều khiển hoạt hình
    private SpriteRenderer ma; // SpriteRenderer để điều khiển hình ảnh của nhân vật
    [SerializeField] private LayerMask nhaytrendat; // LayerMask để xác định layer cho việc nhảy
    private float thumuc = 0f; // Thumuc là hướng di chuyển của nhân vật
    [SerializeField] private float tocdoduychuyen = 7f; // Tốc độ di chuyển của nhân vật
    [SerializeField] private float lucnhay = 20f; // Lực nhảy của nhân vật
    private enum MovementState { dung, chay, nhay, nga } // Các trạng thái di chuyển của nhân vật
    [SerializeField] private AudioSource amthanhnhay; // AudioSource để phát âm thanh nhảy
    public GameObject player; // Đối tượng nhân vật

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Tìm đối tượng nhân vật dựa trên tag "Player"
        rb = GetComponent<Rigidbody2D>(); // Lấy component Rigidbody2D của nhân vật

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>(); // Nếu nhân vật chưa có Rigidbody2D, thêm component Rigidbody2D vào nhân vật
        }

        rb.bodyType = RigidbodyType2D.Dynamic; // Đảm bảo loại Rigidbody2D của nhân vật là Dynamic để có chuyển động
        doichieu = GetComponent<BoxCollider2D>(); // Lấy component BoxCollider2D của nhân vật
        ma = GetComponent<SpriteRenderer>(); // Lấy component SpriteRenderer của nhân vật để điều khiển hình ảnh
        amin = GetComponent<Animator>(); // Lấy component Animator của nhân vật để điều khiển hoạt hình
    }

    private void Update()
    {
        thumuc = Input.GetAxisRaw("Horizontal"); // Lấy giá trị đầu vào từ người chơi để xác định hướng di chuyển của nhân vật

        if (rb.bodyType == RigidbodyType2D.Dynamic) // Kiểm tra loại Rigidbody2D trước khi sử dụng velocity
        {
            rb.velocity = new Vector2(thumuc * tocdoduychuyen, rb.velocity.y); // Cập nhật vận tốc di chuyển của nhân vật theo hướng và tốc độ đã định trước
        }

        if (Input.GetButtonDown("Jump") && Cancu()) // Kiểm tra nút nhảy được nhấn và nhân vật đang đứng trên mặt đất
        {
            amthanhnhay.Play(); // Phát âm thanh nhảy
            rb.velocity = new Vector2(rb.velocity.x, lucnhay); // Cập nhật vận tốc nhảy của nhân vật
        }

        UpdateAnimationState(); // Cập nhật trạng thái hoạt hình của nhân vật
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (thumuc > 0f)
        {
            state = MovementState.chay; // Nếu nhân vật di chuyển sang phải, trạng thái là "chạy"
            ma.flipX = false; // Đảo hướng hình ảnh của nhân vật để nhìn về phía phải
        }
        else if (thumuc < 0f)
        {
            state = MovementState.chay; // Nếu nhân vật di chuyển sang trái, trạng thái là "chạy"
            ma.flipX = true; // Đảo hướng hình ảnh của nhân vật để nhìn về phía trái
        }
        else
        {
            state = MovementState.dung; // Nếu nhân vật đứng yên, trạng thái là "dừng"
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.nhay; // Nếu nhân vật đang đi lên, trạng thái là "nhảy"
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.nga; // Nếu nhân vật đang đi xuống, trạng thái là "ngã"
        }

        amin.SetInteger("state", (int)state); // Cập nhật giá trị của trạng thái hoạt hình trong Animator
    }

    private bool Cancu()
    {
        // Sử dụng BoxCast để kiểm tra va chạm với mặt đất bằng cách tạo một hình hộp (BoxCollider2D) và xem liệu có va chạm với các vật thể có layer nhaytrendat hay không
        // Hình hộp được tạo dựa trên trung tâm và kích thước của BoxCollider2D của nhân vật
        // Ray được phát đi theo hướng Vector2.down (phía dưới) và chỉ kiểm tra trong khoảng cách rất nhỏ (0.1f)
        // Nếu có va chạm với mặt đất, trả về true; ngược lại, trả về false

        return Physics2D.BoxCast(doichieu.bounds.center, doichieu.bounds.size, 0f, Vector2.down, .1f, nhaytrendat);
    }
}
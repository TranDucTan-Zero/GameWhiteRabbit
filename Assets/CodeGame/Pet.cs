
using UnityEngine;
public class Pet : MonoBehaviour
{
    private GameObject player;
    [SerializeField]private Vector3 offset = new Vector3(-4f, 0f, 0f);// khoảng cách pet và player
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private float jumpForce = 5f;//nhảy
    [SerializeField] private float speed = 5f;// tocdo
    private LayerMask obstacleLayer;

    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private bool isGrounded = false;
    private SpriteRenderer image;

    private void Start()
    {
        player = GameObject.Find("Player"); // Tìm Player bằng phương thức GameObject.Find
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 targetPosition = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if (isGrounded && Random.value < 0.01f) // Sử dụng Random để pet nhảy ngẫu nhiên
        {
            if (rb != null) // Kiểm tra xem rb đã được hủy chưa
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }
    }

    private void FixedUpdate()
    {
        // Di chuyển pet đến Player
        Vector2 targetVelocity = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.fixedDeltaTime);

        // Kiểm tra pet có chạm chướng ngại vật không
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.2f, obstacleLayer);
        if (hitColliders.Length > 0)
        {
            // Nếu có chạm, quay đầu lại
            Vector2 dir = hitColliders[0].transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        }
        else
        {
            // Nếu không chạm, tiếp tục di chuyển về phía Player
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra pet có chạm đất không
        if (collision.gameObject.layer == LayerMask.NameToLayer("Diahinh"))
        {
            isGrounded = true;
        }
    }
}






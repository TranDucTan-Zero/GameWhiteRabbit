using UnityEngine;

public class thoman3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D doichieu;
    private Animator amin;
    private SpriteRenderer ma;
    private float thumuc = 0f;
    [SerializeField] private float tocdoduychuyen = 7f;
    [SerializeField] private float lucnhay = 14f;
    private enum MovementState { dung, chay, nhay, nga }
    [SerializeField] private AudioSource amthanhnhay;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>(); // Thêm Rigidbody2D nếu chưa có
        }

        rb.bodyType = RigidbodyType2D.Dynamic; // Đảm bảo loại Rigidbody2D là Dynamic
        doichieu = GetComponent<BoxCollider2D>();
        ma = GetComponent<SpriteRenderer>();
        amin = GetComponent<Animator>();
    }

    private void Update()
    {
        thumuc = Input.GetAxisRaw("Horizontal");

        if (rb.bodyType == RigidbodyType2D.Dynamic) // Kiểm tra loại Rigidbody2D trước khi sử dụng velocity
        {
            rb.velocity = new Vector2(thumuc * tocdoduychuyen, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            amthanhnhay.Play();
            rb.velocity = new Vector2(rb.velocity.x, lucnhay);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (thumuc > 0f)
        {
            state = MovementState.chay;
            ma.flipX = false;
        }
        else if (thumuc < 0f)
        {
            state = MovementState.chay;
            ma.flipX = true;
        }
        else
        {
            state = MovementState.dung;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.nhay;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.nga;
        }
        amin.SetInteger("state", (int)state);
    }
}


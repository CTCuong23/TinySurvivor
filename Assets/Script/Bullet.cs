using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        // Gán vận tốc ngay khi đạn sinh ra
        // transform.up là hướng "lên" của viên đạn (hướng mũi tên đỏ trong Scene)
        // Vì Player xoay mặt thế nào thì đạn sẽ xoay theo thế ấy
        rb.linearVelocity = transform.up * speed;

        // Tự hủy sau 2 giây để đỡ nặng máy
        Destroy(gameObject, 2f);
    }

    // Hàm này để dành cho bữa sau (Xử lý va chạm)
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log("Bắn trúng: " + hitInfo.name);
        // Destroy(gameObject); // Đạn biến mất khi trúng đích
    }
}
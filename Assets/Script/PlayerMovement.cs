using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;          // Tốc độ chạy
    public Rigidbody2D rb;            // Xác nhân vật
    public Joystick joystick;         // Cần điều khiển

    Vector2 moveInput;

    void Update()
    {
        // 1. Nhận lệnh từ bàn phím (Máy tính)
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // 2. Nếu bàn phím không bấm -> Nhận lệnh từ Joystick (Điện thoại)
        if (moveInput == Vector2.zero && joystick != null)
        {
            moveInput.x = joystick.Horizontal;
            moveInput.y = joystick.Vertical;
        }

        // Chuẩn hóa để đi chéo không bị nhanh hơn
        moveInput = moveInput.normalized;
    }

    void FixedUpdate()
    {
        // 3. Di chuyển nhân vật
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);

        // 4. Xoay mặt theo hướng chạy (Tùy chọn)
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            // Trừ 90 độ vì ảnh gốc Kenney thường hướng lên trên
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
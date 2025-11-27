using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // Mục tiêu để theo dõi
    public Vector3 offset = new Vector3(0, 0, -10); // Khoảng cách (Z = -10 để nhìn thấy 2D)
    public float smoothSpeed = 5f; // Độ mượt khi camera chạy theo

    void LateUpdate()
    {
        if (player != null)
        {
            // Tính vị trí mong muốn
            Vector3 desiredPos = player.position + offset;

            // Dùng Lerp để camera lướt đi mượt mà thay vì giật cục
            transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        }
    }
}
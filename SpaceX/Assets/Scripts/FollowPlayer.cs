using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerShip;    // Tham chiếu tới tàu của người chơi
    [SerializeField] float cameraSpeed = 6f;   // Tốc độ di chuyển camera

    private Vector3 offset;    // Khoảng cách giữa camera và player

    void Start()
    {
        if ( playerShip != null ) {
            // Tính toán khoảng cách giữa camera và player tại thời điểm bắt đầu
            offset = transform.position - playerShip.transform.position;
        }
    }

    // LateUpdate để đảm bảo camera theo dõi mượt mà sau khi player di chuyển
    void LateUpdate()
    {
        if ( playerShip != null ) {
            // Di chuyển camera theo player nhưng giữ nguyên khoảng cách ban đầu (offset)
            Vector3 targetPosition = playerShip.transform.position + offset;
            // Smooth camera movement
            transform.position = Vector3.Lerp (transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        }
    }
}

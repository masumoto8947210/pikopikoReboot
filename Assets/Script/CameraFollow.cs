using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public Vector2 minPosition; // カメラの移動範囲の最小値
    public Vector2 maxPosition; // カメラの移動範囲の最大値

    void LateUpdate()
    {
            // プレイヤーの位置を追跡（z軸は変更しない）
            Vector3 targetPosition = new Vector3(
                Mathf.Clamp(player.position.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(player.position.y, minPosition.y, maxPosition.y),
                transform.position.z
            );
            transform.position = targetPosition;
    }
}

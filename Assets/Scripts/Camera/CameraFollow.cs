using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ÷ель, за которой будет следовать камера
    public float smoothSpeed = 0.125f; // —корость плавного перемещени€ камеры

    private Vector3 offset; // —мещение камеры относительно цели
    private Vector3 initialPosition; // Ќачальна€ позици€ камеры

    private void Start()
    {
        // «апоминаем начальную позицию камеры
        initialPosition = transform.position;
        // ¬ычисл€ем смещение камеры относительно цели
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // –ассчитываем позицию, в которую должна переместитьс€ камера
        Vector3 desiredPosition = target.position + offset;
        // »спользуем метод SmoothDamp дл€ плавного перемещени€ камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    public void ResetCamera()
    {
        // ¬озвращаем камеру в начальную позицию
        transform.position = initialPosition;
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ����, �� ������� ����� ��������� ������
    public float smoothSpeed = 0.125f; // �������� �������� ����������� ������

    private Vector3 offset; // �������� ������ ������������ ����
    private Vector3 initialPosition; // ��������� ������� ������

    private void Start()
    {
        // ���������� ��������� ������� ������
        initialPosition = transform.position;
        // ��������� �������� ������ ������������ ����
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // ������������ �������, � ������� ������ ������������� ������
        Vector3 desiredPosition = target.position + offset;
        // ���������� ����� SmoothDamp ��� �������� ����������� ������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    public void ResetCamera()
    {
        // ���������� ������ � ��������� �������
        transform.position = initialPosition;
    }
}

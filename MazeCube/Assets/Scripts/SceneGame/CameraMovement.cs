using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 _offset;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _offset = transform.position - _playerController.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _playerController.transform.position + _offset;
    }
}

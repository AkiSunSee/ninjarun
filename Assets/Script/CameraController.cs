using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform parent;
    [SerializeField] private float RotateSpeed;
    private void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float RotateX = Input.GetAxis("Horizontal") * RotateSpeed;
        parent.Rotate(Vector3.up, RotateX * Time.deltaTime);
    }
}

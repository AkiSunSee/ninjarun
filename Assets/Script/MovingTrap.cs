
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition= transform.position;
        Debug.Log(startingPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = startingPosition;

        v.z += distanceToCover * Mathf.Sin(Time.time*speed);
        transform.position= v;
    }
}

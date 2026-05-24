using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    [SerializeField] private Vector3 degreesPerSecond = new Vector3(0, 0, 0);

    void Update()
    {
        transform.Rotate(degreesPerSecond * Time.deltaTime);
    }
}

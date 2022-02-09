using UnityEngine;

public class DummyActor : MonoBehaviour
{
    private Vector3 targetPosition;
    private float _lastRotation;

    public void Update()
    {
        float distance = Vector3.Distance(targetPosition, this.transform.position);
        if (distance > 0.05f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, 5f * Time.deltaTime);

            var dir = targetPosition - this.transform.position;
            
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }
        else
        {
            this.transform.position = targetPosition;
            this.transform.rotation = Quaternion.Slerp( this.transform.rotation, Quaternion.Euler(0.0f, _lastRotation, 0.0f), 15f * Time.deltaTime);
        }
    }

    public void SetPosition(Vector3 position, float rotation)
    {
        targetPosition = position;
        _lastRotation = rotation;
    }
}

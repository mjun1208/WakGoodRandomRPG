using UnityEngine;

public class DummyActor : MonoBehaviour
{
    private Vector3 targetPosition;
    
    public void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition,5f * Time.deltaTime);
    }

    public void SetPosition(Vector3 position, float rotation)
    {
        targetPosition = position;
        
        float rotationVelocity = 0f;
        rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref rotationVelocity, 0f);
        this.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
    }
}

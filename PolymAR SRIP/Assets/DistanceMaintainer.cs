using UnityEngine;

public class DistanceMaintainer : MonoBehaviour
{
    public Transform atom3;
    public Transform atom4;
    [SerializeField] private float targetDistance = 2.0f; // The distance that should be maintained

    void FixedUpdate()
    {
        Vector3 displacement = atom4.localPosition - atom3.localPosition;
        float currentDistance = displacement.magnitude;

        if (currentDistance < targetDistance)
        {
            // Calculate the correction direction and position
            Vector3 correctionDirection = displacement.normalized;
            Vector3 targetPosition = atom3.localPosition + correctionDirection * targetDistance;

            // Move atom4 to the target position
            atom4.localPosition = targetPosition;

            // If atom4 has a Rigidbody, set its velocity to zero to prevent further movement
            Rigidbody rb4 = atom4.GetComponent<Rigidbody>();
            if (rb4 != null)
            {
                rb4.velocity = Vector3.zero;
            }
        }
    }
}

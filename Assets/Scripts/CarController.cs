using TMPro;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider[] wheelColliders;
    private Rigidbody rb;
    
    public float forwardTorque;
    public float steeringAngle;
    public float brakeTorque;

    public TMP_Text speedText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 input = new Vector2();
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        bool isShift = Input.GetKey(KeyCode.LeftShift);
        steeringAngle = isShift ? 90 : 20;
        //forwardTorque = isShift ? 20000 : 10000;
        
        wheelColliders[2].motorTorque = forwardTorque / 2.0f * input.y;
        wheelColliders[3].motorTorque = forwardTorque / 2.0f * input.y;
        
        wheelColliders[0].steerAngle = steeringAngle / 2.0f * input.x;
        wheelColliders[1].steerAngle = steeringAngle / 2.0f * input.x;
        
        foreach (var w in wheelColliders) w.brakeTorque = brakeTorque * (Input.GetKey(KeyCode.Space) ? 1 : 0);

        speedText.text = $"{rb.velocity.magnitude * 3.6f:F0} Km/h";
    }
}

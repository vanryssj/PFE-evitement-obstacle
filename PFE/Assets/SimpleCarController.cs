using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{

    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public Transform frontleftwheeltrans;
    public Transform frontrightwheeltrans;
    public Transform rearleftwheeltrans;
    public Transform rearrightwheeltrans;
    public WheelCollider frontleftwheel;
    public WheelCollider frontrightwheel;
    public WheelCollider rearleftwheel;
    public WheelCollider rearrightwheel;
    
    public void FixedUpdate()
    {
        UpdateCollider();
        UpdateVisualWheel(frontleftwheel,frontleftwheeltrans);
        UpdateVisualWheel(frontrightwheel,frontrightwheeltrans);
        UpdateVisualWheel(rearleftwheel,rearleftwheeltrans);
        UpdateVisualWheel(rearrightwheel,rearrightwheeltrans);
        
    }
    
    public void UpdateCollider() {
    
    	float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float currentsteerAngle = maxSteeringAngle * Input.GetAxis("Horizontal");
        rearleftwheel.motorTorque = motor;
        rearrightwheel.motorTorque = motor;
        frontleftwheel.steerAngle = currentsteerAngle;
        frontrightwheel.steerAngle = currentsteerAngle;
    }
    
    	
    public void UpdateVisualWheel(WheelCollider wheelCollider, Transform wheelTransform) {
    	Vector3 pos;
    	Quaternion rot;
    	wheelCollider.GetWorldPose(out pos, out rot);
    	wheelTransform.rotation = rot;
    	wheelTransform.position = pos;
    }
    	 
    	
    public void Update(){
    
    	frontleftwheeltrans.transform.Rotate(frontleftwheel.rpm/60*360*Time.deltaTime,0,0);
    	frontrightwheeltrans.transform.Rotate(frontrightwheel.rpm/60*360*Time.deltaTime,0,0);
    	rearleftwheeltrans.transform.Rotate(frontleftwheel.rpm/60*360*Time.deltaTime,0,0);
    	rearrightwheeltrans.transform.Rotate(frontrightwheel.rpm/60*360*Time.deltaTime,0,0);
    }


}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
    
public class CarAgentController : Agent {

	
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
    public Transform Target;    
    Rigidbody rBody;
    public Material winMaterial;
    public Material loseMaterial;
    public MeshRenderer floorMeshRenderer;
        
        
        

    void Start () {
        	rBody = GetComponent<Rigidbody>();
    	}
    
    
    public override void OnEpisodeBegin()
    	{
    		
    		this.rBody.angularVelocity = Vector3.zero;
            	this.rBody.velocity = Vector3.zero;
            	this.transform.localPosition = new Vector3( 0, 0, -4);
            	this.transform.localRotation = new Quaternion(0,0,0,0);
        

        	// Move the target to a new spot
        	Target.localPosition = new Vector3(Random.value * 4-2,0.5f, Random.value * 50);
    }
    
    public override void CollectObservations(VectorSensor sensor)
	{
    		// Target and Agent positions
    		sensor.AddObservation(Target.localPosition);
    		sensor.AddObservation(this.transform.localPosition);

    		// Agent velocity
    		sensor.AddObservation(rBody.velocity.y);
    		sensor.AddObservation(rBody.velocity.z);
	}
    
    
    public float forceMultiplier = 10;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
    		// Actions, size = 2
    		rearleftwheel.motorTorque = maxMotorTorque;
    	    	rearrightwheel.motorTorque = maxMotorTorque;
    	    	frontleftwheel.steerAngle = maxSteeringAngle*actionBuffers.ContinuousActions[0];
    	    	frontrightwheel.steerAngle = maxSteeringAngle*actionBuffers.ContinuousActions[0];
    	    	frontleftwheel.motorTorque = maxMotorTorque;
    	    	frontrightwheel.motorTorque = maxMotorTorque;
    	    	UpdateVisualWheel(frontleftwheel,frontleftwheeltrans);
       	UpdateVisualWheel(frontrightwheel,frontrightwheeltrans);
        	UpdateVisualWheel(rearleftwheel,rearleftwheeltrans);
        	UpdateVisualWheel(rearrightwheel,rearrightwheeltrans);
    	    	Vector3 controlSignal = Vector3.zero;
    		controlSignal.z = maxMotorTorque;
    		controlSignal.y = maxSteeringAngle*actionBuffers.ContinuousActions[0];
    		
    		rBody.AddForce(controlSignal * forceMultiplier);
    		

    		
    		// Fell off platform
    		if (this.transform.localPosition.x < -3 | this.transform.localPosition.x > 3 | this.transform.localPosition.z > 53 | this.transform.localPosition.z < -7)
    		{
    			floorMeshRenderer.material = loseMaterial;
        		EndEpisode();
    		}
	}
    
    public override void Heuristic(in ActionBuffers actionsOut)
	{
		
    		var continuousActionsOut = actionsOut.ContinuousActions;
    		continuousActionsOut[0] = Input.GetAxis("Horizontal");
    		//continuousActionsOut[1] = Input.GetAxis("Vertical");
    		
	}
    

    public void UpdateVisualWheel(WheelCollider wheelCollider, Transform wheelTransform) {
    	Vector3 pos;
    	Quaternion rot;
    	wheelCollider.GetWorldPose(out pos, out rot);
    	wheelTransform.rotation = rot;
    	wheelTransform.position = pos;
    }
    
    void OnCollisionEnter(Collision collision)
    {
    	floorMeshRenderer.material = winMaterial;
    	AddReward(1.0f);
    	EndEpisode();
    }
}

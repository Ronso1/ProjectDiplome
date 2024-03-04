﻿using UnityEngine;

public class RearWheelDrive : MonoBehaviour {

	[SerializeField] private WheelCollider[] wheels;
	[SerializeField] private Transform[] wheelsTransform;

	public float maxAngle = 30;
	public float maxTorque = 300;

	public void Update()
	{
		float angle = maxAngle * Input.GetAxis("Horizontal");
		float torque = maxTorque * Input.GetAxis("Vertical");

		for (int i = 0; i < wheels.Length; i++)
		{
            if (wheels[i].transform.localPosition.z > 0)
				wheels[i].steerAngle = angle;

            if (wheels[i].transform.localPosition.z < 0)
				wheels[i].motorTorque = torque;

            RotateWheel(wheels[i], wheelsTransform[i]);
        }
	}

    private void RotateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.rotation = rotation;
        transform.position = position;
    }
}

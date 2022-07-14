using UnityEngine;
using System;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        Buttons,
        VR
    };

    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        //public GameObject handleModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    public ControlMode control;

    [SerializeField] float acceleration = 300f;
    [SerializeField] float maxAcceleration = 30.0f;
    [SerializeField] float brakeAcceleration = 50.0f;

    [SerializeField] float turnSensitivity = 1.0f;
    [SerializeField] float maxSteerAngle = 45.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody carRb;
    Vector3 m_EulerAngleVelocity;

    public HandleBreak bicycleHandleBreak;

    [SerializeField]
    float eulerAngZ;

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;

    }

    private void FixedUpdate()
    {
        eulerAngZ = transform.eulerAngles.z;
        if (transform.eulerAngles.z < 355 && transform.eulerAngles.z > 180)
        {
            m_EulerAngleVelocity = new Vector3(0, 0, 20);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
            carRb.MoveRotation(carRb.rotation * deltaRotation);
            //Debug.Log("<-2");
        }

        if (transform.eulerAngles.z > 5 && transform.eulerAngles.z < 180)
        {
            m_EulerAngleVelocity = new Vector3(0, 0, -20);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
            carRb.MoveRotation(carRb.rotation * deltaRotation);
            //Debug.Log(">2");
        }
    }
    void Update()
    {
        GetInputs();
        AnimateWheels();
    }

    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    public void MoveInput(float input)
    {
        moveInput = input;
    }

    public void SteerInput(float input)
    {
        steerInput = input;
    }

    void GetInputs()
    {
        if (control == ControlMode.Keyboard)
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }
        if (control == ControlMode.VR)
        {
            moveInput = MotionInput.GetAverageHandSpeed();
            steerInput = bicycleHandle.GetTurnedAngle();
        }
    }

    void Move()
    {
        foreach (var wheel in wheels)
        {
            if (control == ControlMode.VR)
                wheel.wheelCollider.motorTorque = moveInput * acceleration * maxAcceleration * Time.deltaTime;
            else
                wheel.wheelCollider.motorTorque = moveInput * acceleration * 2  * maxAcceleration * Time.deltaTime;
            carRb.velocity = Vector3.ClampMagnitude(carRb.velocity, maxAcceleration);
        }
    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                if (control == ControlMode.VR)
                {
                    wheel.wheelCollider.steerAngle = steerInput;
                }
                else 
                {                    
                    var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                    wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
                }
                
            }
        }
    }

    void Brake()
    {
        if (bicycleHandleBreak.breakBicycle)
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }
        }
        else if (moveInput == 0)
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 30 * brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
            wheel.wheelModel.transform.rotation *= Quaternion.Euler(0, -90, 0);
            //wheel.handleModel.transform.rotation = rot;
            //wheel.handleModel.transform.rotation *= Quaternion.Euler(0, 90, 0);
            //wheel.handleModel.transform.eulerAngles = new Vector3(wheel.handleModel.transform.eulerAngles.x, wheel.handleModel.transform.eulerAngles.y, 0);
        }
    }
}
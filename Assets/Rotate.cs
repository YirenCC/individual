using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    Rigidbody m_rigidBody;
    public Vector3 Torque;
	// Use this for initialization
	void Start ()
    {
        m_rigidBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void FixedUpdate()
    {
        m_rigidBody.AddTorque(Torque);
    }
}

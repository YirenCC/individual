using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotateAround : MonoBehaviour {

    // Use this for initialization
   
    public Text m_GUI;
    public string m_name;
    public float Angle;
    Transform target;
    Rigidbody m_RigidBody;
 

	void Start ()
    {
        target = GameObject.Find("Sun").transform;
        m_RigidBody = GetComponent<Rigidbody>();
        m_GUI.text = "GUI";
	}
	
	// Update is called once per frame
    void OnMouseDown() 
    {
        m_GUI.text = m_name;
    }

	void Update ()
    {
        transform.RotateAround(target.position, Vector3.up, Angle * Time.deltaTime);
    }

    void FixedUpdate()
    {
        m_RigidBody.AddTorque(0,5,0);
    }
}

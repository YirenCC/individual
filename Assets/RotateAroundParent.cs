using UnityEngine;
using System.Collections;

public class RotateAroundParent : MonoBehaviour
{
   public float Angle;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(gameObject.transform.parent.transform.position, Vector3.up, Angle * Time.deltaTime);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Sun : MonoBehaviour
{
    public Text m_GUI;
    // Use this for initialization
    void Start()
    {

    }
    void OnMouseDown() 
    {
        m_GUI.text = "Sun";
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,10,0));
    }
}

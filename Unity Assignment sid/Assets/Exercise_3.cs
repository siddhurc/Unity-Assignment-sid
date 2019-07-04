using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise_3 : MonoBehaviour
{
    // Start is called before the first frame update


    private void Awake()
    {
        Debug.Log("Welcome");
    }
    private void OnEnable()
    {
        Debug.Log("to");
    }
    void Start()
    {
        Debug.Log("Freshers");
    }
    private void FixedUpdate()
    {
        Debug.Log("from");
    }
    private void Update()
    {
        Debug.Log("Rythmos");
    }
    private void LateUpdate()
    {
        Debug.Log("Family");
    }
}

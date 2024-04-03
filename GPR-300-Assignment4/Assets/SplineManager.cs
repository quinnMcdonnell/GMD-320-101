using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SplineManager : MonoBehaviour
{
    public curves[] beziers;
    public GameObject character;

    public int uMax;
    public int u = 0;


    // Start is called before the first frame update
    void Start()
    {
        uMax = beziers.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //character.transform.position = 
    }

}

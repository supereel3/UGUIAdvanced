using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamere : MonoBehaviour
{
    public Camera target;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(target.transform.forward);
    }
}

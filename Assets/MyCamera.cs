using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public GameObject target;

    private void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(
            target.transform.position.x,
            target.transform.position.y,
            gameObject.transform.position.z);
    }

}

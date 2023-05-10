using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject character;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = character.transform.position.x;
        transform.position = position;
    }
}

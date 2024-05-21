using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmaeraFoliow : MonoBehaviour
{
    [SerializeField] Transform _targetPosition;
    [SerializeField] Vector3 _offset;
    void Update()
    {
        transform.position = _targetPosition.transform.position + _offset;
        transform.LookAt(transform.position);
    }
}

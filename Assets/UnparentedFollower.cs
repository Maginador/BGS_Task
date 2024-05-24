using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentedFollower : MonoBehaviour
{

    [SerializeField] bool startEnabled;
    private Transform target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
       target = transform.parent;
       offset = transform.localPosition;
       transform.parent = null;
       gameObject.SetActive(startEnabled);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorConnection : MonoBehaviour
{
    public bool Connected { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Connected)
        {
            // TODO: Make some visual cue that this is connected
        }
    }

    void OnMouseDown()
    {
        Connected = true;
    }

    void OnMouseUp()
    {
        Connected = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject anchors;

    GameObject connectedAnchor;
    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!connectedAnchor || !connectedAnchor.GetComponent<AnchorConnection>().Connected)
        {
            foreach (Transform anchorTransform in anchors.transform)
            {
                AnchorConnection anchorConnection = anchorTransform.gameObject.GetComponent<AnchorConnection>();
                if (anchorConnection.Connected)
                {
                    connectedAnchor = anchorTransform.gameObject;
                    break;
                }
            }
        }

        if (connectedAnchor)
        {
            AnchorConnection anchorConnection = connectedAnchor.GetComponent<AnchorConnection>();

            if (anchorConnection.Connected)
            {
                Vector3 oldPosition = transform.position;
                transform.RotateAround(connectedAnchor.transform.position, new Vector3(0, 0, 1), 90 * Time.deltaTime);
                // TODO: Let's try the average of the last 10 updates instead.
                velocity = (oldPosition - transform.position) / Time.deltaTime;
            }
            else
            {
                connectedAnchor = null;
            }
        }

        if (!connectedAnchor)
        {
            transform.Translate(velocity * Time.deltaTime);
        }
    }
}

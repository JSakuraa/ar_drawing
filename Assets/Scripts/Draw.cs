using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject spacePenPoint;
    public GameObject surfacePenPoint;

    public GameObject handPenPoint;
    public GameObject stroke;
    public bool mouseLookTesting;

    [HideInInspector]
    public Transform penPoint;

    public static bool drawing = false;

    private float pitch = 0;
    private float yaw = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mouseLookTesting)
        {
            yaw += 2 * Input.GetAxis("Mouse X");
            pitch -= 2 * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        if (PenManager.drawingOnSurface)
        {
            penPoint = surfacePenPoint.transform;

            surfacePenPoint.GetComponent<MeshRenderer>().enabled = true;
            spacePenPoint.GetComponent<MeshRenderer>().enabled = false;
            handPenPoint.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (PenManager.drawingWithHand)
        {
            penPoint = handPenPoint.transform;

            surfacePenPoint.GetComponent<MeshRenderer>().enabled = false;
            spacePenPoint.GetComponent<MeshRenderer>().enabled = false;
            handPenPoint.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            penPoint = handPenPoint.transform;

            surfacePenPoint.GetComponent<MeshRenderer>().enabled = false;
            spacePenPoint.GetComponent<MeshRenderer>().enabled = true;
            handPenPoint.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void StartStroke()
    {
        GameObject currentStroke;
        drawing = true;
        currentStroke = Instantiate(stroke, spacePenPoint.transform.position, spacePenPoint.transform.rotation) as GameObject;
    }

    public void EndStroke()
    {
        drawing = false;
    }

}

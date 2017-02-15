using UnityEngine;

public class CameraController : MonoBehaviour {

    public float PanSpeed = 30f;
    public float PanBorderThickness = 50f;
    public float ScrollSpeed = 5f;
    public float MinY = 10f;
    public float MaxY = 80f;

    private bool doMovement = true;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
        {
            return;
        }

        var speed = PanSpeed * Time.deltaTime;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - PanBorderThickness)
        {
            transform.Translate(Vector3.forward * speed, Space.World);
        } else if (Input.GetKey("s") || Input.mousePosition.y <= PanBorderThickness)
        {
            transform.Translate(Vector3.back * speed, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - PanBorderThickness)
        {
            transform.Translate(Vector3.right * speed, Space.World);
        }
        else if (Input.GetKey("a") || Input.mousePosition.x <= PanBorderThickness)
        {
            transform.Translate(Vector3.left * speed, Space.World);
        }

        var scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= scroll * ScrollSpeed * Time.deltaTime * 1000;

        position.y = Mathf.Clamp(position.y, MinY, MaxY);
        transform.position = position;
    }
}

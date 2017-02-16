using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color HoverColor;
    private Vector3 Offset = new Vector3(0, 0.5f, 0);

    private Material material;
    private Color originalColor;
    private GameObject turret;
    private BuildManager buildManager;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        buildManager = BuildManager.Instance;
        originalColor = material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        var turretToBuild = buildManager.GetTurretToBuild();
        if (turretToBuild == null)
        {
            Debug.Log("No turret to build");
            return;
        }

        if (turret != null)
        {
            Debug.Log("Already there");
            return;
        }

        turret = Instantiate(turretToBuild, transform.position + Offset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        var turretToBuild = buildManager.GetTurretToBuild();
        if (turretToBuild == null)
        {
            return;
        }
        originalColor = material.color;
        material.color = HoverColor;
    }

    private void OnMouseExit()
    {
        material.color = originalColor;
    }
}

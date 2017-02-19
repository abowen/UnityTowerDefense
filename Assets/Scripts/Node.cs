using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color HoverColor;
    private Vector3 offset = new Vector3(0, 0.5f, 0);

    private Material material;
    private Color originalColor;

    [Header("Optional")]
    public GameObject Turret;
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

        
        if (!buildManager.CanBuild)
        {
            Debug.Log("Can't build");
            return;
        }

        if (Turret != null)
        {
            Debug.Log("Already there");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
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

    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }
}

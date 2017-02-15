using UnityEngine;

public class Node : MonoBehaviour {

    public Color HoverColor;
    private Vector3 Offset = new Vector3(0, 0.5f, 0);

    private Material material;
    private Color originalColor;
    private GameObject turret;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Already there");
            return;
        }

        var turretToBuild = BuildManager.Instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + Offset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        originalColor = material.color;
        material.color = HoverColor;
    }

    private void OnMouseExit()
    {
        material.color = originalColor;
    }
}

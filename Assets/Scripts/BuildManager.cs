using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager Instance;

    public GameObject StandardTurretPrefab;

    private GameObject turretToBuild;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        turretToBuild = StandardTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}

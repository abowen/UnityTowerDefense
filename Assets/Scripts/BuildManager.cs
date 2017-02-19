using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager Instance;

    public GameObject StandardTurretPrefab;
    public GameObject MissileLauncherPrefab;

    private TurretBlueprint turretToBuild;

    private void Awake()
    {
        Instance = this;
    }

    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
    }

    public void BuildTurretOn(Node node)
    {
        Debug.Log("Money: " + PlayerStats.Money);
        if (PlayerStats.Money < turretToBuild.Cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        var turret = Instantiate(turretToBuild.Prefab, node.GetBuildPosition(), Quaternion.identity);
        node.Turret = turret;
        PlayerStats.Money -= turretToBuild.Cost;
    }
}
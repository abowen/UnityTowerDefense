using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint StandardTurret;
    public TurretBlueprint MissileLauncher;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(StandardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Purchased");
        buildManager.SelectTurretToBuild(MissileLauncher);
    }
}

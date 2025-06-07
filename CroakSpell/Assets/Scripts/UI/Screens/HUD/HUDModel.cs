using UnityEngine;

public class HUDModel : UIModel
{
    private PlayerStats playerStats;

    //evita crear un playerstats falso
    public void SetPlayerStats(PlayerStats stats)
    {
        playerStats = stats;
    }

    protected override void Initialize()
    {
        if (playerStats == null) 
        {
            Debug.Log("[HUDModel] PlayerStats no fue asignado");
            return;
        }

        var view = GetView() as HUDView;
        controller = new HUDController(view, true, playerStats);
        controller.Show();
    }
}

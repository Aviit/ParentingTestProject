using FishNet.Connection;
using FishNet.Managing.Timing;
using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class PlayerScript : NetworkBehaviour
{
    NetworkObject networkObject;

    public override void OnStartClient()
    {
        networkObject = GetComponent<NetworkObject>();
        LoadPlayerDataAndSetUpPlayer();

        ChangeCurrentArea(GameManager.Instance.GetStartingArea());
    }

    void LoadPlayerDataAndSetUpPlayer()
    {
        if (IsOwner)
        {
            //string playerUserName;
            //bool isAdmin;
            //string playerScreenname;
            //SQLAuthentication sqlAuthentication = FindObjectOfType<SQLAuthentication>();
            //if (sqlAuthentication != null)
            //{
            //    playerUserName = sqlAuthentication.GetPlayerUserName();
            //    isAdmin = sqlAuthentication.IsPlayerAdmin();
            //    playerScreenname = sqlAuthentication.GetScreenName();
            //}
            //else
            //{
            //    playerUserName = "not set";
            //    isAdmin = false;
            //    playerScreenname = "not set";
            //}

            //ServerRpcSetPlayerStats(playerUserName, playerScreenname, isAdmin);
        }

        LocalSetUpPlayer();

    }

    private void LocalSetUpPlayer()
    {
        //if (aiPath != null) aiPath.enabled = base.IsOwner;


        //playerVisualController.HidePlayerVisual(networkIsAdmin.Value); //if this is admin, hide the player character

        //playerVisualController.HighLightPlayer(base.IsOwner); //if this is local player AND is NOT an admin, show the player highlight object

        //GameManager.Instance.LocalPlayerSpawned();
    }
    public void ChangeCurrentArea(EnterableArea area)
    {
        //ServerRpcChangeCurrentArea(this, area);

        //if (currentVehicle.Value == null) //if player is NOT in a vehicle, change the player parent
        {
            ChangeParent(area.GetComponent<NetworkObject>());
        }
    }

    //[ServerRpc(RequireOwnership = false)] //kukaan ei omista t‰t‰, mutta clientien pit‰‰ p‰‰st‰ k‰ytt‰m‰‰n t‰t‰, siksi false
    //private void ServerRpcChangeCurrentArea(PlayerScript script, EnterableArea newArea, NetworkConnection sender = null)
    //{
    //    script.networkCurrentArea.Value = newArea;
    //}

    void ChangeParent(NetworkObject newParentNOB)
    {

        if (networkObject == null) networkObject = GetComponent<NetworkObject>();
        if (newParentNOB == null)
        {
            Debug.LogError("Trying to parent player to a null networkobject");
            return;
        }
        networkObject.SetParent(newParentNOB);
    }


}

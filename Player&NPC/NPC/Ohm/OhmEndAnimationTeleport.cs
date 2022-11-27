using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhmEndAnimationTeleport : MonoBehaviour
{
    [SerializeField]OhmTeleport ohmTeleportScript;
    public void EndTeleportAnimation()
    {
        GameManager.Instance.TeleportOhmAray[ohmTeleportScript.numberIndexTeleport] = true;
        Player.Instance._speed = Player.Instance._speed + ohmTeleportScript.speedPlayReduction;
        Destroy(ohmTeleportScript.OhmTeleportObj);
    }
}

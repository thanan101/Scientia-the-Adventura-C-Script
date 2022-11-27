using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhmTeleport : MonoBehaviour
{
    OhmAnimationStandAlone ohmAnimation;
    public int numberIndexTeleport;
    [SerializeField] public GameObject OhmTeleportObj;
    public float speedPlayReduction=8.5f;
    private void Start()
    {
        ohmAnimation = GetComponentInParent<OhmAnimationStandAlone>();
        StartCoroutine(DelayCheack());

    }
    IEnumerator DelayCheack()
    {
        yield return new WaitForEndOfFrame();
        if (GameManager.Instance.TeleportOhmAray[numberIndexTeleport] == true)
            Destroy(OhmTeleportObj);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.Instance._speed = Player.Instance._speed -speedPlayReduction;
            SoundFxManager.Instance.BlinkFx();
            ohmAnimation.PlayAnimationTeleport();
        }
    }
}

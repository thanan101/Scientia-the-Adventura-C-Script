using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public void PlayerRespondEnemyAttack()
    {
        Player.Instance.PlayeDieAnimation();
        SoundFxManager.Instance.HitByEnemy();
    }
    public void RobotFx()
    {
        Debug.Log("i'mRun!!");
        SoundFxManager.Instance.RobotFx();
    }
}

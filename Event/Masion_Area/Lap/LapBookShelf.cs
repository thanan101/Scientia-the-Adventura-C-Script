using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapBookShelf : MonoBehaviour
{
    [SerializeField] BoxCollider2D switchBoxCollider2D;
    [SerializeField] Animator bookShelfAnimator;
    [SerializeField] BoxCollider2D bookShelfBoxCollider;
    [SerializeField] public GameObject useSwitchText;
    [SerializeField] public GameObject secrectDoorisOpenText;
    [SerializeField] public GameObject bookShelfLight;
    [SerializeField] public GameObject bookShelfCamera;
    private void Start()
    {
        StartCoroutine(DelayCheck());
    }
    IEnumerator DelayCheck()
    {
        yield return new WaitForEndOfFrame();
        if (GameManager.Instance.useSwitchBookShelf == true)
        {
            bookShelfBoxCollider.enabled = false;
            bookShelfAnimator.SetTrigger("BookShelf");
        }
    }
    
   public void OpenShelf()
    {
        bookShelfCamera.SetActive(true);
        bookShelfLight.SetActive(true);
        bookShelfBoxCollider.enabled = false;
        bookShelfAnimator.SetTrigger("BookShelf");
        GameManager.Instance.useSwitchBookShelf = true;
        Player.Instance.PlayerCanNotMove();
        SoundFxManager.Instance.SecrectDoor();
    }
}

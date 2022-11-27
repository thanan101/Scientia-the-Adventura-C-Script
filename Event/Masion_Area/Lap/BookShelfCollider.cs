using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfCollider : MonoBehaviour
{
    LapBookShelf lapBookShelf;
    [SerializeField] float camTime=3f;
    void Start()
    {
        lapBookShelf = GetComponentInParent<LapBookShelf>();
    }
    private void OnTriggerEnter2D(Collider2D switchBoxCollider2D)
    {
        if (switchBoxCollider2D.tag == "Player")
            SreachIcon.Instance.OpenSreachIcon();
    }
    private void OnTriggerExit2D(Collider2D switchBoxCollider2D)
    {
        if (switchBoxCollider2D.tag == "Player")
            SreachIcon.Instance.CloseSreachIcon();
    }
    private void OnTriggerStay2D(Collider2D switchBoxCollider2D)
    {
        if (Input.GetKeyDown(KeyCode.F)&&switchBoxCollider2D.tag=="Player")
        {
            if (GameManager.Instance.useSwitchBookShelf == false)
                lapBookShelf.useSwitchText.SetActive(true);
            else if (GameManager.Instance.useSwitchBookShelf == true)
            {
                lapBookShelf.bookShelfCamera.SetActive(true);
                lapBookShelf.bookShelfLight.SetActive(true);
                StartCoroutine(HintLocation());
            }
                
        }
    }
    IEnumerator HintLocation()
    {
        yield return new WaitForSecondsRealtime(camTime);
        lapBookShelf.bookShelfLight.SetActive(false);
        lapBookShelf.bookShelfCamera.SetActive(false);
        lapBookShelf.secrectDoorisOpenText.SetActive(true);
    }
}

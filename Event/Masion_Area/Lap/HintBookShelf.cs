using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintBookShelf : MonoBehaviour
{
    [SerializeField] GameObject cameraHint;
    [SerializeField] GameObject hintText;
    [SerializeField] float timeDelay=3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameManager.Instance.useSwitchBookShelf == false)
            {
                Player.Instance.PlayerCanNotMove();
                StartCoroutine(CameraHint());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    IEnumerator CameraHint()
    {
        GameManager.Instance.EnableUIDisplay(false);
        cameraHint.SetActive(true);
        yield return new WaitForSecondsRealtime(timeDelay);
        cameraHint.SetActive(false);
        hintText.SetActive(true);
    }
}

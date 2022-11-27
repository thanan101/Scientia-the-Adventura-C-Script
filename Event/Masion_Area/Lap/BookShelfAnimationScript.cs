using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfAnimationScript : MonoBehaviour
{
    LapBookShelf lapBookShelf;
    void Start()
    {
        lapBookShelf = GetComponentInParent<LapBookShelf>();
    }
    public void EndShelfAnimation()
    {
        lapBookShelf.bookShelfCamera.SetActive(false);
        lapBookShelf.bookShelfLight.SetActive(false);
        Player.Instance.PlayerCanMove();
    }
}

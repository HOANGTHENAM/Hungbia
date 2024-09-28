using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class BackgroundChanger : MonoBehaviour
{
    private SpriteRenderer sprite
        ;
    private Sprite[] backgroundSprites;
    private int currentIndex = 0;
    public int intInterval = 2;
    

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        backgroundSprites = Resources.LoadAll<Sprite>("Sprite/BG");
    }

    void Update()
    {
        if (GameManager.Instance.SetScore() >= intInterval)
        {
            ChangeBG();
            intInterval += 2;
        }

    }
    private void ChangeBG()
    {
        if (currentIndex >= backgroundSprites.Length - 1)
        {
            currentIndex = -1;
        }
        currentIndex++;
        sprite.sprite = backgroundSprites[currentIndex];
    }
}

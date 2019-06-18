using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;
    public Image HeartUI;

    private Player player; //access variables in Player Script

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        HeartUI.sprite = HeartSprites[player.curHealth];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health_player : MonoBehaviour
{
    public TextMeshProUGUI HP;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        HP.text = player.GetComponent<Player_move>().player_health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = player.GetComponent<Player_move>().player_health.ToString();
    }
}

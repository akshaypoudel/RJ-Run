using UnityEngine;
using TMPro;
public class HighScoreTExt : MonoBehaviour
{ 
    private TMP_Text text;
    public GameObject Player;
    private double speed;
    [SerializeField]
    private double speedController;
    void Start()
    {
        text=GetComponent<TMP_Text>();
        speed=0;
    }

    void FixedUpdate()
    {
        if(Player.GetComponent<PlayerController>().isActiveAndEnabled)
        {
            text.text=((long)speed).ToString();
            speed+=speedController;
        }
    }
}

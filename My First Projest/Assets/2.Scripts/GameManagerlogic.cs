using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerlogic : MonoBehaviour
{
    public int TotalScorce;
    public int Stage;
    public Text stageCountText;
    public Text playerCountText;

    private void Awake()
    {
        stageCountText.text = "/" + TotalScorce;
    }

    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();
    }
}

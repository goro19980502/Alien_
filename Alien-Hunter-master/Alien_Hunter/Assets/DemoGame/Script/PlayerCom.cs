using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCom : MonoBehaviour
{
    public Image Blood;

    private Color DestColor = new Color(1, 1, 1, 0);

    private void Update()
    {
        Blood.color = Color.Lerp(Blood.color, DestColor, .01f);
    }

    public void OnDamage()
    {
        Color tmpCol = Blood.color;
        tmpCol.a = 1;
        Blood.color = tmpCol;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class records : MonoBehaviour
{
    public Text st1;
    public Text nd2;
    public Text rd3;

    public void resetRecord()
    {
        PlayerPrefs.DeleteAll();
        st1.text = PlayerPrefs.GetFloat("st1").ToString("0.0#");
        nd2.text = PlayerPrefs.GetFloat("nd2").ToString("0.0#");
        rd3.text = PlayerPrefs.GetFloat("rd3").ToString("0.0#");
    }
    public void showRec()
    {
        st1.text = PlayerPrefs.GetFloat("st1").ToString("0.0#");
        nd2.text = PlayerPrefs.GetFloat("nd2").ToString("0.0#");
        rd3.text = PlayerPrefs.GetFloat("rd3").ToString("0.0#");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangeLevel : MonoBehaviour
{
    public string targetLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Players")
        {
            SaveStuff();
            SwitchLevel(false, targetLevel);
            PlayerPrefs.SetString("Level", targetLevel);
        }
    }

    static public void SwitchLevel(bool restartCurrent, string level = "")
    {
        if (restartCurrent)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            SceneManager.LoadScene(level);
    }

    public void SaveStuff()
    {
        PlayerControls pc = FindObjectOfType<PlayerControls>();
        PlayerPrefs.SetFloat("Adrenaline", Camera.main.GetComponentInChildren<Slider>().value);
        PlayerPrefs.SetFloat("Health", pc.GetComponentInChildren<Slider>().value);
        PlayerPrefs.SetInt("HasObject1", 4738);//where 4738 is the ID for an item
        PlayerPrefs.Save();
    }
}

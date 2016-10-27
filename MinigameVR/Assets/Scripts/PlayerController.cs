using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private int count;
    private int total;
    public Text countText;
    public Text winText;
    public AudioSource audio;

    void Start()
    {
        total = GameObject.FindGameObjectsWithTag("Collectible").Length;
        winText.gameObject.SetActive(false);
        count = 0;
        SetCountText();
        VRSettings.renderScale = 1.0f;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            audio.Play();
            count++;
            SetCountText();
            if(count >= total)
            {
                winText.gameObject.SetActive(true);
            }
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + "/" + total.ToString();
    }
}

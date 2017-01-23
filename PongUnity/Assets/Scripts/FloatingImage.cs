using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FloatingImage : MonoBehaviour {

    public GameObject spinner;
    private RectTransform spinner_pos;
    public GameObject loading_text;
    private Text load_text;
    public GameObject image_frame;
    private Image image_img;
    private RectTransform img_pos;

    public Sprite[] floating_images;
    private int timer;
    private int image_timer;
    private int loading_scene;


    // Use this for initialization
    void Start () {
        timer = 300;
        image_timer = 180;
        loading_scene = 2;

        spinner_pos = spinner.GetComponent<RectTransform>();
        load_text = loading_text.GetComponent<Text>();
        image_img = image_frame.GetComponent<Image>();
        img_pos = image_frame.GetComponent<RectTransform>();

        Sprite newsprite = floating_images[Random.Range(0, floating_images.Length)];
        image_img.sprite = newsprite;
        image_img.color = new Color(1, 1, 1, 1.0f - ((float)image_timer / 180.0f));
    }
	
	// Update is called once per frame
	void Update () {
        image_img.color = new Color(1, 1, 1, 1.0f - ((float)image_timer / 180.0f));
        img_pos.position += new Vector3(0,0.1f,0);
        timer--;
        image_timer--;
        spinner_pos.Rotate(new Vector3(0, 0, 1));

        load_text.text = "Loading";
        for (int i = 0; i < 3-(image_timer / 30) % 3; i++) {
            load_text.text += ".";
        }


       
        
        if (image_timer <= 0)
        {
            image_timer = 180;
            Sprite newsprite = floating_images[Random.Range(0, floating_images.Length)];
            image_img.sprite = newsprite;
            image_img.color = new Color(1, 1, 1, 1.0f - ((float)image_timer / 180.0f));
        }
        if (timer == 0) {
            SceneManager.LoadScene(loading_scene);
        }
	}
}

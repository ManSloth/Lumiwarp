using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour {

    /*Animation Types:
        0=Shiny button (quit)
        1=particle animation
    */

    public Sprite image0, image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, image11, image12;
    float elapsed;
    public float speed;
    public ArrayList pics;
    public int curFrame;
    public int animationType;
    public bool startParticle;
    int loginState; public int flashCount;
    public int loginSuccess;

    public Button tandemButton;
    public Image tandemImage;
	// Use this for initialization
	void Start () {
        loginSuccess = 0;
        loginState = 1;
        flashCount = 0;
        startParticle = false;
        elapsed = 0;
        //speed = 0.1f;
        pics = new ArrayList();

        if(image0 !=null)
            pics.Add(image0);
        if(image1 != null)
            pics.Add(image1);
        if(image2 != null)
            pics.Add(image2);
        if(image3 != null)
            pics.Add(image3);
        if(image4 != null)
            pics.Add(image4);
        if(image5 != null)
            pics.Add(image5);
        if(image6 != null)
            pics.Add(image6);
        if(image7 != null)
            pics.Add(image7);
        if (image8 != null)
            pics.Add(image8);
        if (image9 != null)
            pics.Add(image9);
        if (image10 != null)
            pics.Add(image10);
        if (image11 != null)
            pics.Add(image11);
        if (image12 != null)
            pics.Add(image12);

        //curFrame = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (animationType == 0)
            QuitAnimation();
        else if (animationType == 1)
            ParticleAnimation();
        else if (animationType == 3)
            ConstantAnimation();
        else if (animationType == 4)
            TandemAnimation();
        else if (animationType == 5)
            Login();
        else if (animationType == 6)
            TandemImage();

        ParticleAnimation();

    }

    void QuitAnimation()
    {
        elapsed += Time.unscaledDeltaTime;
        if (curFrame == 0)
        {
            if (elapsed >= speed * 10)
            {
                curFrame++;
                transform.gameObject.GetComponent<Image>().sprite = (Sprite)pics[curFrame];
                elapsed = 0;
            }
        }
        else
        {
            if (elapsed >= speed)
            {
                curFrame++;
                if (curFrame >= pics.Count)
                    curFrame = 0;
                transform.gameObject.GetComponent<Image>().sprite = (Sprite)pics[curFrame];
                elapsed = 0;
            }
        }
    }

    void ParticleAnimation()
    {
        if (startParticle)
        {
            elapsed += Time.unscaledDeltaTime;
            if (elapsed >= speed)
            {
                curFrame++;
                if (curFrame >= pics.Count)
                {
                    curFrame = 0;
                    startParticle = false;
                }
                transform.gameObject.GetComponent<Image>().sprite = (Sprite)pics[curFrame];
                elapsed = 0;
            }
        }
    }

    public void StartParticle()
    {
        startParticle = true;
    }

    void ConstantAnimation()
    {
        elapsed += Time.unscaledDeltaTime;
        if (elapsed >= speed)
        {
            curFrame++;
            if (curFrame >= pics.Count)
                curFrame = 0;
            transform.gameObject.GetComponent<Image>().sprite = (Sprite)pics[curFrame];
            elapsed = 0;
        }
    }
    
    void TandemAnimation()
    {
        if(tandemButton.GetComponent<SpriteAnimation>().curFrame == tandemButton.GetComponent<SpriteAnimation>().pics.Count-2)
        {
            StartParticle();
        }
    }

    void TandemImage()
    {
        if (tandemImage.GetComponent<SpriteAnimation>().curFrame == tandemImage.GetComponent<SpriteAnimation>().pics.Count - 2)
        {
            StartParticle();
        }
    }

    void Login()
    {
        if (loginSuccess == 0)
        {
            elapsed += Time.unscaledDeltaTime;
            if (loginState == 0)
            {
                if (elapsed >= speed * 0.75f)
                {
                    curFrame++;
                    if (curFrame >= pics.Count - 3)
                    {
                        loginState = 1;
                        curFrame = 0;
                    }
                    transform.gameObject.GetComponent<Image>().sprite = (Sprite)pics[curFrame];
                    elapsed = 0;
                }
            }
            else
            {
                if (elapsed >= speed)
                {
                    flashCount++;
                    if (curFrame == 0)
                        curFrame = pics.Count - 3;
                    else
                        curFrame = 0;
                    transform.gameObject.GetComponent<Image>().sprite = (Sprite)pics[curFrame];
                    elapsed = 0;
                    if (flashCount >= 4)
                    {
                        loginState = 0;
                        curFrame = 0;
                        flashCount = 0;
                    }
                }
            }
        }
        else if(loginSuccess ==1)
        {
            transform.gameObject.GetComponent<Image>().sprite = (Sprite)pics[7];
        }
        else if(loginSuccess ==2)
        {
            transform.gameObject.GetComponent<Image>().sprite = (Sprite)pics[8];
        }
        
    }
}

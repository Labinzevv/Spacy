using UnityEngine;
using UnityEngine.UI;

public class shipDamageAndScore : MonoBehaviour
{
    public GameObject smash;
    public Text scoreText;
    public float score;
    public laserBlue shootBlue;
    public laserRed shootRed;
    float st1Float;
    float nd2Float;
    float rd3Float;
    public CanvasGroup leftButton;
    public CanvasGroup rightButton;
    public ParticleSystem smashPlay;

    void Awake()
    {
        smashPlay.Stop();
    }

    public void Update()
    {
        score += Time.deltaTime;
        scoreText.text = score.ToString("0.0" + "\n" + " LIGHT YEARS LATER");

        st1Float = PlayerPrefs.GetFloat("st1");
        nd2Float = PlayerPrefs.GetFloat("nd2");
        rd3Float = PlayerPrefs.GetFloat("rd3");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            leftButton.alpha -= 0.35f;
            rightButton.alpha -= 0.35f;
            smashPlay.Play();

            if (leftButton.alpha == 0)
            {
                //1 место
                if (score > rd3Float
                && score > nd2Float
                && score > st1Float)
                {
                    PlayerPrefs.SetFloat("st1", score);
                }

                //2 место
                if (score > rd3Float
                   && score > nd2Float
                   && score < st1Float)
                {
                    PlayerPrefs.SetFloat("nd2", score);
                }

                //3 место
                if (score > rd3Float
                   && score < nd2Float
                   && score < st1Float)
                {
                    PlayerPrefs.SetFloat("rd3", score);
                }

                Destroy(gameObject, 0.3f);
            }
        }
        if (other.gameObject.tag == "stone")
        {
            leftButton.alpha -= 0.35f;
            rightButton.alpha -= 0.35f;
            smashPlay.Play();

            if (leftButton.alpha == 0)
            {
                //1 место
                if (score > rd3Float
                   && score > nd2Float
                   && score > st1Float)
                {
                    PlayerPrefs.SetFloat("st1", score);
                }

                //2 место
                if (score > rd3Float
                   && score > nd2Float
                   && score < st1Float)
                {
                    PlayerPrefs.SetFloat("nd2", score);
                }

                //3 место
                if (score > rd3Float
                   && score < nd2Float
                   && score < st1Float)
                {
                    PlayerPrefs.SetFloat("rd3", score);
                }

                Destroy(gameObject, 0.3f);
            } 
        }
        if (other.gameObject.tag == "lives")
        {
            if (leftButton.alpha < 1)
            {
                leftButton.alpha += 0.35f;
                rightButton.alpha += 0.35f;
            }
        }
        if (other.gameObject.tag == "bonusShootBlue")
        {
            if (shootBlue.shootBlue < 1)
            {
                shootBlue.shootBlue += 0.24f;
            }
        }
        if (other.gameObject.tag == "bonusShootRed")
        {
            if (shootRed.shootRed < 1)
            {
                shootBlue.shootBlue += 0.25f;
            }
        }
    }
}

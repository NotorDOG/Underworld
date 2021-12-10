using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControls : MonoBehaviour
{
    public float speed = 3;
    public float jumpPower = 10;
    public bool isInvincible = false;
    public float timeInvincible = 3.0f;
    public float reloadTime = .5f;
    
    public int ammunitionAmount = 5;
    public bool canShoot = true;

    public GameObject bullet;
    Rigidbody2D rb;
    Adrenaline adr;
    Animator anim;
    AudioSource sound;

    void Start()
    {
        PlayerPrefs.SetString("Level", SceneManager.GetActiveScene().name);
        rb = GetComponent<Rigidbody2D>();
        adr = GetComponentInChildren<Adrenaline>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("Health") && PlayerPrefs.HasKey("Adrenaline"))
        {
            Camera.main.GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("Adrenaline");
            GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("Health");
        }
        
            
        
    }
    void FixedUpdate()
    {

        if (Input.GetAxis("Pause") == 1)
        {
        Time.timeScale = 0.0f;   
        }
        if(Input.GetAxis("Cancel") == 1)
        {
            PlayerPrefs.SetFloat("Adrenaline", Camera.main.GetComponentInChildren<Slider>().value);
            PlayerPrefs.SetFloat("Health", GetComponentInChildren<Slider>().value);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
        if(canShoot && Input.GetAxis("Fire1") == 1 && Camera.main.GetComponentInChildren<Slider>().value > ammunitionAmount)
        {
            StartCoroutine(ShootandReload());
        }
        float horizontalMovement = Input.GetAxis("Horizontal");
        //rb.velocity.x = speed * horizontalMovement;//not allowed
        rb.velocity = new Vector2(speed * horizontalMovement, rb.velocity.y);
        bool isJumping = Input.GetAxis("Jump") > 0;

       
        //Jump Method 3: Correct way.
        if (isJumping)//if pressing the spacebar/trying to jump
        {
            
            //Check if the feet are colliding with something right now
            Vector3 feetPosition = transform.GetChild(0).position;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feetPosition, .25f);
            
            for (int i = 0; i < colliders.Length; ++i)
            {
                if (colliders[i].gameObject == gameObject || colliders[i].gameObject.name == "AdrenalineCollider" || colliders[i].gameObject.tag == "BadProj" || colliders[i].gameObject.tag == "Health")
                {
                    continue;
                }
                //make each jump consistently the same speed/height
                
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpPower);
                
                break;
            }
            
        }

        if (rb.velocity.magnitude > .01f)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);

        if (GetComponentInChildren<Slider>().value <= 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
    public void becomeInvincible()
    {
        StartCoroutine(RevertHittable());
    }
    IEnumerator RevertHittable()
    {
        isInvincible = true;
        yield return new WaitForSeconds(timeInvincible);
        isInvincible = false;
    }
    IEnumerator ShootandReload()
    {
        canShoot = false;
        adr.setAdrenaline(-10);
        sound.Play();
        Instantiate(bullet, transform.GetChild(4).position, transform.rotation);
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }
}

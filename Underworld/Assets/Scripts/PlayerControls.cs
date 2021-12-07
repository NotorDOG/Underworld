using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public float speed = 3;
    public float jumpPower = 10;
    public bool isInvincible = false;
    public float timeInvincible = 3.0f;
    public GameObject bullet; 
    Rigidbody2D rb;
    public int ammunitionAmount = 5;
    public bool canShoot = true;
    Adrenaline adr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        adr = GetComponentInChildren<Adrenaline>();
    }
    void FixedUpdate()
    {

        if (Input.GetAxis("Pause") == 1)
        {
        Time.timeScale = 0.0f;   
        }
        if(Input.GetAxis("Cancel") == 1)
        {
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
        Instantiate(bullet, transform.GetChild(4).position, transform.rotation);
        yield return new WaitForSeconds(.3f);
        canShoot = true;
    }
}

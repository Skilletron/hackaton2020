using UnityEngine;
using System.Collections;

public class BossControl : MonoBehaviour
{

	public enum ProjectAxis { onlyX = 0, xAndY = 1 };
	public ProjectAxis projectAxis = ProjectAxis.onlyX;
	public float speed = 150;
	public float addForce = 7;
	public bool isFacingRight = true;
	public AudioClip clip_pistol,clip_revolver,clip_ak;
	private Vector3 direction;
	private bool visibility = false;
	private float vertical;
	private float horizontal;
	private Rigidbody2D body;
	  public Transform addParent;
	  public GameObject Audio;
	public GameObject firePoint;
	public GameObject bullet;
	public int health;
	
    Animator animator;
	public GameObject Player;
    public GameObject Bot;
	private float timeBtwShots;
	public float startTimeBtwShots;
	void Start()
	{
		
		body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
		Player = GameObject.Find("Terrain/Player");
		Audio = GameObject.Find("ScriptHolder");
		addParent = GameObject.Find("Terrain/Bullets").transform;
		if (projectAxis == ProjectAxis.xAndY)
		{
			body.gravityScale = 0;
			body.drag = 10;
		}
	}


	
	public void TakeDamage(int damage) {
		health -= damage;
	}

	 void Shoot() {
		Audio.GetComponent<AudioSource>().PlayOneShot(clip_ak);
		GameObject kek = Instantiate(bullet, firePoint.transform.position, transform.rotation);
      	kek.transform.SetParent(addParent,true);
        
    }
	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed);

		if (Mathf.Abs(body.velocity.x) > speed / 100f)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
		}

		if (projectAxis == ProjectAxis.xAndY)
		{
			if (Mathf.Abs(body.velocity.y) > speed / 100f)
			{
				body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed / 100f);
			}
		}
	}

	void Flip()
	{
		if (projectAxis == ProjectAxis.onlyX)
		{
			isFacingRight = !isFacingRight;
			transform.Rotate(0,180f,0);
		}
	}

	void Update()
	{
		
        if(visibility) {
			if( ((Player.transform.position.x - Bot.transform.position.x) < 2f) &&  ((Player.transform.position.x - Bot.transform.position.x) > 0.6f) && ( ((Player.transform.position.y - Bot.transform.position.y) < 1f) && ((Bot.transform.position.y - Player.transform.position.y) < 1.3f)) ) {
            horizontal = 1;
			animator.SetBool("isRun", true);
			
        }
        else if(((Bot.transform.position.x - Player.transform.position.x) < 2f) &&  ((Bot.transform.position.x - Player.transform.position.x) > 0.6f) && ( ((Player.transform.position.y - Bot.transform.position.y) < 1f) && ((Bot.transform.position.y - Player.transform.position.y) < 1.3f)) ){
            horizontal = -1;
			animator.SetBool("isRun", true);
			
        } else {
            horizontal = 0;
			animator.SetBool("isRun", false);
        }
		}

        else if( ((Player.transform.position.x - Bot.transform.position.x) < 2f) &&  ((Player.transform.position.x - Bot.transform.position.x) > 0.6f) && ( ((Player.transform.position.y - Bot.transform.position.y) < 0.5f) && ((Bot.transform.position.y - Player.transform.position.y) < 0.5f)) ) {
            horizontal = 1;
			visibility = true;
			animator.SetBool("isRun", true);
        }
        else if(((Bot.transform.position.x - Player.transform.position.x) < 2f) &&  ((Bot.transform.position.x - Player.transform.position.x) > 0.6f) && ( ((Player.transform.position.y - Bot.transform.position.y) < 0.5f) && ((Bot.transform.position.y - Player.transform.position.y) < 0.5f)) ){
            horizontal = -1;
			visibility = true;
			animator.SetBool("isRun", true);
        } else {
            horizontal = 0;
			animator.SetBool("isRun", false);
			
        }
		if( (Player.transform.position.y > Bot.transform.position.y)){
			vertical = 1;
		} else {
			vertical = 0;
		}
		if( (Player.transform.position.y > Bot.transform.position.y)){
			vertical = 1;
		} else {
			vertical = 0;
		}
		if(health <= 0) {
			Destroy(gameObject);
		}
		if( ((Bot.transform.position.y - Player.transform.position.y) < 0.2f) && ((Player.transform.position.y - Bot.transform.position.y) < 0.2f) && (Player.transform.position.x > Bot.transform.position.x) && ((Player.transform.position.x - Bot.transform.position.x) < 2f)){
			if( timeBtwShots <= 0){
		
            Shoot();
			timeBtwShots = startTimeBtwShots;
        
	} 
	else {
		timeBtwShots -= Time.deltaTime;
	}
		}
		else if(((Bot.transform.position.y - Player.transform.position.y) < 0.2f) && ((Player.transform.position.y - Bot.transform.position.y) < 0.2f) && (Player.transform.position.x > Bot.transform.position.x) && ((Player.transform.position.x - Bot.transform.position.x) < 2f)){
			if( timeBtwShots <= 0){
		
            Shoot();
			timeBtwShots = startTimeBtwShots;
        
	} 
	else {
		timeBtwShots -= Time.deltaTime;
	}
		}

		if (projectAxis == ProjectAxis.onlyX)
		{
			direction = new Vector2(horizontal, 0);
		}
		if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
	}
	
	
}
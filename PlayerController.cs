using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
	public GameObject Health_1, Health_2, Health_3;
	public enum ProjectAxis { onlyX = 0, xAndY = 1 };
	public ProjectAxis projectAxis = ProjectAxis.onlyX;
	public float speed = 150;
	public float addForce = 7;
	public bool lookAtCursor;
	public KeyCode leftButton = KeyCode.A;
	public KeyCode Fire = KeyCode.Q;
	public KeyCode rightButton = KeyCode.D;
	public KeyCode upButton = KeyCode.W;
	public KeyCode downButton = KeyCode.S;
	public KeyCode addForceButton = KeyCode.Space;
	public bool isFacingRight = true;
	private Vector3 direction;
	private bool isLadder;
	private float vertical;
	private float horizontal;
	private Rigidbody2D body;
	private float rotationY;
	private bool fire = false;
	private bool jump;
	AudioSource audio;
	public AudioClip clip_pistol,clip_revolver,clip_ak, clip;
	public GameObject Audio;
	public Joystick joystick;
	private float timeBtwShots;
	private float startTimeBtwShots;
	Animator animator;
	public int health;
	public GameObject Player;
	public GameObject firePoint;
    public Transform addParent;
	private GameObject addParent2;
	public DataManager dataManager;
	public GameObject Weapon_AK;
	public GameObject Weapon_Pistol;
	public GameObject Weapon_Revolver;
	public GameObject DeathMenu;
	public GameObject bullet;
	public GameObject HealthPotion_1, HealthPotion_2, HealthPotion_3;

	public Bullet buldmg;



	void Start()
	{
		animator = Player.GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();
	

		if (projectAxis == ProjectAxis.xAndY)
		{
			body.gravityScale = 0;
			body.drag = 10;
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.transform.tag == "Ground")
		{
			animator.SetBool("IsJump", false);
			body.drag = 10;
			jump = true;
			
		}
		if(coll.transform.tag == "Health_1")
        {
			HealthPotion_1.SetActive(false);
			health += 50;
        }
		if (coll.transform.tag == "Health_2")
		{
			HealthPotion_2.SetActive(false);
			health += 50;
		}
		if (coll.transform.tag == "Health_3")
		{
			HealthPotion_3.SetActive(false);
			health += 50;
		}
		if (coll.transform.tag == "Teleport")
		{
			Audio.GetComponent<AudioSource>().PlayOneShot(clip);
            SceneManager.LoadScene("Level_2");
			
		}
		else if (coll.transform.tag == "Teleport2")
		{
			Audio.GetComponent<AudioSource>().PlayOneShot(clip);
            SceneManager.LoadScene("Level_3");
			
		}
		else if (coll.transform.tag == "Teleport3")
		{
			Audio.GetComponent<AudioSource>().PlayOneShot(clip);
            SceneManager.LoadScene("Level_1");
			
		}
		if (coll.transform.tag == "DeathZone")
		{

			transform.rotation = Quaternion.Euler(0, 0, 90);
			Health_1.SetActive(false);
			Health_2.SetActive(false);
			Health_3.SetActive(false);
			DeathMenu.SetActive(true);
		}
	}
public void TakeDamage(int damage) {
		health -= damage;
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.transform.tag == "Ground")
		{
			
			animator.SetBool("IsJump", true);
			body.drag = 0;
			jump = false;
		}
		if (coll.transform.tag == "DeathZone")
		{

			transform.rotation = Quaternion.Euler(0, 0, 90);
			Health_1.SetActive(false);
			Health_2.SetActive(false);
			Health_3.SetActive(false);
			DeathMenu.SetActive(true);
		}
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
 void Shoot() {
		if (dataManager.data.IsRevolver == 1)
        {
			Audio.GetComponent<AudioSource>().PlayOneShot(clip_revolver);
		}
		if (dataManager.data.IsAK == 1)
		{
			Audio.GetComponent<AudioSource>().PlayOneShot(clip_ak);
		}
		if (dataManager.data.IsGlock == 1)
		{
			Audio.GetComponent<AudioSource>().PlayOneShot(clip_pistol);
		}

		GameObject kek = Instantiate(bullet, firePoint.transform.position, transform.rotation);
        kek.transform.SetParent(addParent,true);
		
    }
public void GetFire() {
	fire = true;
}
public void OffFire() {
	fire = false;
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
		if(dataManager.data.IsAK == 0 && dataManager.data.IsGlock == 0 && dataManager.data.IsRevolver == 0){
			Weapon_AK.SetActive(false);
			Weapon_Pistol.SetActive(true);
			Weapon_Revolver.SetActive(false);
			startTimeBtwShots = 0.3f;
			animator.SetBool("IsGun", true);
			dataManager.data.IsGlock = 1;
		}
		else if (dataManager.data.IsAK == 1)
        {
			startTimeBtwShots = 0.15f;
			Weapon_AK.SetActive(true);
			Weapon_Pistol.SetActive(false);
			Weapon_Revolver.SetActive(false);
			animator.SetBool("IsGun", true);
			buldmg.damage = 20;
			
		}
		 else if (dataManager.data.IsGlock == 1)
		{
			startTimeBtwShots = 0.3f;
			Weapon_AK.SetActive(false);
			Weapon_Pistol.SetActive(true);
			Weapon_Revolver.SetActive(false);
			animator.SetBool("IsGun", true);
			buldmg.damage = 20;
		}
		else if (dataManager.data.IsRevolver == 1)
		{
			startTimeBtwShots = 0.5f;
			Weapon_AK.SetActive(false);
			Weapon_Pistol.SetActive(false);
			Weapon_Revolver.SetActive(true);
			animator.SetBool("IsGun", true);
			buldmg.damage = 50;
		}

		if ( timeBtwShots <= 0){
		if(fire)
        {
            Shoot();
			timeBtwShots = startTimeBtwShots;
        }
	} 
	else {
		timeBtwShots -= Time.deltaTime;
	}
		 
		
		horizontal = joystick.Horizontal;
		vertical = joystick.Vertical;
		if (horizontal < 0) {
			
			
			 animator.SetBool("IsRunning", true);
			
		}
		else if (horizontal > 0) {
			
		
			animator.SetBool("IsRunning", true);

		} else {
			
			animator.SetBool("IsRunning", false);
			
		}

		if (vertical > .7f && jump )
			{
				
				body.velocity = new Vector2(0, addForce);
				animator.SetTrigger("Jump");

			}

		if (projectAxis == ProjectAxis.onlyX)
		{
			direction = new Vector2(horizontal, 0);
		}
        if (health > 50)
        {
			Health_1.SetActive(true);
        }
		if (health > 25)
		{
			Health_2.SetActive(true);
		}
		if (health > 0)
		{
			Health_3.SetActive(true);
		}
		if (health < 50)
            {
			Health_1.SetActive(false);
            }
		if (health < 25)
		{

			Health_2.SetActive(false);
		}

		if (health <= 0)
		{
			transform.rotation = Quaternion.Euler(0, 0, 90);
			Health_3.SetActive(false);
			DeathMenu.SetActive(true);
			

		}
		
		if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
		
	}
	
	public void OnClickRestart()
    {
		DeathMenu.SetActive(false);
		SceneManager.LoadScene((SceneManager.GetActiveScene().name));
	}
	public void OnClickExitToMenu()
	{
		DeathMenu.SetActive(false);
		SceneManager.LoadScene("Menu");
	}
}

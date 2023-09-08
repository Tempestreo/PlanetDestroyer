using Cinemachine;
using System;
using TMPro;
using UnityEngine;

public class MeteoriteScript : MonoBehaviour
{
    #region components
    [SerializeField] GameObject vfxExplosion;
    [SerializeField] TextMeshProUGUI txtSize;
    GameObject CineCamera;
    WaveManager scWave;
    Rigidbody2D rb2d;
    MenuManager scMenuManager;
    ParticleScript scParticle;
    #endregion

    public static MeteoriteScript instance;
    internal float currentSpeed;
    Vector3 target;
    [SerializeField] float speed;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        #region Component attachment
        scMenuManager = FindObjectOfType<MenuManager>();
        CineCamera = FindObjectOfType<CinemachineVirtualCamera>().gameObject;
        rb2d = GetComponent<Rigidbody2D>();
        scWave = FindObjectOfType<WaveManager>();
        scParticle = FindObjectOfType<ParticleScript>();
        #endregion

        speed = 30;
        rb2d.velocity = Vector2.down * (this.transform.localScale.x * 2) * Time.deltaTime * speed;
        scParticle.UpdateSize();
    }
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //get mouse position
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.Set(target.x, target.y, 0);
            transform.position = Vector3.Slerp(transform.position, target, Time.deltaTime);
            speed = 30;
            rb2d.velocity = Vector2.down * (this.transform.localScale.x * 2) * Time.deltaTime * speed;
            scParticle.UpdateSize();
        }
        if (this.transform.localScale.x < 0.1f)
        {
            scMenuManager.LosePanel();
            vfxExplosion.transform.position = this.transform.position;
            Instantiate(vfxExplosion);
            Time.timeScale = 0.5f;
            Destroy(txtSize.gameObject);
            Destroy(this.gameObject);
        }

        SizeText();
    }
    //The KM size text of the meteorite
    void SizeText()
    {
        txtSize.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (1 * this.transform.localScale.x), this.transform.position.z);
        txtSize.transform.localScale = this.transform.localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "texts")
        {
            char process = collision.gameObject.GetComponent<TextMeshProUGUI>().text[0];

            string strvalue = collision.gameObject.GetComponent<TextMeshProUGUI>().text.Substring(1);
            int value = Convert.ToInt32(strvalue);
            //using the values on meteorite
            switch (process)
            {
                case '*':
                    this.transform.localScale *= value;
                    break;
                case '+':
                    this.transform.localScale = new Vector3(this.transform.localScale.x + value / 30f, this.transform.localScale.y + value / 30f, this.transform.localScale.z + value / 30f);
                    break;
                case '%':
                    this.transform.localScale /= value;
                    break;
                case '-':
                    this.transform.localScale = new Vector3(this.transform.localScale.x - value / 30f, this.transform.localScale.y - value / 30f, this.transform.localScale.z - value / 30f);
                    break;
            }
            scWave.CheckInstatiate();
            rb2d.velocity = Vector2.down * (this.transform.localScale.x * 2) * Time.deltaTime * speed;
            currentSpeed = (this.transform.localScale.x * 2) * Time.deltaTime * speed;
            CinemachineComponentBase cineMachine = CineCamera.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent(CinemachineCore.Stage.Body);
            (cineMachine as CinemachineFramingTransposer).m_CameraDistance = this.gameObject.transform.localScale.x * 8;
            scParticle.UpdateSize();
            txtSize.text = (Math.Round(this.transform.localScale.x, 1) + " KM").ToString();
            Destroy(collision.transform.parent.gameObject);
        }

    }
}

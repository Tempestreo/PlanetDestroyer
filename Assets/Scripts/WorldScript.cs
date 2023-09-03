using UnityEngine;

public class WorldScript : MonoBehaviour
{
    MenuManager scMenu;
    MeteoriteScript scMeteorite;

    [SerializeField] GameObject VFX_Explosion;

    void Start()
    {
        scMenu = FindObjectOfType<MenuManager>();
        scMeteorite = FindObjectOfType<MeteoriteScript>();

        Material planetMat = this.gameObject.GetComponent<Renderer>().material;
        planetMat.SetInt("_isStopped", 1);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "meteorite")
        {
            if (other.gameObject.transform.localScale.x < this.transform.localScale.x / 2)
            {
                scMenu.LosePanel();
                Material planetMat = this.gameObject.GetComponent<Renderer>().material;
                VFX_Explosion.transform.position = scMeteorite.gameObject.transform.position;
                Instantiate(VFX_Explosion);
                planetMat.SetInt("_isStopped", 0);
                Invoke("ResetProperty", 1f);
                Time.timeScale = 0.2f;
                Destroy(other.gameObject);
            }
            else
            {
                Time.timeScale = 0.2f;
                scMenu.WinPanel();
                scMenu.LevelUp();
                scMenu.LevelCheck();
                VFX_Explosion.transform.position = this.transform.position;
                Instantiate(VFX_Explosion);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
    void ResetProperty()
    {
        Material planetMat = this.gameObject.GetComponent<Renderer>().material;
        planetMat.SetInt("_isStopped", 1);
    }
}

using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{

    #region Components

    MenuManager scMenuManager;
    MeteoriteScript scmeteorite;
    [SerializeField] GameObject location;
    [SerializeField] GameObject TextSphere;
    [SerializeField] GameObject CineCamera;
    [SerializeField] GameObject planet;
    [SerializeField] AudioSource audio;
    #endregion
    #region Sprite Attachment
    [SerializeField] Sprite Planet0;
    [SerializeField] Sprite Planet1;
    [SerializeField] Sprite Planet2;
    [SerializeField] Sprite Planet3;
    [SerializeField] Sprite Planet4;
    [SerializeField] Sprite Planet5;
    [SerializeField] Sprite Planet6;
    [SerializeField] Sprite Planet7;
    [SerializeField] Sprite Planet8;
    [SerializeField] Sprite Planet9;
    #endregion

    internal int textSphereCount = 0;
    internal int size;
    int maxTextSphere;
    private void Start()
    {
        #region Script attachment

        scMenuManager = FindObjectOfType<MenuManager>();
        scmeteorite = FindObjectOfType<MeteoriteScript>();
        #endregion
        #region property Attachment by scene
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            planet.GetComponent<SpriteRenderer>().sprite = Planet0;
            size = 50;
            maxTextSphere = 3;
            planet.gameObject.transform.localScale = new Vector3(size, size, size);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            planet.GetComponent<SpriteRenderer>().sprite = Planet1;
            size = 70;
            maxTextSphere = 3;
            planet.gameObject.transform.localScale = new Vector3(size, size, size);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            planet.GetComponent<SpriteRenderer>().sprite = Planet2;
            size = 120;
            maxTextSphere = 5;
            planet.gameObject.transform.localScale = new Vector3(size, size, size);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            planet.GetComponent<SpriteRenderer>().sprite = Planet3;
            size = 130;
            maxTextSphere = 5;
            planet.gameObject.transform.localScale = new Vector3(size, size, size);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            planet.GetComponent<SpriteRenderer>().sprite = Planet4;
            size = 490;
            maxTextSphere = 7;
            planet.gameObject.transform.localScale = new Vector3(size, size, size);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            planet.GetComponent<SpriteRenderer>().sprite = Planet5;
            size = 520;
            maxTextSphere = 7;
            planet.gameObject.transform.localScale = new Vector3(size, size, size);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            planet.GetComponent<SpriteRenderer>().sprite = Planet6;
            size = 1250;
            maxTextSphere = 10;
            planet.gameObject.transform.localScale = new Vector3(size, size, size);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            planet.GetComponent<SpriteRenderer>().sprite = Planet7;
            size = 1500;
            maxTextSphere = 10;
            planet.gameObject.transform.localScale = new Vector3(size, size, size);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            planet.GetComponent<SpriteRenderer>().sprite = Planet8;
            size = 1700;
            maxTextSphere = 10;
            planet.gameObject.transform.localScale = new Vector3(size, size, size);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            maxTextSphere = 10;
            planet.GetComponent<SpriteRenderer>().sprite = Planet9;
            size = 2500;
            planet.gameObject.transform.localScale = new Vector3(size, size, size);
        }
        #endregion
        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
    private void Update()
    {
        if (scMenuManager.isStarted == true && textSphereCount == 0)
        {
            CheckInstatiate();
        }
    }
    internal void CheckInstatiate()
    {
        if (textSphereCount < maxTextSphere & scmeteorite.transform.localScale.x < size / 2)
        {
            textSphereCount++;
            Invoke("InstantiateTextSphere", 0.5f);
        }
        else
        {
            location.transform.position = new Vector3(scmeteorite.transform.position.x, scmeteorite.transform.position.y - (20 * (scmeteorite.transform.localScale.x)) - (scmeteorite.transform.localScale.x * scmeteorite.currentSpeed / 4) - (size * 2), scmeteorite.transform.position.z);
            planet.transform.position = location.transform.position;
            Invoke("InstantiatePlanet", 0.5f);
            float betweenPlanetAndMeteorite = (location.transform.position.y + scmeteorite.gameObject.transform.position.y) / 2;
            CineCamera.GetComponent<CinemachineVirtualCamera>().Follow.transform.position = new Vector3(location.transform.position.x, betweenPlanetAndMeteorite, location.transform.position.z);
            CineCamera.GetComponent<CinemachineVirtualCamera>().LookAt.transform.position = new Vector3(location.transform.position.x, betweenPlanetAndMeteorite, location.transform.position.z);
        }
    }
    internal void InstantiatePlanet()
    {

        Instantiate(planet);
    }
    void InstantiateTextSphere()
    {
        location.transform.position = new Vector3(scmeteorite.transform.position.x, scmeteorite.transform.position.y - (20 * (scmeteorite.transform.localScale.x)) - (scmeteorite.transform.localScale.x * scmeteorite.currentSpeed / 4), scmeteorite.transform.position.z);
        Instantiate(TextSphere.gameObject, location.transform);

    }
}

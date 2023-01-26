using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Top_Controller : MonoBehaviour
{
    public SpriteRenderer ressam;
    public Rigidbody2D _rb2;

    
    public float _ziplamaGücü;
    public Color pembe, turkuaz, sari, mor;
    string mevcut_renk;
    int score = 0;

    [SerializeField] AudioSource ziplama_sesi;
    [SerializeField] Transform kontrol1, kontrol2, cember1, cember2;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] Transform değiştirici;// renk değiştricinin atanacağı değişken

    private void Start()
    {
        Rastgele_Renk();
        _rb2.velocity = Vector2.up * _ziplamaGücü;
        Cember_Return.donus_hizi = 2f;
      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            _rb2.velocity = Vector2.up * _ziplamaGücü;
            ziplama_sesi.Play();
        }

        Score.text = "Score:" + score;

    }

    void Rastgele_Renk()
    {
        int rastgele_sayi = Random.Range(0, 4);

        switch (rastgele_sayi)
        {
            case 0:
                ressam.color = pembe;
                mevcut_renk = "pembe";
                break;
            case 1:
                ressam.color = sari;
                mevcut_renk = "sari";
                break;
            case 2:
                ressam.color = mor;
                mevcut_renk = "mor";
                break;
            case 3:
                ressam.color = turkuaz;
                mevcut_renk = "turkuaz";
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.tag != mevcut_renk && temas.tag != "renkDegistirici" && temas.tag !="kontrol1" && temas.tag != "kontrol2")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (temas.CompareTag("zemin"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (temas.CompareTag("renkDegistirici")) //renk değiştiricinin kodeu
        {
            Cember_Return.donus_hizi += 0.10f;
            score++;
            Rastgele_Renk();
            değiştirici.position = new Vector3(değiştirici.position.x, değiştirici.position.y + 8f, değiştirici.position.z);
        }

        if (temas.CompareTag("kontrol1"))
        {
            kontrol1.position = new Vector3(kontrol1.position.x,kontrol1.position.y + 16f, kontrol1.position.z);
            cember1.position = new Vector3(cember1.position.x, cember1.position.y + 16f, cember1.position.z);
        }

        if (temas.CompareTag("kontrol2"))
        {
            kontrol2.position = new Vector3(kontrol2.position.x, kontrol2.position.y + 16f, kontrol2.position.z);
            cember2.position = new Vector3(cember2.position.x, cember2.position.y + 16f, cember2.position.z);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement; 
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 100.0f;
    private Rigidbody _rb;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI TimeText;
    private int _score = 0;
    public float _time = 30.0f;
    public GameObject obj;
    public GameObject _defText;
    public GameObject _ReturnMenuButton;
    public float SpavnTime = 5f;
    // Start is called before the first frame update
    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (_time > 0f){
        _time = _time -  Time.fixedDeltaTime;
        int a = (int)_time;
        TimeText.text = "Время: " + a;
        float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        _rb.AddForce(new Vector3(h, 0, v));
        }else{
            OnDesPlayer();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Cube"){
            _score++;
            Destroy(other.gameObject);
            _time = _time + 1.0f;
            scoreText.text = "Счёт: " + _score;
        }
    }

    void Start()
    {
        Create();
    }

    private IEnumerator Create3dObjects(float wait){
        // таймер
        yield return new WaitForSeconds(wait);
        Create();
    }

    void Create()
    {
        //Instantiate(obj, new Vector3(0, 5, 0), Quaternion.Euler(12f,-15f,40f));
        //GameObject newGameobject = Instantiate(obj, new Vector3(0, 5, 0), Quaternion.Euler(12f,-15f,40f)) as GameObject;
        //newGameobject.GetComponent<Transform>().Translate(new Vector3(5, 5, 0));
        for (int i = 0; i<5; i++){
            Instantiate(obj, new Vector3(RN(), 0.5f, RN()), Quaternion.Euler(0f,0f,0f));
        }
        StartCoroutine(Create3dObjects(SpavnTime));
    }

    private int RN(){   // RandomeNamber
        return UnityEngine.Random.Range(-9, 9);
    }

    private void OnDesPlayer() {
        _defText.SetActive(true);
        _ReturnMenuButton.SetActive(true);
        if (PlayerPrefs.HasKey("score")){
            int s = PlayerPrefs.GetInt("score");
            if (s < _score){
                PlayerPrefs.SetInt("score", _score);
            }
        }else{
            PlayerPrefs.SetInt("score", _score);
        }

    }

    public void scenGoMainMenue(){
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
//obj.SetActive(false);
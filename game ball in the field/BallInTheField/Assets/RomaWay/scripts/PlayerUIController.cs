using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] GameObject _jostic;
    [SerializeField] PlayerMoveForceForCommon _playerMoveForceForCommon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetActiveJostic(bool a)
    {
        _jostic.SetActive(a);
        _playerMoveForceForCommon.ChangeControlTypePhone(a);
    }
}

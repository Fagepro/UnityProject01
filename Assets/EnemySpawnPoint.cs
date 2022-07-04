using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{

	[SerializeField] private ObjectTypes objectType;
	private SpawnController _spawnController;
	
		void Start()
		{
			_spawnController = FindObjectOfType<SpawnController>();
			Spawn();
		}
	
    void Update()
    {
        
    }

    private void Spawn()
    {
	    _spawnController.SpawnByType(objectType, this.transform.position);
    }

}

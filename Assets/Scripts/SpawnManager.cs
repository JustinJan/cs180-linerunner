using UnityEngine;
	using System.Collections;
	
	public class SpawnManager : MonoBehaviour {
		
		public int maxPlatforms = 20;
		public GameObject platform;
		public float horizontalMin = 7.5f;
		public float horizontalMax = 14f;
		public float verticalMin = -1;
		public float verticalMax = 2f;
		
		
		private Vector2 originPosition;
		
		
		void Start () {
			
			originPosition = transform.position;
			Spawn ();
			
		}
		
		void Spawn()
		{
			for (int i = 0; i < maxPlatforms; i++)
			{
				int isFloor = Random.Range(0,2);
				int position;
				if(isFloor == 1)
					position = 0;
				else
					position = 3;
				Vector2 randomPosition = originPosition + new Vector2 (Random.Range(horizontalMin, horizontalMax), position);
				Instantiate(platform, randomPosition, Quaternion.identity);
				originPosition.x = randomPosition.x;
				//if (originPosition.y < 2) {
				//    originPosition.y = 2;
			    //}
			    if (originPosition.y > 5) {
				    originPosition.y = 5;
			    }
				
			}  
		}
		
	}

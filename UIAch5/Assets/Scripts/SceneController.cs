using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	public const int gridRows = 2;
	public const int gridCols = 4;
	public const float offsetX = 2f;
	public const float offsetY = 2.5f;

	[SerializeField] private MemoryCard originalCard;
	[SerializeField] private Sprite[] images;
	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;
	[SerializeField] private TextMesh scoreLabel;
	private int _score = 0;

	void Start(){
		Vector3 startPos = originalCard.transform.position;

		int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
		numbers = ShuffleArray (numbers);

		for(int i = 0; i < gridCols; i++){
			for(int j = 0; j < gridRows; j++){
				MemoryCard card;
				if(i == 0 && j == 0){
					card = originalCard;
				} else{
					card = Instantiate(originalCard) as MemoryCard;
				}

				int index = j * gridCols + i;
				int id = numbers[index];
				card.SetCard (id, images [id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3(posX, posY, startPos.z);
			}
		}
	}

	//Knuth's shuffle algorithm //Also known as Fisher-Yates shuffle
	private int[] ShuffleArray(int[] numbers){
		int[] newArray = numbers.Clone () as int[];
		for (int i = 0; i < newArray.Length; i++) {
			int tmp = newArray [i];
			int r = Random.Range (i, newArray.Length);
			newArray [i] = newArray [r];
			newArray [r] = tmp;
		}
		return newArray;
	}

	public bool canReveal {
		get { return _secondRevealed == null; }
	}

	public void CardRevealed(MemoryCard card){
		if (_firstRevealed == null) {
			_firstRevealed = card;
		} else {
			_secondRevealed = card;
			StartCoroutine (CheckMatch ());
		}
	}

	private IEnumerator CheckMatch(){
		if (_firstRevealed.id == _secondRevealed.id) {
			_score++;
			scoreLabel.text = "Score: " + _score;
		} else {
			yield return new WaitForSeconds (0.5f);

			_firstRevealed.Unreveal ();
			_secondRevealed.Unreveal ();
		}

		_firstRevealed = null;
		_secondRevealed = null;
	}

	public void Restart(){
		Application.LoadLevel ("ch5");
	}

}

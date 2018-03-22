using UnityEngine;

public class ClaimMoney : MonoBehaviour
{
	public GUIText gt;
	private string text;

	void Start(){
		if (WinningNumber.winningnum == SelectionOkay.numberBought) {
			text = "Your number: " + UpDownButtons4D.playerNum + "\nToday's winning number: " + WinningNumber.winningnum +
				"\n\nCongratulations! Your number is\nthe winning number for today!";
			transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
			gt.text = text;
		} else {
			text = "Your number: " + UpDownButtons4D.playerNum + "\nToday's winning number: " + WinningNumber.winningnum +
				"\n\nSorry! Your number is not the\nwinning number for today...";
			gt.text = text;
		}
	}

	void OnMouseDown(){
		SelectionOkay.numberBought = "";
		MoneyCounter.addAmt(SelectionOkay.amount*20);
		transform.position = new Vector3 (transform.position.x, transform.position.y, -20);
		GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Home");
	}
}
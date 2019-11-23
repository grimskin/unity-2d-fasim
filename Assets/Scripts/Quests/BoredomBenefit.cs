using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoredomBenefit : BaseBenefit {

	public BoredomBenefit()
	{
		key = BaseBenefit.BOREDOM;
		value = 1f;
		reversed = true;
	}
}

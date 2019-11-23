using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBenefit
{
	string getKey ();

	float getValue ();

	bool isReversed();
}

public class BaseBenefit: IBenefit
{
	public const string BOREDOM = "boredom";

	protected string key;

	protected float value;

	protected bool reversed = false;

	public string getKey()
	{
		return key;
	}

	public float getValue ()
	{
		return value;
	}

	public void setValue (float newValue)
	{
		value = newValue;
	}

	public bool isReversed()
	{
		return reversed;
	}
}

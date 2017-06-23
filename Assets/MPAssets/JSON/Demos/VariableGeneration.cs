﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MPAssets;

public class MyDataTest {
	public static MyDataTest instance;

	public MyDataTest() {
		instance = this;
	}

	[SerializeField]
	int MYINT = 0;
	public static int myInt {
		set { instance.MYINT = value; }
		get { return instance.MYINT; }
	}

	[SerializeField]
	float MYFLOAT = 1.0f;
	public static float myFloat {
		set { instance.MYFLOAT = value; }
		get { return instance.MYFLOAT; }
	}

	[SerializeField]
	string MYSTRING = "Default Value";
	public static string myString {
		set { instance.MYSTRING = value; }
		get { return instance.MYSTRING; }
	}

	[SerializeField]
	List<string> MYLISTOFSTRINGS = new List<string>() { "str1", "str2" };
	public static List<string> myListOfStrings {
		set { instance.MYLISTOFSTRINGS = value; }
		get { return instance.MYLISTOFSTRINGS; }
	}

	[SerializeField]
	List<string> EMPTYLIST;
	public static List<string> emptyList {
		set { instance.EMPTYLIST = value; }
		get { return instance.EMPTYLIST; }
	}
}

public class VariableGeneration : MonoBehaviour {
	List<MyVariable> myVariables = new List<MyVariable>() {
		new MyVariable("int", "myInt", "0"),
		new MyVariable("float", "myFloat", "1.0f"),
		new MyVariable("string", "myString", "\"Default Value\""),
		new MyVariable("List<string>", "myListOfStrings", "new List<string>(){\"str1\", \"str2\"}"),
		new MyVariable("List<string>", "emptyList")
	};

	string GenerateAllVariables(List<MyVariable> variables) {
		string str = "";

		foreach (MyVariable variable in variables) {
			str += MyJSON.GenerateVariable(variable.type, variable.name, variable.defaultValue);
			str += "\n";
		}

		return str;
	}

	public void SaveData() {
		MyDataTest data = new MyDataTest();

		MyJSON.SaveInfo<MyDataTest>(data, "data.json");
	}

	public void LoadData() {
		MyDataTest data = MyJSON.LoadInfo<MyDataTest>(Application.dataPath + "/../data.json");

		if (data == null)
			Debug.Log("File not found or not formated");
		else
			Debug.Log(MyJSON.FormatJson(JsonUtility.ToJson(data)));
	}

	// Use this for initialization
	void Start () {
		string str = GenerateAllVariables(myVariables);

		Debug.Log(str);

		//System.IO.File.WriteAllText("VariablesMain.cs", str);
	}
}

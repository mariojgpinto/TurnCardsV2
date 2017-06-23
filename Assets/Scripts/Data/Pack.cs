using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackPage {
	public string title;
	public int startIdx = -1;
	public int endIdx = -1;
}

public class Pack {
	public string title;

	public List<Board> boards = new List<Board>();

	public List<PackPage> subTitles = new List<PackPage>();
}

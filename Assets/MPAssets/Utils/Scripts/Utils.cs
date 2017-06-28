using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MPAssets {
	public class Utils {
		public static string RemoveSpecialCharacters(string str) {
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			foreach (char c in str) {
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_') {
					sb.Append(c);
				}
			}
			return sb.ToString();
		}

		public static bool ExistsInList<T>(List<T> list, T element) {
			foreach(T elem in list) {
				if (elem.Equals(element))
					return true;
			}
			return false;
		}
	}
}
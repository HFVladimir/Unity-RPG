using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	public List<BaseStat> Stats { get; set; }

	// lowercase no-space name of the item
	public string ObjectSlug { get; set; }

	public Item(List<BaseStat> _Stats, string _ObjectSlug)
	{
		this.Stats = _Stats;
		this.ObjectSlug = _ObjectSlug;
	}
}

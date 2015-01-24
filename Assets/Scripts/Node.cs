using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
public class Node: IEquatable<Node> {
	public enum CellType{start,goal,ordinary};
	public Vector3 coords{ get; set; }
	public int id{ get; set; }
	public List<Node> adjacent;

	public Node(Vector3 coords, int id){
		this.coords = coords;
		this.id = id;
		adjacent = new List<Node>();
	}

	public void addAdjacent(Node n){
		if(!adjacent.Contains(n)){
			adjacent.Add(n);
		}
	}
	public List<Node> getAdjacentNodes(){
		return adjacent;
	}
	public bool Equals(Node other)
	{
		if (other == null) return false;
		return (this.id == other.id);
	}
	public override bool Equals(object obj)
	{
		Node emp = obj as Node;
		if (emp != null)
		{
			return this.id == emp.id;
		}
		else
		{
			return false;
		}
	}
	public override int GetHashCode()
	{
		return this.id;
	}
}
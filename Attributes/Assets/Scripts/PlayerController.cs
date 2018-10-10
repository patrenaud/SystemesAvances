using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [Comment("This is an ID")]
    public int playerID;

	void Start ()
    {
        // On cherche l'info sur le type PlayerController
        Type monType = typeof(PlayerController);

        // On cherche l'info sur le field playerID
        FieldInfo monField = monType.GetField("playerID");

        // On va chercher tous les attributs de type CommentAttribute sur le field playerID
        object[] attributes = monField.GetCustomAttributes(typeof(CommentAttribute), false);

        // On cast le premier attribut en CommentAttribute
        CommentAttribute monAttribut = (CommentAttribute)attributes.FirstOrDefault(); // ou: as CommentAttribute;

        Debug.Log(monAttribut.Comment);
	}
	

	void Update ()
    {
		
	}
}

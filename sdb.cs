using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Data;
using Mono.Data.Sqlite;

public class sdb : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/Users.s3db"; //Path to database.
     IDbConnection dbconn;
     dbconn = (IDbConnection) new SqliteConnection(conn);
     dbconn.Open(); //Open connection to the database.
     IDbCommand dbcmd = dbconn.CreateCommand();
     string sqlQuery = "SELECT * " + "FROM Usersinfo";
     dbcmd.CommandText = sqlQuery;
     IDataReader reader = dbcmd.ExecuteReader();
     while (reader.Read())
     {
         int id = reader.GetInt32(0);
         string name = reader.GetString(1);
         string Email = reader.GetString(2);
         string Phone = reader.GetString(3);
        
         Debug.Log( "value= "+id+"  name ="+name+"  Eamil ="+  Email +"Phone"+ Phone);
     }
     reader.Close();
     reader = null;
     dbcmd.Dispose();
     dbcmd = null;
     dbconn.Close();
     dbconn = null;
 }
	
	
	// Update is called once per frame
	void Update () {
		
	}
}

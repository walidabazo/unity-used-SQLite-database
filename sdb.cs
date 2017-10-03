using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
public class insert : MonoBehaviour {
    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
	// Use this for initialization
	void Start () {
        conn = "URI=file:" + Application.dataPath + "/Plugins/Users.s3db"; //Path to database.
        //Deletvalue(6);
        //insertvalue("ahmedm", "ahmedm@gmail.com", "sss"); 
        Updatevalue("a","w@gamil.com","1st",1);
        readers();
	}

    private void insertvalue(string name, string email, string address)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into Usersinfo (Name, Email, Address) values (\"{0}\",\"{1}\",\"{2}\")",name,email,address);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    private void Deletvalue(int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("Delete from Usersinfo WHERE ID=\"{0}\"", id);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void Updatevalue(string name, string email, string address,int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {

            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Usersinfo set Name=\"{0}\", Email=\"{1}\", Address=\"{2}\" WHERE ID=\"{3}\" ", name, email, address, id);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void readers()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM Usersinfo";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string Email = reader.GetString(2);
                string Phone = reader.GetString(3);

                Debug.Log("value= " + id + "  name =" + name + "  Eamil =" + Email + "   Phone" + Phone);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

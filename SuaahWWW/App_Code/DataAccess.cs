using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Suaahwww
{
    public class DataAccess
    {
        private string adapterstring;
        private SqlConnection con;
        public DataAccess(string conn)
        {
            string connectionstring = conn;
             adapterstring= ConfigurationManager.ConnectionStrings[connectionstring].ToString();
            con = new SqlConnection(adapterstring);
        }

        public void Insert(string TableName,string[] propValue,string[] propName=null)
        {
            if (TableName == null)
            {
                throw new Exception("Enter all tables names");
            }
            if (propValue == null)
            {
                throw new Exception("Must enter the values");
            }
            if (propName != null)
            if (propName.Length != propValue.Length)
            {
                throw new Exception("The number of prop dont equal values ");
            }

            string sql = "insert into [dbo].[" + TableName+"] ";
            if (propName != null)
            {
                sql += "(";
                for (int i = 0; i < propName.Length - 1; i++)
                {

                    sql += "[" + propName[i] + "],";
                }
                sql += "[" + propName[propName.Length - 1] + "]) VALUES(";
            }
            else
            {
                sql += "VALUES(";
            }
                
                for(int j = 0; j < propValue.Length-1; j++)
                {
                sql+="'"+propValue[j] + "',";
                }
                sql+="'"+propValue[propValue.Length-1] + "')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(string TableName, string[] propName, string[] propValue,string[] WhereProp=null,string[] WhereValues=null)
        {
            if (TableName == null)
            {
                throw new Exception("Enter all tables names");
            }
            if ((WhereProp == null && WhereValues != null) || (WhereProp != null && WhereValues == null))
            {
                throw new Exception("The number of prop dont equal values in where");
            }
            if (WhereProp != null && WhereValues != null)
            {
                if (WhereValues.Length != WhereProp.Length)
                {
                    throw new Exception("The number of prop dont equal values in where");
                }
            }
            if ((propName == null && propValue != null) || (propName != null && propValue == null))
            {
                throw new Exception("The number of prop dont equal values in where");
            }
            if (propName != null && propValue != null)
            {
                if (propValue.Length != propName.Length)
                {
                    throw new Exception("The number of prop dont equal values in where");
                }
            }
            string sql = "update [dbo].[" + TableName + "] set ";
            for( int i = 0; i < propName.Length-1; i++)
            {
                sql += propName[i] + "= '" + propValue[i] + "' , ";
            }
            sql += propName[propName.Length-1] + "= '" + propValue[propName.Length - 1] + "' ";
            if (WhereProp != null || WhereValues != null)
            {
                sql += "where ";
                for (int i = 0; i < WhereProp.Length - 1; i++)
                {
                    sql += WhereProp[i] + "= '" + WhereValues[i] + "' and ";
                }
                sql += WhereProp[WhereProp.Length - 1] + "= '" + WhereValues[WhereProp.Length - 1] + "'";
            }
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string TableName, string[] WhereProp = null, string[] WhereValues = null)
        {
            if ((WhereProp == null && WhereValues != null) || (WhereProp != null && WhereValues == null))
            {
                throw new Exception("The number of prop dont equal values in where");
            }
            if (WhereProp != null && WhereValues != null)
            {
                if (WhereValues.Length != WhereProp.Length)
                {
                    throw new Exception("The number of prop dont equal values in where");
                }
            }
            string sql = "delete from "+TableName+" ";
           
            if (WhereProp != null || WhereValues != null)
            {
                sql += "where ";
                for (int i = 0; i < WhereProp.Length - 1; i++)
                {
                    sql += WhereProp[i] + "= '" + WhereValues[i] + "' and ";
                }
                sql += WhereProp[WhereProp.Length - 1] + "= '" + WhereValues[WhereProp.Length - 1] + "'";
            }
            

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public DataTable SelectDist(string TableName, string[] propName = null, string[] WhereProp = null, string[] WhereValues = null, string[] Orderby = null)
        {
            if (TableName == null)
            {
                throw new Exception("Enter all tables names");
            }
            if ( (WhereProp == null && WhereValues != null) || (WhereProp != null && WhereValues == null))
            {
                throw new Exception("The number of prop dont equal values in where");
            }
            if (WhereProp != null && WhereValues != null)
            {
                if (WhereValues.Length != WhereProp.Length)
                {
                    throw new Exception("The number of prop dont equal values in where");
                }
            }
            string sql = "select DISTINCT";
            if (propName != null)
            {
                for (int i = 0; i < propName.Length - 1; i++)
                {
                    sql += propName[i] + " , ";
                }
                sql += propName[propName.Length - 1] + " ";
            }
            else
            {
                sql += " * ";
            }
            sql += "from " + TableName + " ";
            if (WhereProp != null || WhereValues != null)
            {
                sql += "where ";
                for (int i = 0; i < WhereProp.Length - 1; i++)
                {
                    sql += WhereProp[i] + "= '" + WhereValues[i] + "' and ";
                }
                sql += WhereProp[WhereProp.Length - 1] + "= '" + WhereValues[WhereProp.Length - 1] + "'";
            }
            if (Orderby != null)
            {
                sql += "ORDER BY ";
                for (int i = 0; i < Orderby.Length - 1; i++)
                {
                    sql += Orderby[i] + " , ";
                }
                sql += Orderby[Orderby.Length - 1];
            }
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable Select(string TableName, string[] propName = null, string[] WhereProp = null, string[] WhereValues = null,string[] Orderby=null)
        {
            if (TableName == null )
            {
                throw new Exception("Enter all tables names");
            }
            
            if (  (WhereProp == null && WhereValues != null) || (WhereProp != null && WhereValues == null))
            {
                throw new Exception("The number of prop dont equal values in where");
                    
            }
            if(WhereProp != null && WhereValues != null)
            {
                if(WhereValues.Length !=WhereProp.Length)
                {
                    throw new Exception("The number of prop dont equal values in where");
                }
            }
            string sql = "select ";
            if (propName != null)
            {
                for (int i = 0; i < propName.Length - 1; i++)
                {
                    sql += propName[i] + " , ";
                }
                sql += propName[propName.Length - 1] + " ";
            }
            else
            {
                sql += " * ";
            }
            sql += "from " + TableName + " ";
            if (WhereProp != null || WhereValues != null)
            {
                sql += "where ";
                for (int i = 0; i < WhereProp.Length - 1; i++)
                {
                    sql += WhereProp[i] + "= '" + WhereValues[i] + "' and ";
                }
                sql += WhereProp[WhereProp.Length - 1] + "= '" + WhereValues[WhereProp.Length - 1] + "' ";
            }
            if (Orderby != null)
            {
                sql += "ORDER BY ";
                for (int i = 0; i < Orderby.Length - 1; i++)
                {
                    sql += Orderby[i] + " , ";
                }
                sql += Orderby[Orderby.Length - 1] ;
            }
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable Select2Join(string firstTableName, string secTableName, string[] firpropName=null , string[] secpropName=null ,string firstTableJoin=null,string secTableJoin=null, string[] WhereProp = null, string[] WhereValues = null, string[] Orderby = null)
        {
            if ( firstTableName == null || secTableName == null)
            {
                throw new Exception("Enter all tables names");
            }
            if ((WhereProp == null && WhereValues != null) || (WhereProp != null && WhereValues == null))
            {
                throw new Exception("The number of prop dont equal values in where");

            }
            if (WhereProp != null && WhereValues != null)
            {
                if (WhereValues.Length != WhereProp.Length)
                {
                    throw new Exception("The number of prop dont equal values in where");
                }
            }
            string sql = "select ";
            if (firpropName != null)
            {
                for (int i = 0; i < firpropName.Length - 1; i++)
                {
                    sql +=firstTableName+"."+ firpropName[i] + " , ";
                }
                sql += firstTableName + "." + firpropName[firpropName.Length - 1] + " ";
            }
            if(secpropName != null)
            {
                sql += ", ";
                for (int i = 0; i < secpropName.Length - 1; i++)
                {
                    sql += secTableName + "." + secpropName[i] + " , ";
                }
                sql += secTableName + "." + secpropName[secpropName.Length - 1] + " ";
            }
            sql += "from " + firstTableName + " ";
            sql += "inner join "+secTableName+" on "+firstTableName+"."+ firstTableJoin+" = "+secTableName+"."+secTableJoin+" ";
            if (WhereProp != null || WhereValues != null)
            {
                sql += "where ";
                for (int i = 0; i < WhereProp.Length - 1; i++)
                {
                    sql +=firstTableName+"."+ WhereProp[i] + "= '" + WhereValues[i] + "' and ";
                }
                sql += firstTableName + "." + WhereProp[WhereProp.Length - 1] + "= '" + WhereValues[WhereProp.Length - 1] + "' ";
            }
            if (Orderby != null)
            {
                sql += "ORDER BY ";
                for (int i = 0; i < Orderby.Length - 1; i++)
                {
                    sql += firstTableName + "." + Orderby[i] + " , ";
                }
                sql += firstTableName + "." + Orderby[Orderby.Length - 1];
            }
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable Select3Join(string firstTableName, string secTableName, string thrdTableName, string[] firpropName = null, string[] secpropName = null, string[] thirdpropName = null, string firstTableJoinsec = null, string firstTableJointhir = null, string secTableJoin = null, string thirdTableJoin = null, string[] WhereProp = null, string[] WhereValues = null, string[] Orderby = null)
        {
            if (thrdTableName == null||firstTableName==null||secTableName==null)
            {
                throw new Exception("Enter all tables names");
            }
            if ((WhereProp == null && WhereValues != null) || (WhereProp != null && WhereValues == null))
            {
                throw new Exception("The number of prop dont equal values in where");

            }
            if (WhereProp != null && WhereValues != null)
            {
                if (WhereValues.Length != WhereProp.Length)
                {
                    throw new Exception("The number of prop dont equal values in where");
                }
            }

            string sql = "select ";
            if (firpropName != null)
            {
                for (int i = 0; i < firpropName.Length - 1; i++)
                {
                    sql += firstTableName + "." + firpropName[i] + " , ";
                }
                sql += firstTableName + "." + firpropName[firpropName.Length - 1] + " ";
            }
            if (secpropName != null)
            {
                sql += ", ";
                for (int i = 0; i < secpropName.Length - 1; i++)
                {
                    sql += secTableName + "." + secpropName[i] + " , ";
                }
                sql += secTableName + "." + secpropName[secpropName.Length - 1] + " ";
            }
            if (thirdpropName != null)
            {
                sql += ", ";
                for (int i = 0; i < thirdpropName.Length - 1; i++)
                {
                    sql += thrdTableName + "." + thirdpropName[i] + " , ";
                }
                sql += thrdTableName + "." + thirdpropName[thirdpropName.Length - 1] + " ";
            }
            sql += "from ((" + firstTableName + " ";
            sql += "inner join " + secTableName + " on " + firstTableName + "." + firstTableJoinsec + " = " + secTableName + "." + secTableJoin + ") ";
            sql += "inner join " + thrdTableName + " on " + firstTableName + "." + firstTableJointhir + " = " + thrdTableName + "." + thirdTableJoin + ") "; ;
            if (WhereProp != null || WhereValues != null)
            {
                sql += "where ";
                for (int i = 0; i < WhereProp.Length - 1; i++)
                {
                    sql += firstTableName + "." + WhereProp[i] + "= '" + WhereValues[i] + "' and ";
                }
                sql += firstTableName + "." + WhereProp[WhereProp.Length - 1] + "= '" + WhereValues[WhereProp.Length - 1] + "' ";
            }
            if (Orderby != null)
            {
                sql += "ORDER BY ";
                for (int i = 0; i < Orderby.Length - 1; i++)
                {
                    sql += firstTableName + "." + Orderby[i] + " , ";
                }
                sql += firstTableName + "." + Orderby[Orderby.Length - 1];
            }
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable Procedure(string procedureName,string[] propName=null,string[] propValue=null)
        {
            if ((propName == null && propValue != null) || (propName != null && propValue == null))
            {
                throw new Exception("The number of prop dont equal values in where");

            }
            if (propName != null && propValue != null)
            {
                if (propValue.Length != propName.Length)
                {
                    throw new Exception("The number of prop dont equal values in where");
                }
            }
            if (procedureName == null)
            {
                throw new Exception("Must enter Procedure name");
            }
            string sql = "EXEC " + procedureName + " ";
            if (propName != null)
            {
                for (int i = 0; i < propName.Length - 1; i++)
                {
                    sql += "@" + propName[i] + " = '" + propValue[i] + "' , ";
                }
                sql+= "@" + propName[propName.Length - 1] + " = '" + propValue[propName.Length - 1] + "'  ";
            }
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


    }
}
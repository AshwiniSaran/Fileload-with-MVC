using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SportAgency.Models
{
    public class FileLoad
    {
        string constring = ConfigurationManager.ConnectionStrings["con"].ToString();

        public int insertsport(string filepath)
        {
            int result;
            try
            {

                //string constring = ConfigurationManager.ConnectionStrings["con"].ToString();
                SqlBulkCopy bulkCopy = new SqlBulkCopy(constring);
                bulkCopy.DestinationTableName = "tbl_Sports";
                DataTable sporttable = FiletoTableforSports(filepath);
                bulkCopy.WriteToServer(sporttable);
                result = 1;
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: {0}", e.ToString());
                result = 0;
                
            }
            return result;
        }

        public DataTable FiletoTableforSports(String filepath)
        {
            string record;
            DataTable dt = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "SNo";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "displayname";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "sportcode";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "teamsize";
            dt.Columns.Add(column);

            DataRow dr;
            StreamReader file = new StreamReader(filepath);
            while ((record = file.ReadLine()) != null)
            {
                string[] values = record.Split(new char[] { '\t' });
                dr = dt.NewRow();
                dr["displayname"] = values[0];
                dr["sportcode"] = values[1];
                dr["teamsize"] = values[2];
                dt.Rows.Add(dr);

            }
            file.Close();

            return dt;
        }
        public int insertagent(string filepath)
        {
            int result;
            try
            {
                
                //string constring = ConfigurationManager.ConnectionStrings["con"].ToString();
                SqlBulkCopy bulkCopy = new SqlBulkCopy(constring);
                bulkCopy.DestinationTableName = "tbl_Agents";
                DataTable agenttable = FiletoTableforAgent(filepath);
                bulkCopy.WriteToServer(agenttable);
                result = 1;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: {0}", e.ToString());
                result = 0;

            }
            return result;
        }
        public DataTable FiletoTableforAgent(String filepath)
        {
            string record;
            DataTable dt = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "SNo";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Code";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "firstname";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Lastname";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "phonenumber";
            dt.Columns.Add(column);


            DataRow dr;
            StreamReader file = new StreamReader(filepath);
            if (file.ReadLine() != null)
            {
                while ((record = file.ReadLine()) != null)
                {


                    string[] values = Regex.Split(record, "\\ +");
                    dr = dt.NewRow();
                    dr["Code"] = values[0];
                    dr["firstname"] = values[1];
                    dr["Lastname"] = values[2];
                    dr["phonenumber"] = values[3];
                    dt.Rows.Add(dr);

                }
            }
            file.Close();

            return dt;
        }


        public int insertathlete(string filepath)
        {
            int result;
            try
            {

                //string constring = ConfigurationManager.ConnectionStrings["con"].ToString();
                SqlBulkCopy bulkCopy = new SqlBulkCopy(constring);
                bulkCopy.DestinationTableName = "tbl_Athletes";
                DataTable athletetable = FiletoTableforAthlete(filepath);
                bulkCopy.WriteToServer(athletetable);
                result = 1;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: {0}", e.ToString());
                result = 0;
            }
            return result;
        }
        public DataTable FiletoTableforAthlete(String filepath)
        {
            string record;
            DataTable dt = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "SNo";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SSN";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "firstname";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Lastname";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "birthdate";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "sportcode";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "agencycode";
            dt.Columns.Add(column);


            DataRow dr;
            StreamReader file = new StreamReader(filepath);
            if (file.ReadLine() != null)
            {
                while ((record = file.ReadLine()) != null)
                {
                    string[] values = record.Split(new char[] { '|' });
                    dr = dt.NewRow();
                    dr["SSN"] = values[0];
                    dr["firstname"] = values[1];
                    dr["Lastname"] = values[2];
                    dr["birthdate"] = values[3];
                    dr["sportcode"] = values[4];
                    dr["agencycode"] = values[5];
                    dt.Rows.Add(dr);

                }
            }
            file.Close();

            return dt;
        }
        public List<SportAgency> GetAthleteAndAgent()
        {
            SqlConnection con = new SqlConnection(constring);
            List<SportAgency> sportagencylist = new List<SportAgency>();
            try
            {
                
                

                SqlCommand cmd = new SqlCommand("sp_GetAthleteAndAgent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataColumn column = new DataColumn();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "firstname";
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "lastname";
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dob";
                dt.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "sport";
                dt.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "AgentName";
                dt.Columns.Add(column);



                con.Open();
                sd.Fill(dt);
                con.Close();


                foreach (DataRow dr in dt.Rows)
                {
                    sportagencylist.Add(
                        new SportAgency
                        {
                            athlete_firstname = Convert.ToString(dr["firstname"]),
                            athlete_lastname = Convert.ToString(dr["lastname"]),
                            dob = Convert.ToString(dr["birthdate"]),
                            sport = Convert.ToString(dr["sport"]),
                            AgentName = Convert.ToString(dr["AgentName"])
                        });
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: {0}", e.ToString());
                sportagencylist.Add(new SportAgency { athlete_firstname = "", athlete_lastname = "", dob = "", sport = "", AgentName = "" });
                con.Close();
            }
            
            return sportagencylist;
        }

    }
}

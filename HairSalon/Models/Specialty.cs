using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Specialty
    {
        private string _name;
        private int _id;

        public Specialty(string name, int id = 0)
        {
            _name = name;
            _id = id;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                string specialtyName = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
                allSpecialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (name) VALUES (@name);";
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;
            cmd.Parameters.Add(name);
            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty)otherSpecialty;
                bool idEquality = this.GetId().Equals(newSpecialty.GetId());
                bool nameEquality = this.GetName().Equals(newSpecialty.GetName());
                return (idEquality && nameEquality);
            }
        }

        public static Specialty Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int SpecialtyId = 0;
            string SpecialtyName = "";
            while (rdr.Read())
            {
                SpecialtyId = rdr.GetInt32(0);
                SpecialtyName = rdr.GetString(1);
            }
            Specialty newSpecialty = new Specialty(SpecialtyName, SpecialtyId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newSpecialty;
        }

        public List<Stylist> GetStylists()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT stylists.* FROM specialties 
                    JOIN specialties_stylists ON (specialties.id = specialties_stylists.specialty_id) 
                    JOIN stylists ON (specialties_stylists.stylist_id = stylists.id)
                    WHERE specialties.id = @RecipeId;";
            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@RecipeId";
            stylistId.Value = _id;
            cmd.Parameters.Add(stylistId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Stylist> stylists = new List<Stylist> { };
            while (rdr.Read())
            {
                int thisStylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                Stylist foundStylist = new Stylist(stylistName, thisStylistId);
                stylists.Add(foundStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return stylists;
        }

        public void AddStylist(Stylist newStylist)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties_stylists (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";
            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@StylistId";
            stylist_id.Value = newStylist.GetId();
            cmd.Parameters.Add(stylist_id);
            MySqlParameter specialty_id = new MySqlParameter();
            specialty_id.ParameterName = "@SpecialtyId";
            specialty_id.Value = _id;
            cmd.Parameters.Add(specialty_id);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
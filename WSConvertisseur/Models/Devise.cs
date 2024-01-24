﻿using System.ComponentModel.DataAnnotations;
namespace WSConvertisseur.Models
{
    public class Devise
    {
		private int id;

		[Required]
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string nomDevise;

		[Required]
		public string NomDevise
		{
			get { return nomDevise; }
			set { nomDevise = value; }
		}

		private double taux;

		[Required]
		public double Taux
		{
			get { return taux; }
			set { taux = value; }
		}

        public Devise(int _id, string _nomDevise, double _taux)
        {
            Id = _id;
			NomDevise = _nomDevise;
			Taux = _taux;
        }
        public Devise():this(0, "", 1) { }

        public override bool Equals(object? obj)
        {
            return obj is Devise devise &&
                   Id == devise.Id &&
                   NomDevise == devise.NomDevise &&
                   Taux == devise.Taux;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, NomDevise, Taux);
        }
    }
}

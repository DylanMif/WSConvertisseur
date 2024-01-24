namespace WSConvertisseur.Models
{
    public class Devise
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string nomDevise;

		public string NomDevise
		{
			get { return nomDevise; }
			set { nomDevise = value; }
		}

		private double taux;

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


    }
}

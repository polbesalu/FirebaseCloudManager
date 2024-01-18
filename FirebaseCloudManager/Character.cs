using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCloudManager
{
    class Character
    {
        private string nom;
        private string serie;
        private string descripcio;
        private string data;
        private string fotoURL;

        public string Nom { get => nom; set => nom = value; }
        public string Serie { get => serie; set => serie = value; }
        public string Descripcio { get => descripcio; set => descripcio = value; }
        public string Data { get => data; set => data = value; }
        public string FotoURL { get => fotoURL; set => fotoURL = value; }


        public Character(string nom, string serie, string descripcio, string data, string fotoURL)
        {
            this.nom = nom;
            this.serie = serie;
            this.descripcio = descripcio;
            this.data = data;
            this.fotoURL = fotoURL;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTester
{
    public interface IDizionario
    {

        bool isEmpty();

        /*
            svuota il dizionario
        */
        void makeEmpty();

        /*
         Inserisce un elemento nel dizionario. L'inserimento va sempre a buon fine.
         Se la chiave non esiste la coppia key/value viene aggiunta al dizionario; 
         se la chiave esiste gia' il valore ad essa associato viene sovrascritto 
         con il nuovo valore; se key e` null viene lanciata IllegalArgumentException
        */
        void insert(IComparable key, Object value);

        /*
         Rimuove dal dizionario l'elemento specificato dalla chiave key
         Se la chiave non esiste viene lanciata DictionaryItemNotFoundException 
        */
        void remove(IComparable key);

        /*
         Cerca nel dizionario l'elemento specificato dalla chiave key
         La ricerca per chiave restituisce soltanto il valore ad essa associato
         Se la chiave non esiste viene lanciata DictionaryItemNotFoundException
        */
        Object find(IComparable key);
    }

    class DictionaryItemNotFoundException { }

    public class Rubrica : IDizionario
    {
        private Dictionary<IComparable, object> clientDictionary = new Dictionary<IComparable, object>();

        public bool isEmpty() 
        {
            return this.clientDictionary.Count == 0;
        }

        public void makeEmpty() 
        {
            this.clientDictionary.Clear();
        }

        public void insert(IComparable key, object value) 
        {
            Pair coppia = new Pair(key as string, (long)value);
            bool finded = false;

            foreach(var item in clientDictionary) 
            {
                if(item.Key != key)
                {
                    clientDictionary.Add(key, coppia);
                }
                else 
                {
                    finded = true;
                }
            }

            if (finded) 
            {
                clientDictionary[key] = coppia;
            }
        }

        public void remove(IComparable key) 
        {
            if (this.clientDictionary.ContainsKey(key))
            {
                object attribute = this.clientDictionary[key];
                this.clientDictionary.Remove(key);
            }
            else
            {
                throw new KeyNotFoundException("Elemento non presente");
            }
        }

        public object find(IComparable key) 
        {
            if (this.clientDictionary.ContainsKey(key))
            {
                return this.clientDictionary[key];
            }
            else
            {
                throw new KeyNotFoundException();
            }

        }
        private class Pair
        {
            private string name;
            private long phone;
            public Pair(string aName, long aPhone)
            {
                name = aName;
                phone = aPhone;
            }

            public string getName()
            { 
                return name; 
            }

            public long getPhone()
            { 
                return phone; 
            }
            /*
                Restituisce una stringa contenente
                - la nome, "name"
                - un carattere di separazione ( : )
                - il numero telefonico, "phone"
            */
            public override string ToString()
            { 
                return name + " : " + phone; 
            }   
        }
    }
}


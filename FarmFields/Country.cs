using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFields
{
    public class Country
    {
        private string _name;
        private string _countryInfo;
        private Cultures[] clt;
        private int cltSize = 0;

        public Country()
        {
            clt = new Cultures[0];
        }
        public Country(string name, string countryInfo)
        {
            _name = name;
            _countryInfo = countryInfo;
        }

        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }


        public string GetCountryInfo()
        {
            return _countryInfo;
        }
        public void SetCountryInfo(string countryInfo)
        {
            _countryInfo = countryInfo;
        }

        public void SetCulturesCount(int size)
        {
            Array.Resize(ref clt, size);
        }


        public Cultures GetCultures(int index)
        {
            return clt[index];
        }
        public void SetCultures(int index, Cultures data)
        {
            clt[index] = data;
        }





        public int GetCltSize()
        {
            return cltSize;
        }
        public void SetCltSize(int value)
        {
            cltSize = value;
        }
        public void Remvove(object item)
        {
            for (int i = 0; i < clt.Length; i++)
            {
                if (clt[i] == item)
                {
                    clt[i] = null;
                    Cultures[] temporaryArray = new Cultures[--cltSize];
                    if (i != 0)
                    {
                        Array.Copy(clt, 0, temporaryArray, 0, i);
                        Array.Copy(clt, i + 1, temporaryArray, i, cltSize - i);

                    }
                    else
                    {
                        Array.Copy(clt, 1, temporaryArray, 0, cltSize);
                    }
                    clt = temporaryArray;
                    return;
                }
            }

        }
    }
}

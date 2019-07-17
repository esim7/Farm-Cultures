using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFields
{
    public class Cultures
    {
        private string _culture;
        private Plant[] plnt;
        private int plntSize;

        public Cultures()
        {
            plnt = new Plant[0];
        }
        public Cultures(string culture)
        {
            _culture = culture;
        }
        public string GetTypeCulture()
        {
            return _culture;
        }

        public void SetTypeCulture(string culture)
        {
            _culture = culture;
        }

        public void SetPlantsCount(int size)
        {
            Array.Resize(ref plnt, size);
        }


        public Plant GetPlant(int index)
        {
            return plnt[index];
        }
        public void SetPlnt(int index, Plant data)
        {
            plnt[index] = data;
        }

        public int GetPlntSize()
        {
            return plntSize;
        }
        public void SetPlntSize(int value)
        {
            plntSize = value;
        }

        public void Remvove(object item)
        {
            for (int i = 0; i < plnt.Length; i++)
            {
                if (plnt[i] == item)
                {
                    plnt[i] = null;
                    Plant[] temporaryArray = new Plant[--plntSize];
                    if (i != 0)
                    {
                        Array.Copy(plnt, 0, temporaryArray, 0, i);
                        Array.Copy(plnt, i + 1, temporaryArray, i, plntSize - i);

                    }
                    else
                    {
                        Array.Copy(plnt, 1, temporaryArray, 0, plntSize);
                    }
                    plnt = temporaryArray;
                    return;
                }
            }

        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFields
{
    public class Plant
    {
        private string _plantName;
        public Plant()
        {
            _plantName = "none";
        }
        public Plant(string plantName)
        {
            _plantName = plantName;
        }
        public string GetNamePlant()
        {
            return _plantName;
        }

        public void SetNamePlant(string plantName)
        {
            _plantName = plantName;
        }


    }
}

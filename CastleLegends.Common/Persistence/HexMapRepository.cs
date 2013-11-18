using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace CastleLegends.Common.Persistence
{
    public class HexMapRepository
    {
        public void Save(HexMap map, string fullPath)
        {
            if (null == map) 
                throw new ArgumentNullException("map");
            if (string.IsNullOrWhiteSpace(fullPath))
                throw new ArgumentNullException("fullPath");
        }

        public HexMap Load(string fullPath)
        {
            throw new NotImplementedException();
        }
    }
}

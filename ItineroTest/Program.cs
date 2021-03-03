using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Itinero;
using Itinero.LocalGeo;
using Itinero.Osm.Vehicles;

namespace ItineroTest
{
  class Program
  {
    static void Main(string[] args)
    {
      Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream("ItineroTest.sk.routerdb");
      
      var _router = new Router(RouterDb.Deserialize(stream));

      var profile = Vehicle.Car.Shortest();
      Coordinate[] coordinates = {
        new Coordinate(49.4045f, 18.645014f),
        new Coordinate(49.4039f, 18.627453f)
      };

      float dist = 100f;

      RouterPoint[] routerPoints =
        _router.Resolve(profile, coordinates, dist);

      var route = _router.Calculate(profile, routerPoints);
    }
  }
}

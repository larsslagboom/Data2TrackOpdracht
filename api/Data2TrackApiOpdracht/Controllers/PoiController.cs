using Data2TrackApiOpdracht.Class;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Data2TrackApiOpdracht.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoiController : ControllerBase
    {
        /*private readonly Data2TrackDbContext _dbContext;

        public PoiController(Data2TrackDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetMergeLists")]
        public IActionResult MergeLists()
        {
            var poiLocations = _dbContext.PoiLocations.ToList();
            var poiTypesAndTitles = _dbContext.PoiTypesAndTitles.ToList();

            var mergedList = poiLocations.Select(location =>
            {
                var matchingType = poiTypesAndTitles.FirstOrDefault(type => type.PoiId == location.PoiId);
                return new Poi
                {
                    PoiId = location.PoiId,
                    PoiTitle = matchingType?.Title,
                    PoiType = matchingType?.Type ?? 0,
                    PoiLat = (double)location.Latitude,
                    PoiLon = (double)location.Longitude,
                    PoiRadius = location.Radius
                };
            }).ToList();

            return Ok(mergedList);
        }*/

        [HttpGet(Name = "GetMergeLists")]
        public IActionResult MergeLists()
        {
            var poiLocations = ReadPoiLocations();
            var poiTypesAndTitles = ReadPoiTypesAndTitles();

            var mergedList = poiLocations.Select(location =>
            {
                var matchingType = poiTypesAndTitles.FirstOrDefault(type => type.PoiId == location.PoiId);
                return new Poi
                {
                    PoiId = location.PoiId,
                    PoiTitle = matchingType?.Title,
                    PoiType = matchingType?.Type ?? 0,
                    PoiLat = (double)location.Latitude,
                    PoiLon = (double)location.Longitude,
                    PoiRadius = location.Radius
                };
            }).ToList();

            return Ok(mergedList);
        }

        private List<PoiLocation> ReadPoiLocations()
        {
            var json = System.IO.File.ReadAllText("json/poiLocations.json");
            var jsonObject = JObject.Parse(json);
            var poisArray = jsonObject["pois"].ToObject<List<PoiLocation>>();
            return poisArray;
        }

        private List<PoiTypeAndTitle> ReadPoiTypesAndTitles()
        {
            var json = System.IO.File.ReadAllText("json/poiTypesAndTitles.json");
            var jsonObject = JObject.Parse(json);
            var poisArray = jsonObject["pois"].ToObject<List<PoiTypeAndTitle>>();
            return poisArray;
        }
    }
}

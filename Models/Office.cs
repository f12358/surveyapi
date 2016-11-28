using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace surveyapi.Models
{
    public class Office
    {
        public Office()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public Location Location {
            get;
            set;
        }

        public List<string> Rooms {
            get;
            set;
        }
    }

    public class Location {
        public string type {
            get;
            set;
        }

        public double[] coordinates {
            get;
            set;
        }        
    }
}

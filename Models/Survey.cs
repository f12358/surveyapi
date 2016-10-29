using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace surveyapi.Models
{
    [BsonKnownTypes(typeof(VccSurvey))]
    public class Survey
    {
        public Survey()
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

        public List<Question> Questions {
            get;
            set;
        }
    }

    public class Question
    {
        public int Number {
            get;
            set;
        }

        public string Text {
            get;
            set;
        }

        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
        [BsonRepresentation(BsonType.String)] 
        public QuestionType QuestionType {
            get;
            set;
        }

        public List<Options> Options {
            get;
            set;
        }
    }

    public enum QuestionType
    {
        SingleSelect,
        MultipleChoice
    }

    public class Options
    {
        public string Id {
            get;
            set;
        }
        
        public string Text {
            get;
            set;
        }
    }
}
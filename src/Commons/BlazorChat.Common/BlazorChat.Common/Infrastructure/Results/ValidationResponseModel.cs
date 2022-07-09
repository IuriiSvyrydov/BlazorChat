

using System.Text.Json.Serialization;

namespace BlazorChat.Common.Infrastructure.Results
{
    public class ValidationResponseModel
    {
        public ValidationResponseModel(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public ValidationResponseModel(string message): this(new List<string>{message})
        {
            
        }
        [JsonIgnore]
        public IEnumerable<string> Errors { get; set; }
        public string FlattenError =>Errors !=null ? string.Join(Environment.NewLine,Errors)
            : string.Empty;
    }
}

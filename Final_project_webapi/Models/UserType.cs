using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Final_project_webapi.Models
{
    //Showing the string instead of the number
    [JsonConverter(typeof(JsonStringEnumConverter))]


    /// <summary>
    /// Enumerate for User Type User = 1, Administrator = 2, SystemAdmin = 3
    /// </summary>
    public enum UserType
    {
        User = 1,
        Administrator = 2,
        SystemAdmin = 3
    }

    /// <summary>
    /// Enumerate for Department Type IT = 1, Sales = 2, HR = 3, Production = 4
    /// </summary>

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentType
    {
        IT = 1,
        Sales = 2,
        HR = 3,
        Production = 4
    }

}

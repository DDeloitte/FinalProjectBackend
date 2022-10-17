using System.ComponentModel;

namespace Final_project_webapi.Models
{
    public enum UserType
    {
        User = 1,
        Administrator = 2,
        SystemAdmin = 3
    }

    //class for department name
    public class DepartmentName
    {
        public const string IT = "IT";
        public const string Sales = "Sales";
        public const string HR = "HR";
        public const string Production = "Production";
    }

    //Enum for the items
    public enum ItemDepartment
    {
        [Description("IT")]
        IT,
        Sales,
        HR,
        Production
    }
}

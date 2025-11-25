using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace url_shortener.Models
{
    enum RoleType
    {
        USER = 0,
        USER_PREMIUM = 1,
        USER_ADMIN = 2
    }

    class RoleSerializer
    {
        public static RoleType FromString(string roleStr) => roleStr.ToUpper() switch
        {
            "USER" => RoleType.USER,
            "USER_PREMIUM" => RoleType.USER_PREMIUM,
            "USER_ADMIN" => RoleType.USER_ADMIN,
            _ => throw new ArgumentException("Invalid role type string")
        };

        public static string ToString(RoleType roleType) => roleType switch
        {
            RoleType.USER => "USER",
            RoleType.USER_PREMIUM => "USER_PREMIUM",
            RoleType.USER_ADMIN => "USER_ADMIN",
            _ => throw new ArgumentException("Invalid role type")
        };
    }

    public class Role
    {
        private RoleType _roleType;
        public required int Id { get; set; }
        
        [Column(TypeName = "varchar(50)")] 
        public string Role_Type
        {
            get => RoleSerializer.ToString(_roleType);
            set => _roleType = RoleSerializer.FromString(value);
        }
        [JsonIgnore]
        public IEnumerable<User> AssignedTo { get; set; } = null!;

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public List<string> Permissions { get; set; } = [];
    }
}

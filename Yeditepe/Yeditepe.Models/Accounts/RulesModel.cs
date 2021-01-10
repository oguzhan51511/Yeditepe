namespace Yeditepe.Models.Accounts
{
    public class RulesModel 
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string ModuleDescription { get; set; }
        public bool View { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}
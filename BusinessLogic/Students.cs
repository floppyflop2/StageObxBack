using StageobxDB;

namespace BusinessLogic
{
    internal class Students : Student
    {
        public string StudentDepartement { get; set; }
        public byte[] StudentDocument { get; set; }
        public string StudentEmail { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentName { get; set; }
        public string StudentTelephone { get; set; }
        public string StudentToken { get; set; }
    }
}
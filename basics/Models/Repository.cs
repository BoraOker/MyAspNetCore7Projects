namespace basics.Models
{
    public class Repository {

        private static readonly List<Course> _courses = new();

        static Repository() {

            _courses = new List<Course>() {
                new Course() {Id = 1,Title = "Aspnetcore",Description = "Aciklama1",Image = "1.png"},
                new Course() {Id = 2,Title = "JavaScript",Description = "Aciklama2",Image = "2.jpg"},
                new Course() {Id = 3,Title = "Html",Description = "Aciklama3", Image = "3.jpg"}
            };
        }

        public static List<Course> Courses {
            get {
                return _courses;
            }
        }

        public static Course? GetById(int? id) {
            return _courses.FirstOrDefault(c => c.Id == id);
        }
    }
}
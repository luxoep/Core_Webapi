using Teacher_Class;

namespace TeacherSource
{
    public class TeacherSource_Data
    {
        // 使用成员变量保存数据源
        private static List<Teacher> teacherList = new List<Teacher>()
        {
            new Teacher(1, "张老师", 31, "男", "语文老师"),
            new Teacher(2, "王老师", 41, "女", "数学老师"),
            new Teacher(3, "李老师", 21, "女", "英语老师"),
            new Teacher(4, "祁老师", 51, "男", "化学老师")
        };
        public List<Teacher> TeacherList()
        {
            return new List<Teacher>(teacherList);
        }
        public Teacher? Judgmentjudgment(int id)
        {
            foreach (Teacher item in teacherList)
            {
                if (item.Id == id) return item;
            }
            return null;
        }

        // 更新数据
        public Teacher? UpdateTeacher(Teacher updatedTeacher)
        {
            TeacherSource_Data teacherSource_Data = new TeacherSource_Data();

            Teacher? teacher = teacherSource_Data.Judgmentjudgment(updatedTeacher.Id);

            if (teacher == null) return null;

            teacher.Name = updatedTeacher.Name;
            teacher.Age = updatedTeacher.Age;
            teacher.Gender = updatedTeacher.Gender;
            teacher.Occupation = updatedTeacher.Occupation;
            
            return teacher;
        }
    }
}
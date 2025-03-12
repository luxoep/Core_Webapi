using Teacher_Class;

namespace TeacherSource
{
    public class TeacherSource_Data
    {
        // 使用成员变量保存数据源
        private List<Teacher> teacherList = new List<Teacher>()
        {
            new Teacher(1, "张老师", 31, "男", "语文老师"),
            new Teacher(2, "王老师", 41, "女", "数学老师"),
            new Teacher(3, "李老师", 21, "女", "英语老师"),
            new Teacher(4, "祁老师", 51, "男", "化学老师")
        };
        public List<Teacher> TeacherList()
        {
            return teacherList;
        }

        // 更新数据
        public Teacher UpdateTeacher(Teacher updatedTeacher)
        {
            Teacher teacher = null;

            List<Teacher> newList = TeacherList();

            foreach (Teacher item in newList)
            {
                if (item.Id == updatedTeacher.Id) teacher = item;
            }

            if (teacher != null)
            {
                teacher.Name = updatedTeacher.Name;
                teacher.Age = updatedTeacher.Age;
                teacher.Gender = updatedTeacher.Gender;
                teacher.Occupation = updatedTeacher.Occupation;
            }
            return teacher;
        }
    }
}
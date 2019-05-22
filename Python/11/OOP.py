class Student(object):
    def __init__(self,name="",school="",grade=""):
        if not name :#如果学生名为空，提示输入
            self.name = input('学生姓名是什么：')
        else :
            self.name = name
        if not school :
            self.school = input('学生姓名是什么：')
        else :
            self.school = school
        self.grade = grade
    def get_grade(self):
        while True:
            grade = input("请输入学生的年级")
            if grade .lower() not in ['K','1','2','3','4','5']:
                print('录入的年级信息不支持')
            else :
                return grade
    def print_student(self):
        print("姓名：{}".format(self.name))
        print("学校{}".format(self.school))
        print("年级{}".format(self.grade))
def print_roster(students):
    print("学生花名册")
    for student in students:
        print('*'*15)
        student.print_student()
def main():
    student1 = Student(name = '张三',school = '清华大学',grade = 'K')
    student2 = Student(name = '王二',school = '北京大学', grade = 'K')
    student3 = Student('李四','四川大学',  '3')
    students = [student1,student2,student3]
    print_roster(students)
if __name__ == "__main__":
    main()

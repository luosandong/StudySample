#创建类的语法
class MyClass ():
    a = 5
    b = 7
    def print_a (self):
        print('Hello! Here is a:{}'.format(self.a))

my_object = MyClass()
my_object.print_a()

class Student (object):#新式类是指继承object的类
    def __init__(self):  #这玩意相当于构造函数
        self.name = "None"
        self.grade = "K"
        self.district = "Orange Ccounty"
student1 = Student()

print(student1.name);
student1.name = "张三"
print(student1.name);

class School(object):
    def __init__(self,name,address):
        self.name = name 
        self.address = address
school1 = School("清华大学","北京")
print(school1.name)


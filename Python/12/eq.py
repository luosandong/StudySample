#比较两个对象是否相等
class Test():
    def __init__(self,num):
        self.num = num
    def __eq__(self,other):#判断是否相同
        if self.num == other.num:
            return True
        else :
            return False
    def __ne__(self,other):#判断不相同
        if self.num != other.num:
            return True
        else:
            return False

def main():
    a = Test(5)
    b = Test(5)
    c = Test(6)
    print(a==b)# TRUE
    print(a==c)# FALSE
    print(a!=b)# FALSE
    print(a!=c)# TRUE
if __name__ == "__main__":#写这句的作用是 让你写的脚本模块既可以导入到别的模块中用，另外该模块自己也可执行
    main()
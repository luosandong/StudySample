#main函数演示
from getpass import getpass
def getUserName():
    return input('请输入用户名:')
def getPassword():
    return getpass('请输入密码:')
def authenticate(username,password):
    if username == 'lsd' and password == '123456':
        return True
    else:
        return False
def main():
    userName = getUserName()
    password = getPassword()
    if authenticate(userName,password) :
        print("登陆成功")
    else:
        print("登录失败")
if __name__ == "__main__":
    main()
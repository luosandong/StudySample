from getpass import getpass #引用获取密码的包
userName = input("请输入您的用户名：");#接受用户的输入并给提示
password = getpass("请输入密码：");#是个系统函数
if (userName=="lsd" or password=="admin"):#多条件判断 中间需要用and 连起来 
    print("登录成功！");
else:
    print("登录失败！");

#清理用户的输入 strip 清除空格
years = input("您是哪一个出生的 [示例：1985]? ")
if  len(years.strip()) != 4 or not years.strip().isdigit():# not 关键字相当于 非！
    print("您输入的年份格式不正确");
else :
    print("OK");
#格式化字符串
msg = "您的用户名是：{}\t您出生的年份是：{}"
print(msg.format(userName,years))
print("END");

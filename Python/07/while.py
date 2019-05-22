age = input('请输入你的年龄：')
while not age.isdigit():
    print('{} 不是一个合法的年龄值'.format(age))
    age = input('请输入你的年龄：')
print('你的年龄是：{}岁'.format(age))
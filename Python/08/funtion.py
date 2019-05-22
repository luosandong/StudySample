#创建函数
def hello(name):
    print("Hello,{}".format(name))

hello('张三')
def print_total(customer_name,items):
    print("Total for {}".format(customer_name))
    total = 0 
    for item in items :
        total = total + item 
    print("${}".format(total))
print_total(items=[4.52,6.32,5.00],customer_name='Tom')
#参数设置默认值
def print_total2(items,customer_name='Unkonw'):
    print("Total for {}".format(customer_name))
    total = 0 
    for item in items :
        total = total + item 
    print("${}".format(total))
print_total2([2.3,5.8,3.00])
print_total2([6.3,5.8,3.00],'Tim')
#返回值
def getValue(itmes):
    total = 0
    for item in itmes:
        total = total + item
    return total
sumValue = getValue([3,6.7,8.6])
print(sumValue)
#返回多个值
def getSomeValue():
    return 'tom',33,'美国'
name,age,country = getSomeValue()
print("来至“{}”的{}，今年{}岁了".format(country,name,age))



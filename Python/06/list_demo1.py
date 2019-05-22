#创建列表
fruit = ['Apple','Ctrawberry','Bear','Papya']
print(len(fruit));#打印数组长度
list2 = [] #空列表
print(fruit.index('Bear'))#打印某项的下标
#检查某项在数组中是否存在
print('Apple1' in fruit)
#添加项到列表
fruit.append('Xi an')
#使用extend方法 合并列表
list2.append('cat bb');
fruit.extend(list2)
fruit.sort()
print(fruit)
#列表排序
numbers = ['Bad','Dog','Dog','Cat']
numbers.sort()
print(numbers)
print(numbers.count('Dod'))

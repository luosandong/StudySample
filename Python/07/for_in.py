#循环练习
names = ['Tom','Jerry','Keite','Zhangsan']
# for name in names:
#     print(name)

for i in range(len(names)):
    print("第{}项：{}".format(i+1,names[i]))
#continue 和break
numbers = [1,2,3,4,5,6,7,8,9,10]
for n in numbers:
    if n%2 == 0 :
        continue;
    else :
        print(n)

for n in numbers :
    if n == 5:
        print('找到了');
        break
    else :
        print(n)
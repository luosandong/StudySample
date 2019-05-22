#字典演示
myDict = {}
for i in range(30) :
    i=i+1;
    myDict['Key_{}'.format(i)]='Name_{}'.format(i)
print(myDict)
for key in  myDict  :
    print("{}:{}".format(key,myDict[key]))
    print('*******'*5)
#检查某个键是否存在  '' in dict
# myDict.clear();
myDict = {'lsd':'35','rj':32}
print( 'lsd' in myDict)

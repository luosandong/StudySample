#string 演示
s = "hello world";
print (s);
print("Apple:")
print("$ 1.99 / lb");
name = 'Ketie';
print(len(name));#字符串长度
print(name.upper());#转大写
print(name.lower());#转小写
title = "wind in the willows";
print (title.capitalize());#首字母大写
print(title.title());#每个单词首字母大写
birth_year = '1980'
state = "VA "
print(birth_year.isdigit());#检查是否全数组成的字符串
print(state.isdigit());
print(birth_year + " "+state);
five = state * 5;
print(five);#打印5个
five="5";
print(five * -5);#乘以负责将得到空字符
try:
	five*0.1
except Exception as e:
	print("异常信息")
	print(e);
else:
	pass
finally:
	print('finally');
print("hello\nworld");#\n可以换行
print("hello\tworld");#\t可以空格  
print('My\' name');#\转义
print("  Luo sd  ".strip());#去除前后空格
print("***Luo**sd**".strip('*'));#去除前后*号
print("***Luo sd***".rstrip('*'))#去右边*
print("***Luo sd***".lstrip("*"));#去左边*
mystring = "int string int float int";
print(mystring.count('int'));#检查出现次数
print(mystring.find('strb'));#第一次出现的位置 没找到返回-1 相当于C# indexOf
print(mystring.replace("string","Text"));#字符串替换

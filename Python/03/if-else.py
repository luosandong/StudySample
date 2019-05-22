#逻辑控制
print("if else 演示")
num = 5
if num < 1:  #此处一定要有冒号
	print(num);  #分号其实可省略
else:
	print("error");
print("elif语法演示...");#elif 相当于if else if
total=40.29
if total > 50:
	print("You get free shipping!");
	print("大于50")
elif total >40:
	print("Spend abit more to get free shipping");
	print("大于40");
else:
	print("BBBB");
print("End");

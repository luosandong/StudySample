#try 异常捕获
a=5
try:
	a=a+1;
	a = int(a)/int(2)
except :
	#print("不能除0"); #如果此处不想执行任何语句，必须要写个pass
	pass
print(a);

#格式化字符串的占位符应用 
price = 5
sumMoney = 0
goodName = input("请输入您购买的商品名称：")
goodCount =  input('请输购买的数量：')
msg = "您购买了{goodCount}个{goodName}，共{sumMoney}元钱！";
try:
    if  not goodCount.strip().isdigit():
        goodCount = input("请输入正确的数量:");
    else :
        sumMoney = (price * int(goodCount))
        print(msg.format(goodName=goodName,sumMoney=sumMoney,goodCount=goodCount))
        tmpSumMoney = int(input("请输入支付金额："));
        if  tmpSumMoney == sumMoney :
            print("支付完成！谢谢惠顾!");
except Exception as e:
    print("出错了:{}".format(e));

if goodCount == "2" :
    print("OK")



